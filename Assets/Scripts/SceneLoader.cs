using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Reload Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
