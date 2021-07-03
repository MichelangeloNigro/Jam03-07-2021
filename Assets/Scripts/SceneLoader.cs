using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
