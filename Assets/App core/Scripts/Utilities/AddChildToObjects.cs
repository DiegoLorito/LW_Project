using UnityEngine;

public class AddChildToObjects : MonoBehaviour
{
    public string tagName;
    public GameObject childObject; 

    public void AddChild()
    {
        GameObject[] parents = GameObject.FindGameObjectsWithTag(tagName);

        for (int i = 0; i < parents.Length; i++)
        {
            Instantiate(childObject, parents[i].transform);
        }
    }
}
