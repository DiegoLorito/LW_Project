using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HubContent : AppScreen
{
    private SO_ContentCore[] _dataContent;
    private SO_UnitCore _dataUnit;


    [Header("TEMP")]
    [SerializeField] private int lastCompleted;

    [Space(10)]
    public UserProgressData userProgressData;

    [Space(10)]
    public TMPro.TextMeshProUGUI unitName;

    [Header("User Profile")]
    [SerializeField] private UserProfile userProfile;

    [Header("Objects")]
    [SerializeField] private GameObject spotContent;
    [SerializeField] private GameObject normalChest;
    [SerializeField] private GameObject specialChest;
    [SerializeField] private SpotTrophy spotTrophy;

    [Header("Scroll")]
    [SerializeField] private UnityEngine.UI.ScrollRect scroll;
    [SerializeField] private int scrollItemIndex;

    public Transform containerspots;
    public DialogUnitUnlocked cardUnitUnlocked;

    private List<SpotContent> _spotsContent;
    private List<Rwd_NormalChest> _spotsNormalChest;
    private List<Rwd_SpecialChest> _spotsSpecialChest;

    [SerializeField] private List<SpotBase> _spotBase;


    private void Awake()
    {
        _spotBase = new List<SpotBase>();
        _spotsContent = new List<SpotContent>();
        _spotsNormalChest = new List<Rwd_NormalChest>();
        _spotsSpecialChest = new List<Rwd_SpecialChest>();
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(2)) GameEvents.ShowCustomDialog(cardUnitUnlocked);
        if (Input.GetMouseButtonDown(1))
        {
            //StartCoroutine(TestLayout());
        }
    }

    public override void LoadContent()
    {
        GameEvents.UpdateUserProfile(AppServerData.instance.dataCurrentUser);

        userProfile.SetData(AppServerData.instance.dataCurrentUser);

        scroll.horizontalNormalizedPosition = 0;

        // Si la unidad esta completa, mostramos la pantalla de juegos
        if (AppServerData.instance.CurrentUnitIsCompleted())
        {
            List<IEnumerator> routines = new List<IEnumerator>()
            {
                RoutinesController.Action(ContentLoaded),
                RoutinesController.Action(ContentSetted),
                RoutinesController.Action(GameEvents.HideLoadingScreen),
            };

            StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
        }
        // Si la unidad no esta completa, pedimos el progreso de los juegos
        else
        {
            UserData user = AppServerData.instance.dataCurrentUser;

            List<IEnumerator> routines = new List<IEnumerator>()
            {
                DAReportContent.FindContentProgress(DBCallbacks.FindContentProgress, user.idAccount, user.worldId, AppServerData.instance.dataCurrentUser.CurrentUnit.code),
                RoutinesController.Action(ContentLoaded),
                RoutinesController.Action(VerifyContentProgress),
                RoutinesController.Action(ContentSetted),
                RoutinesController.Action(GameEvents.HideLoadingScreen),
            };

            StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
        }

    }
    public override void ContentLoaded()
    {
        string currentUnitCode = AppServerData.instance.dataCurrentUser.CurrentUnit.code;

        DataContentCore.Instance.SetContentData();

        ControladorData.instance.data.userSelected = true;
        ControladorData.instance.SaveAppData();

        //_dataContent = DataContentCore.Instance.Data.ToArray();
        _dataContent = DataContentCore.Instance.Data.ToArray();
        _dataUnit = DataUnitCore.Instance.Data[currentUnitCode];

        int indexContent = 0;
        int indexNormalChest = 0;
        int indexSpecialChest = 0;

        int _amountContent = DataContentCore.Instance.amountContent;
        int _amountNormalChest = DataContentCore.Instance.amountNormalChest;
        int _amountSpecialChest = DataContentCore.Instance.amountSpecialChest;


        unitName.text = _dataUnit.Name;

        _spotsNormalChest.EnableItemList(false);
        _spotsContent.EnableItemList(false);
        spotTrophy.gameObject.SetActive(false);

        _spotBase.Clear();

        containerspots.GetComponent<UnityEngine.UI.ContentSizeFitter>().enabled = true;
        containerspots.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>().enabled = true;


        //=============== INICIALIZACIONES ===============//

        PoolingContent();
        PoolingNormalChest();
        PoolingSpecialChest();

        //=== Inicializamos los spots
        InitSpots();
        //=== Inicializamos el trofeo
        InitTrophy();

        //=============== DISABLE LAYOUTS ===============//

        //Invoke("DisableLayouts", 0.5f);
        DOVirtual.DelayedCall(1, SetAndDisableLayouts);

        //=============== SCROLL POSITIOn ===============//

        //=== Posicionamos el scroll
        // PositionScroll();


        //=============== METODOS ===============//

        //=== Inicializar Spots
        void InitSpots()
        {
            // Asignamos la data de cada contenido y ordenamos su lugar en la fila
            for (int i = 0; i < _dataContent.Length; i++)
            {

                switch (_dataContent[i].category)
                {
                    case Enm_ContentCategory.Content:

                        SpotContent _content = _spotsContent[indexContent];
                        SO_Content _dtContent =  _dataContent[i] as SO_Content;

                        SetDataContent(_content, _dtContent);

                        _spotBase.Add(_spotsContent[indexContent]);
                        indexContent++;

                        break;
                    case Enm_ContentCategory.NormalChest:

                        Rwd_NormalChest _contentNormalChest = _spotsNormalChest[indexNormalChest];
                        SO_NormalChest _dtNormalChest = (SO_NormalChest)_dataContent[i];

                        SetNormalChest(_contentNormalChest, _dtNormalChest);

                        _spotBase.Add(_spotsNormalChest[indexNormalChest]);
                        indexNormalChest++;

                        break;
                    case Enm_ContentCategory.SpecialChest:

                        Rwd_SpecialChest _contentSpecialChest = _spotsSpecialChest[indexSpecialChest];
                        SO_SpecialChest _dtSpecialChest = (SO_SpecialChest)_dataContent[i];

                        SetSpecialChest(_contentSpecialChest, _dtSpecialChest);

                        _spotBase.Add(_spotsSpecialChest[indexSpecialChest]);
                        indexSpecialChest++; 

                        break;
                    default:
                        break;
                }

                // Establecemos las configuraciones generales
                SpotBase _spot = _spotBase[i];

                _spot.Layout.enabled = true;
                _spot.Layout.padding.bottom = 0;
                _spot.transform.SetSiblingIndex(i);
                _spot.gameObject.SetActive(true);
                _spot.SetData();

                // Posicionamos los layouts correspondientes
                int index = i;
                if (index % 2 != 0) _spotBase[index].Layout.padding.bottom = -256;
            }
        }

        //=== Object Pooling Contenido
        void PoolingContent()
        {
            //Si hay mas contenido que spots, instanciamos más spots.
            if (_spotsContent.Count < _amountContent)
            {
                int difference = _amountContent - _spotsContent.Count;

                for (int i = 0; i < difference; i++)
                {
                    _spotsContent.Add(Instantiate(spotContent, containerspots).GetComponent<SpotContent>());
                }
            }
        }
        //=== Object Pooling Cofres Normales
        void PoolingNormalChest()
        {
            // Si hay más cofres que spots, instanciamos más cofres.
            if (_spotsNormalChest.Count < _amountNormalChest)
            {
                int difference = _amountNormalChest - _spotsNormalChest.Count;

                for (int i = 0; i < difference; i++)
                {
                    _spotsNormalChest.Add(Instantiate(normalChest, containerspots).GetComponent<Rwd_NormalChest>());
                }
            }
        }
        //=== Object Pooling Cofres Especiales
        void PoolingSpecialChest()
        {
            //Si hay más cofres que spots, instanciamos más cofres.
            if (_spotsSpecialChest.Count < _amountSpecialChest)
            {
                int difference = _amountSpecialChest - _spotsSpecialChest.Count;

                for (int i = 0; i < difference; i++)
                {
                    _spotsSpecialChest.Add(Instantiate(specialChest, containerspots).GetComponent<Rwd_SpecialChest>());
                }
            }
        }


        //=== Estableemos el contenido
        void SetDataContent(SpotContent _spotContent, SO_Content data)
        {
            _spotContent.data = data;
            _spotContent.dataUnitCore = _dataUnit;

            //=== TEMP
            SpotContent spot = _spotContent;

            _spotContent.onClick = () => ContentCompleted(spot);
            //========

            //_spotContent.SetData();
        }
        //=== Estableemos el cofres normales
        void SetNormalChest(Rwd_NormalChest _spotNormalChest, SO_NormalChest data)
        {
            _spotNormalChest.data = data;
        }
        //=== Inicialización cofres especiales
        void SetSpecialChest(Rwd_SpecialChest _spotSpecialChest, SO_SpecialChest data)
        {
            _spotSpecialChest.data = data;
        }
        //=== Inicializamos el trofeo
        void InitTrophy()
        {
            spotTrophy.layout.padding.bottom = 0;
            spotTrophy.layout.enabled = true;
            spotTrophy.transform.SetAsLastSibling();
            spotTrophy.gameObject.SetActive(true);
        }

        //=== Posicionar Scroll
        //void PositionScroll()
        //{
        //    float contentSpacing = scroll.content.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>().spacing;
        //    float newPosX = ((250 + contentSpacing) * scrollItemIndex) + contentSpacing / 2;

        //    if (scrollItemIndex == 0) newPosX = 0;

        //    scroll.content.anchoredPosition = new Vector2(-newPosX, scroll.content.anchoredPosition.y);
        //}
        //=== Deshabilitamos los layouts
        void SetAndDisableLayouts()
        {
            containerspots.GetComponent<UnityEngine.UI.ContentSizeFitter>().enabled = false;
            containerspots.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>().enabled = false;
             
            for (int i = 0; i < _spotBase.Count; i ++)
            {
                _spotBase[i].Layout.enabled = false;
            }
        }

    }
    public void VerifyContentProgress()
    {
        Debug.Log("Verificando contenido");

         //===== TEMP ===== //

        for (int i = 0; i < lastCompleted; i++)
        {
            _spotsContent[i].CompleteContent();
        }

        _spotsContent[lastCompleted + 1].UnlockContent();

        for (int i = lastCompleted + 1; i < _spotsContent.Count; i++)
        {
            _spotsContent[i].LockContent();
        }

         //================ //



        //if (userProgressData.reportContent != null)
        //{
        //    for (int i = 0; i < userProgressData.reportContent.Count; i++)
        //    {
        //        //SpotContent content = _spotsContent.Find(card => card.data.code == userProgressData.reportContent[i].str_content_code);
        //        SpotContent content = _spotsContent.Find(card => card.data.code == userProgressData.reportContent[i].str_content_code);

        //        // Marcamos como completado la interacción
        //        if (content) content.CompleteContent();
        //    }
        //}

        if (userProgressData.reportContent.Count == _dataContent.Length && AppServerData.instance.CurrentUnitIsCompleted() == false)
        {
            UserData user = AppServerData.instance.dataCurrentUser;

            //if((user.indexMaxUnit += 1) >= user.GetWorld().units.Count)
            //{
            //    //MUNDO COMPLETADO
            //}
            //else
            //{
            //    user.indexMaxUnit++;
            //    user.SetMaxUnit(user.GetWorld().units[user.indexMaxUnit]);
            //}

            ControladorData.instance.data.user.codeMaxUnit = user.MaximunUnit.code;
            ControladorData.instance.SaveAppData();

            //cardUnitUnlocked.dataUnit = user.MaximunUnit;

            List<IEnumerator> routines = new List<IEnumerator>();

            //routines.Add(UpdateProgressUnitWorld(user.GetCurUnit().core.code, user.GetMaxUnit().core.code));
            routines.Add(RoutinesController.Action(() => GameEvents.ShowCustomDialog(cardUnitUnlocked)));

            StartCoroutine(RoutinesController.MultipleRoutines(routines.ToArray()));
        }
    }
    public override void ContentSetted()
    {
        controller.fadeScene.DOFade(0, 0.5f);
        base.ContentSetted();
    }
    public IEnumerator UpdateProgressUnitWorld(string codeCurUnit, string codeMaxUnit)
    {
        UserData dataUser = AppServerData.instance.dataCurrentUser;

        BEProgressUnitWorld _beProgressUnitWorld = new BEProgressUnitWorld();

        //_beProgressUnitWorld.id_world = dataUser.World.id;
        _beProgressUnitWorld.id_world = 1;
        _beProgressUnitWorld.id_user_account = dataUser.idAccount;
        _beProgressUnitWorld.str_current_unit_code = codeCurUnit;
        _beProgressUnitWorld.str_max_unit_code_unlocked = codeMaxUnit;

        yield return DAProgressUnitWorld.Update(DBCallbacks.UpdateProgressUnitWorld, _beProgressUnitWorld);
    }

    public void ContentCompleted(SpotContent content)
    {
        //Completamos el contenido actual
        content.CompleteContent();

        //if (content.HasReward)
        //{
        //    GameEvents.RewardContent(content.data.rewards.ToArray());
        //}

        //=== Desbloqueamos el siguiente contenido
        int indexCurrentContent = _spotsContent.IndexOf(content);
        int indexNextContent = indexCurrentContent + 1;


        if(indexCurrentContent == _spotsContent.Count - 1)
        {
            // Si es el último contenido, Terminamos la unidad
            Debug.Log("Unidad terminada");
        }
        else
        {
            // Si es el contenido existe entonces desbloqueamos el siguiente
            if (indexCurrentContent >= 0)
            {
                _spotsContent[indexNextContent].UnlockContent();
            }
        }
    }

}
