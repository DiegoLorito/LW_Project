using UnityEngine;

public class Rwd_ChestManager : MonoBehaviour
{
    public static Rwd_ChestManager instance;

    public bool hasCoins;
    public int coinAmount;
    public SO_LoriItem[] rewards;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
    }
}
