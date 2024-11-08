using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartGame()
    {
        //save the name form input field
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.Save();
        //load game scene to start game
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}