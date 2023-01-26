using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAvatarBasic : InputImageBasic
{
    public UnityEngine.UI.Image indicator;

    public override void ClearInput()
    {
        indicator.sprite = options[0].icon.sprite;
        base.ClearInput();
    }

}
