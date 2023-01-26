using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestListDataScreen : MonoBehaviour
{
    public Transform layout;

    public List<Text> childText;

    private void Awake()
    {
        childText = new List<Text>();

        for (int i = 0; i < layout.childCount; i++)
        {
            childText.Add(layout.GetChild(i).GetComponent<Text>());

            layout.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ListAllWorlds()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_WorldCore> data = new List<SO_WorldCore>(LocalData.Instance.DataWorlds.Values);

        for (int i = 0; i < data.Count; i++)
        {
            childText[i].text = $"{i + 1}. {data[i].Name}";
            childText[i].gameObject.Enable();
        }
    }

    public void ListAllTemplates()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_TemplateData> data = new List<SO_TemplateData>(LocalData.Instance.DataTemplates.Values);

        for (int i = 0; i < data.Count; i++)
        {
            childText[i].text = $"{i + 1}. {data[i].templateName}";
            childText[i].gameObject.Enable();
        }
    }

    public void ListUnitGroup()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_UnitCore> data = ServerData.Instance.dataUnits.dataValues;

        for (int i = 0; i < data.Count; i++)
        {
            childText[i].text = $"{i + 1}. {data[i].Name}";
            childText[i].gameObject.Enable();
        }
    }
    public void ListContentGroup()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_ContentCore> data = ServerData.Instance.dataContents.dataValues;

        for (int i = 0; i < data.Count; i++)
        {
            childText[i].text = $"{i + 1}. {(data[i] as SO_Content).contentName}";
            childText[i].gameObject.Enable();
        }
    }
    public void ListContentGroupTemplateCode()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_ContentCore> data = ServerData.Instance.dataContents.dataValues;

        for (int i = 0; i < data.Count; i++)
        {
            childText[i].text = $"{i + 1}. {(data[i] as SO_Content).templateCode}";
            childText[i].gameObject.Enable();
        }
    }
    public void ListContentGroupTemplateName()
    {
        foreach (Text item in childText)
        {
            item.gameObject.Disable();
        }

        layout.gameObject.Enable();

        List<SO_ContentCore> data = ServerData.Instance.dataContents.dataValues;

        for (int i = 0; i < data.Count; i++)
        {
            string templateCode = (data[i] as SO_Content).templateCode;

            childText[i].text = $"{i + 1}. {LocalData.Instance.GetDataTemplate(templateCode).templateName}";
            childText[i].gameObject.Enable();
        }
    }
}
