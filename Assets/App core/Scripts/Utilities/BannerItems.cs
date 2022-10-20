using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BannerItems : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Material material;

    private int current;
    private int amount;

    private Dictionary<int, Image> dictionary;

    public void Initialize(int amount)
    {
        dictionary = new Dictionary<int, Image>();

        this.amount = amount;

        for (int i = 0; i < amount; i++)
        {
            Image icon = container.GetChild(i).GetComponent<Image>();

            icon.SetAlpha(0.5f);
            icon.material = Instantiate(material);
            icon.material.SetFloat("_GrayscaleAmount", 1);
            icon.gameObject.Enable();

            dictionary.Add(i, icon);
        }
    }

    public void SetItems(Sprite iconItem)
    {
        for (int i = 0; i < amount; i++)
        {
            Image icon = container.GetChild(i).GetComponent<Image>();

            icon.SetAlpha(0.5f);
            icon.sprite = iconItem;
            icon.material = Instantiate(material);
            icon.material.SetFloat("_GrayscaleAmount", 1);
        }
    }

    public void CollectItem()
    {
        dictionary[current].DOFade(1, 0.25f);
        dictionary[current].material.DOFloat(0, "_GrayscaleAmount", 0.25f);

        if(current == (amount - 1))
        {
            current = 0;
        }
        else
        {
            current++;
        }
    }
}
