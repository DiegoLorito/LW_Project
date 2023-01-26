using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Layout/Custom Vertical Layout Group", 151)]
public class CustomVerticalLayoutGroup : HorizontalOrVerticalLayoutGroup
{
    /// <summary>
    /// Called by the layout system. Also see ILayoutElement
    /// </summary>
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();
        CalcAlongAxis(0, true);
    }

    /// <summary>
    /// Called by the layout system. Also see ILayoutElement
    /// </summary>
    public override void CalculateLayoutInputVertical()
    {
        CalcAlongAxis(1, true);
    }

    /// <summary>
    /// Called by the layout system. Also see ILayoutElement
    /// </summary>
    public override void SetLayoutHorizontal()
    {
        SetChildrenAlongAxis(0, true);
    }

    /// <summary>
    /// Called by the layout system. Also see ILayoutElement
    /// </summary>
    public override void SetLayoutVertical()
    {
        SetChildrenAlongAxis(1, true);
    }

    protected override void Start()
    {
        base.Start();

        //padding.
    }

}
