using UnityEngine;

public class SpotContent : SpotBase
{
    [HideInInspector] public SO_Content data;
    [HideInInspector] public SO_UnitCore dataUnitCore;

    [Header("Spot Icon")]
    [SerializeField] private UnityEngine.UI.Image icon;
    [SerializeField] private UnityEngine.UI.Image background;
    [SerializeField] private UnityEngine.UI.Image type;

    [SerializeField] private GameObject star;
    [SerializeField] private GameObject padlock;

    [Header("Button")]
    public System.Action onClick;
    private Material grayMaterial;

    
    public bool HasReward { get { return false; } }

    private void Awake()
    {
        Layout   = GetComponent<UnityEngine.UI.VerticalLayoutGroup>();

        star.SetActive(false);
        padlock.SetActive(false);

        grayMaterial = Instantiate(icon.material);
        icon.material = grayMaterial;
    }

    public override void SetData()
    {
        //icon.sprite = data.Icon; 
        background.color = dataUnitCore.colorMiddleground;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { onClick?.Invoke(); });
    }

    //============== TEMP ==============//

    public void LockContent()
    {
        padlock.SetActive(true);
        icon.SetAlpha(0.5f);
        grayMaterial.SetFloat("_GrayscaleAmount", 1);
        background.color = ConstantsUI.colorGray;

        star.SetActive(false);
    }

    public void UnlockContent()
    {
        padlock.SetActive(false);
        icon.SetAlpha(1.0f);
        grayMaterial.SetFloat("_GrayscaleAmount", 0);
        background.color = dataUnitCore.colorMiddleground;

        star.SetActive(false);
    }

    public void CompleteContent()
    {
        UnlockContent();
        star.SetActive(true);
    }
    public void DOUnlockContent()
    {

    }

    //==================================//
}
