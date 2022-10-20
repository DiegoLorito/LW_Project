using UnityEngine;

[System.Serializable]
public class CardUnitResumeData
{
    [HideInInspector] public int id;
    [HideInInspector] public int index;

    [Header("Card")]
    public Sprite thumbnail;
    public Sprite background;

    public Color colorBackground;

    public System.DateTime date;
    public string name;
    public string number;
    public float totalProgress;
    public float currenProgress;

    //public CardUnitResumeData( data = null)
    //{
    //    if (data == null) return;

    //    this.id = data.id_unit;
    //    this.index = data.int_unit_index;
    //    this.date = data.dte_unit_creation_date;
    //    this.name = data.str_unit_name;
    //    this.number = data.int_unit_index.ToString();
    //}
}
