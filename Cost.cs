using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Cost : MonoBehaviour
{

    public Text CostText;
    public int cost;

    void Update()
    {
        CostText.text = cost.ToString() + " G";
    }
}
