using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        //load to game scene when start game button is clicked
        SceneManager.LoadScene(1);
    }
}
