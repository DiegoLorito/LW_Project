using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class ScreenEditUser : AppScreen
{
    public UserData dataUser;
    //public SectionProfileEditUser sectionEditUser;

    public override void LoadContent()
    {
        //ParentZoneEvents.ShowScreenEditUser(dataUser);
        //sectionEditUser.LoadContent();

        ContentLoaded();
        ContentSetted();
    }

    public override void ContentSetted()
    {
        GameEvents.HideLoadingScreen();
    }
    public void UpdateUserData()
    {
        //string bday = sectionEditUser.inputDay.text + "-" + sectionEditUser.inputMonth.text + "-" + sectionEditUser.inputYear.text;
        string bday = "";

        BEUser user = new BEUser();
        user.id_user = dataUser.id;
        user.str_user_name = "";
        user.dte_birth_date = bday;
        user.id_client = AppServerData.instance.dataClient.id;

        dataUser.name = "";
        dataUser.birthDate = System.DateTime.Parse(bday);

        List<IEnumerator> routines = new List<IEnumerator>()
        {
            RoutinesController.Action(()=> GameEvents.CanvasInteractable(false)),
            TransitionController.instance.RoutineTransitionIn(),
            //DAUser.Update(sectionEditUser.UpdateUser,user),
            DAUserAccount.UpdateAvatarColor(DBCallbacks.UpdateAvatarColor,dataUser.avatarCode,dataUser.idAccount),
            RoutinesController.Action(()=> AppServerData.instance.UpdateUser(dataUser)),
            RoutinesController.Action(()=> controller.TransitionAppScreen(3)),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    private void RestartProgress()
    {
        List<IEnumerator> routines = new List<IEnumerator>()
        {
            RoutinesController.Action(()=> GameEvents.CanvasInteractable(false)),
            TransitionController.instance.RoutineTransitionIn(),
            //DAProgress.Delete(sectionEditUser.DeleteProgress,dataUser.id),
            RoutinesController.Action(()=> AppServerData.instance.RestartUser(dataUser)),
            RoutinesController.Action(()=> controller.TransitionAppScreen(3)),
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }
    private void DeleteProfile()
    {
        List<IEnumerator> routines = new List<IEnumerator>()
        {
            RoutinesController.Action(()=> GameEvents.CanvasInteractable(false)),
            TransitionController.instance.RoutineTransitionIn(),
            //DAUser.Delete(sectionEditUser.DeleteUser,dataUser.id),
            RoutinesController.Action(()=> AppServerData.instance.RemoveUser(dataUser.id)),
            RoutinesController.Action(()=> controller.TransitionAppScreen(3)),
            
        };

        StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
    }

    #region Dialogs Methods

    public void ShowDialogDetelProfile(DialogData dataDialog)
    {
        dataDialog.actionOne = () => GameEvents.HideDialog(DeleteProfile);
        dataDialog.actionTwo = () => GameEvents.HideDialog();

        GameEvents.ShowDialog(dataDialog);
    }
    public void ShowDialogRestartProgress(DialogData dataDialog)
    {
        dataDialog.actionOne = () => GameEvents.HideDialog(RestartProgress);
        dataDialog.actionTwo = () => GameEvents.HideDialog();

        GameEvents.ShowDialog(dataDialog);
    }

    #endregion
}
