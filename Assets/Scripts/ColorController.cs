using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ColorController : MonoBehaviour
{
    public Material greenMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;

    public TextMeshProUGUI winningColorText;

    //property for current winning material
    public Material CurrentWinningMaterial { get; private set; }  

    void Start()
    {
        StartCoroutine(ChangeWinningColor());
    }

    // function to change winning color randomly every 15 seconds 
    IEnumerator ChangeWinningColor()
    {
        while (true)
        {
            int colorIndex = Random.Range(0, 3);
            switch (colorIndex)
            {
                //in case the winning color is green
                case 0:
                    CurrentWinningMaterial = greenMaterial;
                    winningColorText.text = "Winning Color: Green";
                    winningColorText.color = Color.green;
                    break;
                //in case the winning color is blue
                case 1:
                    CurrentWinningMaterial = blueMaterial;
                    winningColorText.text = "Winning Color: Blue";
                    winningColorText.color = Color.blue;
                    break;
                //in case the winning color is yellow
                case 2:
                    CurrentWinningMaterial = yellowMaterial;
                    winningColorText.text = "Winning Color: Yellow";
                    winningColorText.color = Color.yellow;
                    break;
            }
            yield return new WaitForSeconds(15f);
        }
    }
}
