using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUsers : AppScreen
{
    public int maxUserAmount = 3;
    public Transform contentChildUser;
    public GameObject buttonAddChild;
    public GameObject prefButtonChildProfile;

    public ScreenEditUser screenEditUser;

    private List<CardUser> cards;

    private void Awake()
    {
        //ParentZoneEvents.onShowScreenEditUser += EdiUser;

        cards = new List<CardUser>();

        for (int i = 0; i < contentChildUser.childCount - 1; i++)
        {
            cards.Add(contentChildUser.GetChild(i).GetComponent<CardUser>());
            cards[i].gameObject.SetActive(false);
        }
    }

    public override void LoadContent()
    {
        int idClient = AppServerData.instance.dataClient.id;

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            //DAReportUser.FindUsersProgress(DBCallbacks.FindUsers, idClient),
            RoutinesController.Action(ContentLoaded),
            RoutinesController.Action(ContentSetted)
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    public override void ContentLoaded()
    {
        cards.EnableItemList(false);

        if(cards == null) cards = new List<CardUser>();

        if (cards.Count < AppServerData.instance.users.Count)
        {
            int diference = AppServerData.instance.users.Count - cards.Count;

            for (int i = 0; i < diference; i++)
            {
                cards.Add(Instantiate(prefButtonChildProfile, contentChildUser).GetComponent<CardUser>());
                //cards[i].controller = this;
            }
        }

        for (int i = 0; i < AppServerData.instance.users.Count; i++)
        {
            UserData dataUser = AppServerData.instance.users[i];

            cards[i].gameObject.SetActive(true);
            cards[i].data = dataUser;
            cards[i].SetData();

            cards[i].button.onClick.RemoveAllListeners();
            cards[i].button.onClick.AddListener(()=> SelectUser(dataUser));
        }

        buttonAddChild.SetActive(AppServerData.instance.users.Count < maxUserAmount);
        buttonAddChild.transform.SetAsLastSibling();

        ControladorData.instance.usersLoaded = true;
    }
    public override void ContentSetted()
    {
        GameEvents.HideLoadingScreen();
        controller.fadeScene.DOFade(0,0.5f);
    }
    public void SelectUser(UserData dataUser)
    {
        //GameEvents.CanvasInteractable(false);

        AppServerData.instance.dataCurrentUser = dataUser;
        ControladorData.instance.data.user = dataUser;
        ControladorData.instance.SaveAppData();

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].EnableCheck();
        }

        Debug.Log("Working on Transitions");

        //GameEvents.TransitionScene("App Hub");
    }
    public void EdiUser(UserData dataUser)
    {
        screenEditUser.dataUser = dataUser;
        controller.TransitionAppScreen(5);
    }

    public void LogOut()
    {
        ControladorData.instance.unitsLoaded = false;
        ControladorData.instance.usersLoaded = false;
        ControladorData.instance.data.loggedIn = false;
        ControladorData.instance.SaveAppData();

        PlayerPrefs.SetInt("intro", 0);

        controller.TransitionAppScreen(0);
    }
    public void DialogLogOut(DialogData dataDialog)
    {
        dataDialog.actionOne = () => GameEvents.HideDialog(LogOut);
        dataDialog.actionTwo = () => GameEvents.HideDialog();
        
        GameEvents.ShowDialog(dataDialog);
    }
    private void OnDestroy()
    {
        //ParentZoneEvents.onShowScreenEditUser -= EdiUser;
    }
}
