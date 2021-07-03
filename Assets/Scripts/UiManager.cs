using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Text point;
    public int points;

    private void Start()
    {
        point.text = "Punteggio: " + points.ToString();

    }

    public void Update() {
        point.text = "Punteggio: " + points.ToString();
    }

}
