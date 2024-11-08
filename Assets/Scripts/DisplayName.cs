using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayPlayerName : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        nameText.text = playerName;
    }
}
