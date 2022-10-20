using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class HubSideBar : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private RectTransform sideBar;
    [SerializeField] private Button buttonClose;
    [SerializeField] private Image background;

    [Header("User Data")]
    [SerializeField] private UserProfile profile;

    [Header("Hub Options")]
    [SerializeField] private Button buttonUnits;
    [SerializeField] private Button buttonLoriland;
    [SerializeField] private Button buttonParentZone;

    private void Awake()
    {
        GameEvents.onUpdateUserProfile += UpdateUserProfile;

        buttonClose.onClick.AddListener(()=> HideSideBar());

        buttonParentZone.onClick.AddListener(GameEvents.ShowSecurityPin);
        buttonUnits.onClick.AddListener(ChangeAppScreen);

        void ChangeAppScreen()
        {
            HideSideBar(false);

            List<IEnumerator> routines = new List<IEnumerator>()
            {
                TransitionController.instance.RoutineTransitionIn(),
                RoutinesController.Action(() => GameEvents.TransitionAppScreen(0)),
            };

            StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
        }
    } 

    private void UpdateUserProfile(UserData dataUser)=> profile.SetData(dataUser);
    public void ShowSideBar()
    {
        GameEvents.CanvasInteractable(false);

        background.color.SetAlpha(0);
        background.gameObject.Enable();
        sideBar.gameObject.Enable();

        background.DOFade(0.3f, 0.5f);
        sideBar.DOAnchorPosX(0, 0.5f).OnComplete(()=> GameEvents.CanvasInteractable(true)); 
    }
    private void HideSideBar(bool enableCanvasInteractable = true)
    {
        GameEvents.CanvasInteractable(false);

        float sideBarWidth = sideBar.rect.width;

        background.DOFade(0, 0.5f);
        sideBar.DOAnchorPosX(-sideBarWidth, 0.5f).OnComplete(()=>
        {
            background.gameObject.Disable();
            sideBar.gameObject.Disable();
            GameEvents.CanvasInteractable(enableCanvasInteractable);
        });

    }

    private void OnDestroy()
    {
        GameEvents.onUpdateUserProfile -= UpdateUserProfile;
    }
}
