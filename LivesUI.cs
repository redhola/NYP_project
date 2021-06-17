using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    public Text livesText;

    // Update is called once per frame
    void Update() // Optimal yolu bu degil, o yuzden sonrasýnda coroutine'e cevrilecek.
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}
