using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizedName : MonoBehaviour
{
    [SerializeField] InputField nickname;

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("Name"));
        nickname.text= PlayerPrefs.GetString("Name");
    }
    public void Name(string name)
    {
        PlayerPrefs.SetString("Name", name);
        Debug.Log(PlayerPrefs.GetString("Name"));
    }
}
