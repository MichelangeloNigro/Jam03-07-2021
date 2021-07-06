using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    bool tutorialActivate;
    public GameObject showTutorial;

    private void Start()
    {
        showTutorial.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (tutorialActivate) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Time.timeScale = 1f;
                showTutorial.gameObject.SetActive(false);
                tutorialActivate = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()) {
            tutorialActivate = true;
            Time.timeScale = 0;
            showTutorial.SetActive(true);
            

        }
    }


}





/*
    [SerializeField]List<Sprite> tutorialImage;
    [SerializeField] List<string> tutorialTexts;
    int index = 0;
    public Text tutorialText;
    public Image showImage;
    public Button endTutorial;
    public Button increseIndex;
    public Button decreaseIndex;
    
    void Start()
    {
        Time.timeScale = 0;
        showImage.sprite = tutorialImage[index];
        tutorialText.text = tutorialTexts[index];
        endTutorial.gameObject.SetActive(false);
        increseIndex.gameObject.SetActive(true);
        decreaseIndex.gameObject.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void IncreseIndex() {

        index++;
        showImage.sprite = tutorialImage[index];
        tutorialText.text = tutorialTexts[index];
        if (index >= tutorialImage.Count - 1)
        {
            endTutorial.gameObject.SetActive(true);
            increseIndex.gameObject.SetActive(false);
            decreaseIndex.gameObject.SetActive(true);
        }
        else
        {
            endTutorial.gameObject.SetActive(false);
            increseIndex.gameObject.SetActive(true);
            decreaseIndex.gameObject.SetActive(true);
        }
    }

    public void DecreaseIndex() {
        index--;
        showImage.sprite = tutorialImage[index];
        tutorialText.text = tutorialTexts[index];
        if (index < 1)
        {
            decreaseIndex.gameObject.SetActive(false);
            endTutorial.gameObject.SetActive(false);
            increseIndex.gameObject.SetActive(true);
        }
        else {
            decreaseIndex.gameObject.SetActive(true);
            endTutorial.gameObject.SetActive(false);
            increseIndex.gameObject.SetActive(true);
        }
    }



    public void FinishTutorial() {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
*/
