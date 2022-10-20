using UnityEngine;

public class TestAvatarScreen : MonoBehaviour
{
    public Transform layoutAvatars;
    public GameObject prefAvatarCard;

    public void LoadAllAvatars()
    {
        if(LocalData.Instance == null)
        {
            Debug.Log("No existe un LOCALDATA");
            return;
        }

        layoutAvatars.gameObject.SetActive(true);

        int avatarsCount = LocalData.Instance.DataAvatars.Count;
        int childCount = layoutAvatars.childCount;

        if(avatarsCount > childCount)
        {
            int difference = avatarsCount - childCount;

            for (int i = 0; i < difference; i++)
            {
                Instantiate(prefAvatarCard, layoutAvatars);
            }
        }

        for (int i = 0; i < avatarsCount; i++)
        {
            layoutAvatars.GetChild(i).GetComponent<TestAvatarCard>().SetData(LocalData.Instance.DataAvatarsArray[i]);
        }

        //int cardindex = 0;

        //foreach (SO_Avatar item in LocalData.Instance.DataAvatars.Values)
        //{
        //    layoutAvatars.GetChild(cardindex).GetComponent<TestAvatarCard>().SetData(item);

        //    cardindex++;
        //}
    }
}
