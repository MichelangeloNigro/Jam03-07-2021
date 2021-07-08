using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizedName : MonoBehaviour
{
    [SerializeField] InputField nickname;
    [SerializeField] Button play;
    [SerializeField] Online list;

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("Name"));
        if (PlayerPrefs.GetString("Name")!="")
        {
            nickname.text = PlayerPrefs.GetString("Name");
            nickname.interactable = false;
            play.interactable = true;
           
        }
    }
    public void Name(string name)
    {
        PlayerPrefs.SetString("Name", name);
        foreach (var item in list.punteggi)
        {
            if (name == item.playerName)
            {
                nickname.text = "Invalide name";
                play.interactable = false;
                return;
            }

        }
        play.interactable = true;
        Debug.Log(PlayerPrefs.GetString("Name"));
    }
}
