using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
    public void ChangeName(GameObject ogg)
    {
        ogg.SetActive(true);
        ogg.GetComponentInChildren<Text>().text = "Your actual name will be made unusable, click here if you are sure,otherwise click outside";
    }
    public void TrueChangeName(InputField nickname)
    {
        nickname.interactable = true;
        gameObject.SetActive(false);
    }
    public void SetFalse(GameObject game)
    {
        game.SetActive(false);
    }
}
