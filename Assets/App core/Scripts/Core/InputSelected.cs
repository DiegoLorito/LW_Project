using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputSelected : MonoBehaviour, ISelectHandler
{
    private InputField input;

    private void Awake()
    {
        input = GetComponent<InputField>();
        //input.onEndEdit.AddListener(delegate { GameEvents.KeyboardClosed(); input.DeactivateInputField();  });
    }

    public void OnSelect(BaseEventData eventData)
    {
        //#if UNITY_EDITOR
        //return;
        //#endif
        input.Select();
        input.ActivateInputField();
        //input.isFocused = true;
        
        //GameEvents.KeyboardOpened();
    }
}



