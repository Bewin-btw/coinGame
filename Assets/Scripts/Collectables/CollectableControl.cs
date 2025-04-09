using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;

    void Update()
    {
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
