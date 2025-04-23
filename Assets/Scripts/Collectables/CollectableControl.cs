using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public static event System.Action<int> OnCoinCountUpdated;

    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;

        OnCoinCountUpdated?.Invoke(coinCount);
    }
}
