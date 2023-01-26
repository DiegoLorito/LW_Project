using System;
using System.Collections;
using UnityEngine;

public static class GameEvents
{
    public static event Action<bool> onCanvasInteractable;
    public static void CanvasInteractable(bool value) => onCanvasInteractable?.Invoke(value);

    public static event Action<string> onTransitionScene;
    public static void TransitionScene(string scene) => onTransitionScene?.Invoke(scene);

    public static event Action<int> onChangeAppScreen;
    public static void ChangeAppScreen(int current) => onChangeAppScreen?.Invoke(current);

    public static event Action<int> onTransitionAppScreen;
    public static void TransitionAppScreen(int index) => onTransitionAppScreen?.Invoke(index);

    //=============== ANIMACION TRANSICION

    public static event Action<Action> onScreenTransition;
    public static void ScreenTransition(Action action) => onScreenTransition?.Invoke(action);


    public static event Action<float> onMatchWidthOrHeight;
    public static void MatchWidthOrHeight(float value)
    {
        onMatchWidthOrHeight?.Invoke(value);
    }

    //=============== 

    public static event Action onUpdateTransitionPatternResolution;
    public static void UpdateTransitionPatternResolution()
    {
        onUpdateTransitionPatternResolution?.Invoke();
    }

    //=============== 

    public static event Action onShowSecurityPin;
    public static void ShowSecurityPin() => onShowSecurityPin?.Invoke();

    //=============== 

    public static event Action<UserData> onUpdateUserProfile;
    public static void UpdateUserProfile(UserData dataUser) => onUpdateUserProfile?.Invoke(dataUser);

    //=============== 

    public static event Func<SO_Vocabulary> onGetCurrentVocabulary;
    public static SO_Vocabulary GetCurrentVocabulary() => onGetCurrentVocabulary?.Invoke();

    public static event Func<int> onGetCurrentIndexVocab;
    public static int GetCurrentIndexVocab() => (int)(onGetCurrentIndexVocab?.Invoke());

    public static event Func<bool> onGetHintStatus;
    public static bool GetHintStatus() => onGetHintStatus();

    //=============== Inicio de juego

    public static event Action onGameStart;
    public static void GameStart() => onGameStart?.Invoke();

    //=============== Fin de juego

    public static event Action onGameFinish;
    public static void GameFinish() => onGameFinish?.Invoke();



    public static event Action<bool> onButtonsSpriteInteractable;
    public static void ButtonsSpriteInteractable(bool interactable) => onButtonsSpriteInteractable?.Invoke(interactable);


    //=============== Respuesta en modo de VocabularyData

    public static event Action<VocabularyData> onAnswerVocabulary;
    public static void AnswerVocabulary(VocabularyData answer) => onAnswerVocabulary?.Invoke(answer);

    //=============== Respuesta en modo de GameObject

    public static event Action<GameObject> onAnswerVocabularyObject;
    public static void AnswerVocabularyObject(GameObject answerObject) => onAnswerVocabularyObject?.Invoke(answerObject);

    public static event Action<GameObject> onAnswerObject;
    public static void AnswerObject(GameObject answer) => onAnswerObject?.Invoke(answer);

    //=============== Respuesta Incorrecta

    public static event Action onAnswerIncorrect;
    public static void AnswerIncorrect() => onAnswerIncorrect?.Invoke();

    #region Rewards

    public static event Action onRewardNormalChest;
    public static void RewardNormalChest() => onRewardNormalChest?.Invoke();

    public static event Action<SO_LoriItem[]> onRewardSpecialChest;
    public static void RewardSpecialChest(SO_LoriItem[] rewards) => onRewardSpecialChest?.Invoke(rewards);

    public static event Action<SO_LoriItem[]> onRewardContent;
    public static void RewardContent(SO_LoriItem[] rewards) => onRewardContent?.Invoke(rewards);

    #endregion


    #region DIALOGS

    public static event Action<DialogData> onShowDialog;
    public static void ShowDialog(DialogData dialog) => onShowDialog?.Invoke(dialog);

    public static event Action<int> onShowNormalDialog;
    public static void ShowNormalDialog(int index) => onShowNormalDialog?.Invoke(index);

    public static event Action<DialogCustom> onShowCustomDialog;
    public static void ShowCustomDialog(DialogCustom dialog) => onShowCustomDialog?.Invoke(dialog);

    public static event Action onHideCustomDialog;
    public static void HideCustomDialog() => onHideCustomDialog?.Invoke();

    //=============== OCULTAMOS POP UP
    public static event Action<Action> onHideDialog;
    public static void HideDialog(Action action = null)
    {
        if(onHideDialog != null)
        {
            onHideDialog(action);
        }
        else
        {
            Debug.LogWarning("No listeners for the event: onHideDialog");
        }
    }

    //=============== MOSTRAMOS POP UP ERROR DATA BASE
    public static event Action<Action,bool,string, string> onShowErrorDialog;
    public static void ShowErrorDialog(Action action, bool simple, string title, string description) => onShowErrorDialog?.Invoke(action,simple, title, description);
    #endregion

    #region LOADING SCREEN

    public static event Action onHideLoadingScreen;
    public static void HideLoadingScreen() => onHideLoadingScreen ?.Invoke();

    #endregion




    //=============== TRANSICION FADE PANTALLA
    public static event Action<Action> onFadeTransition;
    public static void FadeTransition(Action myAction)
    {
        if (onFadeTransition != null) onFadeTransition(myAction);
        else
        {
            Debug.LogWarning("No listeners for the event: onFadeTransition");
        }
    }

    //=============== BACKGROUND CAMBIAR COLOR
    public static event Action<Color> onBackgroundSetColor;
    public static void BackgroundSetColor(Color color)
    {
        if (onBackgroundSetColor != null) onBackgroundSetColor(color);
        else
        {
            Debug.LogWarning("No listeners for the event: onBackgroundSetColor");
        }
    }

    //=============== VOLVER PANTALLA
    public static event Action onBackScreen;
    public static void BackScreen()
    {
        if (onBackScreen != null) onBackScreen();
        else
        {
            Debug.LogWarning("No listeners for the event: onBackScreen");
        }
    }

    //=============== ESTABLECER GRID JUEGOS
    public static event Action onSetGridGames;
    public static void SetGridGame()
    {
        if (onSetGridGames != null) onSetGridGames();
        else
        {
            Debug.LogWarning("No listeners for the event: onSetGridGames");
        }
    }

    #region CLIENT
    public static event Action<ResponseClient> onLogIn;
    public static void LogIn(ResponseClient response) => onLogIn?.Invoke(response);

    public static event Action onLogOut;
    public static void LogOut() => onLogOut?.Invoke();

    public static event Action<ResponseClientID> onSignInSuccessful;
    public static void SignInSuccessful(ResponseClientID response) => onSignInSuccessful?.Invoke(response);

    public static event Action<ErrorResponse> onSignInError;
    public static void SignInError(ErrorResponse error) => onSignInError?.Invoke(error);

    public static event Action<bool> onUpdateClientResponse;
    public static void UpdateClientResponse(bool response) => onUpdateClientResponse?.Invoke(response);

    #endregion


    #region USER
    //=============== CREAR USUARIO
    public static event Action<UserData> onCreateUser;
    public static void CreateUser(UserData data) => onCreateUser?.Invoke(data);

    //=============== ELIMINAR USUARIO
    public static event Action<bool> onDeleteUserResponse;
    public static void DeteleUserResponse(bool response) => onDeleteUserResponse?.Invoke(response);

    //=============== ACTUALIZAR USUARIO
    public static event Action<bool> onUpdateUserResponse;
    public static void UpdateUserResponse(bool response) => onUpdateUserResponse?.Invoke(response);

    //=============== ENCONTRAR USUARIOS
    public static event Action<int> onFindUsers;
    public static void FindUsers(int clientId) => onFindUsers?.Invoke(clientId);

    //=============== USUARIOS ENCONTRADOS
    public static event Action<ResponseReportUser> onUsersFound;
    public static void UsersFound(ResponseReportUser response)
    {
        if (onUsersFound != null)
        {
            onUsersFound(response);
        }
        else
        {
            Debug.LogWarning("No listeners for the event: onUsersFound");
        }
    }

    //=============== USUARIOS NO ENCONTRADOS
    public static event Action<ErrorResponse> onUserChildNotFounded;
    public static void UserChildNotFounded(ErrorResponse error)
    {
        if (onUserChildNotFounded != null)
        {
            onUserChildNotFounded(error);
        }
        else
        {
            Debug.LogWarning("No listeners for the event: onUserChildNotFounded");
        }
    }

    #endregion

    #region USER ACCOUND FIND
    //=============== ENCONTRAR CUENTA DE USUARIO
    public static event Action<int> onFindUserAccount;
    public static void FindUserAccount(int userId)
    {
        if (onFindUserAccount != null) onFindUserAccount(userId);
        else
        {
            Debug.LogWarning("No listeners for the event: onFindUserAccount");
        }
    }

    //=============== CUENTA DE USUARIO ENCONTRADA
    public static event Action<ResponseUserAccount> onUserAccountFound;
    public static void UserAccountFound(ResponseUserAccount response)
    {
        if (onUserAccountFound != null) onUserAccountFound(response);
        else
        {
            Debug.LogWarning("No listeners for the event: onUserAccountFound");
        }
    }

    public static event Action<ErrorResponse> onUserAccountNotFound;
    public static void UserAccountNotFound(ErrorResponse error) => onUserAccountNotFound?.Invoke(error);
    #endregion

    #region USER CREATE PROGRESS
    //=============== CREAR PROGRESO
    public static event Action<int, string> onCreateProgress;
    public static void CreateProgress(int contentId, string time) => onCreateProgress?.Invoke(contentId, time);

    //=============== PROGRESO CREADO
    public static event Action<ResponseProgressUserAccount> onProgressCreated;
    public static void ProgressCreated(ResponseProgressUserAccount response)
    {
        if (onProgressCreated != null)
        {
            onProgressCreated(response);
        }
        else
        {
            Debug.LogWarning("No listeners for the event: onProgressCreated");
        }
    }

    //=============== PROGRESO NO CREADO
    public static event Action<ErrorResponse> onProgressNotCreated;
    public static void ProgressNotCreated(ErrorResponse error) => onProgressNotCreated?.Invoke(error);

    #endregion

    public static event Action<Sprite> onSetAvatarSprite;
    public static void SetAvatarSprite(Sprite sprite)=> onSetAvatarSprite?.Invoke(sprite);

    public static event Action<int,int> onUpdateProgressUnitWorld;
    public static void UpdateProgressUnitWorld(int currentUnitIndex, int maxUniIndex) => onUpdateProgressUnitWorld?.Invoke(currentUnitIndex, maxUniIndex);

    #region CONTENT PROGRESS
    //=============== ENCONTRAR PROGRESO DE CONTENIDO
    public static event Action<int, int, int> onFindContentProgress;
    public static void FindContentProgress(int idUser, int idWorld, int idUnit) => onFindContentProgress?.Invoke(idUser, idWorld, idUnit);

    //=============== PROGRESO DE CONTENIDO ENCONTRADO
    public static event Action<ResponseReportContent> onContentProgressFound;
    public static void ContentProgressFound(ResponseReportContent response) => onContentProgressFound?.Invoke(response);

    //=============== PROGRESO DE CONTENIDO NO ENCONTRADO
    public static event Action<ErrorResponse> onContentProgressNotFound;
    public static void ContentProgressNotFound(ErrorResponse error) => onContentProgressNotFound(error);

    //=============== REINICIAR PROGRESO
    public static event Action<bool> onRestartProgressResponse;
    public static void RestartProgressResponse(bool response) => onRestartProgressResponse?.Invoke(response);

    #endregion

    public static event Action<Action,bool, string, string> onConectionError;
    public static void ConectionError(Action action = null,bool simple = false, string title = "", string description = "") => onConectionError?.Invoke(action,simple, title, description);


}
