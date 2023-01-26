using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HubUnits : AppScreen
{
    private SO_WorldCore dataWorld;
    private List<SO_UnitCore> dataUnitsCore;
    private UserData currentUser;

    //[Space(10)]
    //public AppHubController controller;

    [Space(10)]
    public TMPro.TextMeshProUGUI worldName;
    public Transform containerCards;
    public GameObject cardUnit;
    public UnityEngine.UI.ScrollRect scroll;

    private List<CardUnit> cards;

    private void Awake()
    {
        cards = new List<CardUnit>();
        dataUnitsCore = new List<SO_UnitCore>();
    }

    public override void LoadContent()
    {
        //dataWorld = AppServerData.instance.dataCurrentUser.World;
        dataWorld = LocalData.Instance.GetDataWorld("UP");

        scroll.horizontalNormalizedPosition = 0;

        List<IEnumerator> routines = new List<IEnumerator>
        {
            RoutinesController.Action(ContentLoaded),
            RoutinesController.Action(ContentSetted),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    public override void ContentLoaded()
    {
        currentUser = AppServerData.instance.dataCurrentUser;

        dataUnitsCore = new List<SO_UnitCore>(DataUnitCore.Instance.Data.Values);

        


        worldName.text = dataWorld.Name;

        cards.EnableItemList(false);

        //=== Si hay mas unidades que cards, instanciamos más cards.
        if (dataUnitsCore.Count > cards.Count)
        {
            int diference = dataUnitsCore.Count - cards.Count;

            for (int i = 0; i < diference; i++)
            {
                cards.Add(Instantiate(cardUnit, containerCards).GetComponent<CardUnit>());
                cards[i].screen = this;
            }
        }

        //=== Establecemos todsa las cards
        for (int i = 0; i < dataUnitsCore.Count; i++)
        {
            cards[i].unitData = dataUnitsCore[i];
            cards[i].status = i < currentUser.indexMaxUnit ? UnitStatus.Completed: UnitStatus.Locked;
            cards[i].current = i == currentUser.indexCurUnit;
        }

        //=== Filtramos la unidad máxima
        //cards.Find(x=> x.unitData == user.MaximunUnit).status = UnitStatus.InProgress;
        cards[currentUser.indexMaxUnit].status = UnitStatus.InProgress;

        // Establecemos los botones
        for (int i = 0; i < dataUnitsCore.Count; i++)
        {
            cards[i].gameObject.SetActive(true);
            cards[i].SetButton();
        }

        ControladorData.instance.unitsLoaded = true;
    }
    public override void ContentSetted()
    {
        controller.fadeScene.DOFade(0, 0.5f);
        base.ContentSetted();
    }
}
