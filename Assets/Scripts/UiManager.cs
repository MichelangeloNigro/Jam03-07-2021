using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public Text point;
    public Text highScoreText;
    public Text highScoreTextDeath;
    public int points;
    public Slider volume;
    public int highScore;
    public Canvas DeathCanvas;
    public AudioMixer mixer;


    private void Start()
    {
        volume.value = PlayerPrefs.GetFloat("Volume");
        points = 0;
        highScore = PlayerPrefs.GetInt("Highscore");
        DeathCanvas.enabled = false;
        point.text = "Punteggio: " + points.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
        highScoreTextDeath.text = "Highscore: " + highScore.ToString();

    }

    public void Update() {
        point.text = "Punteggio: " + points.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
        highScoreTextDeath.text = "Highscore: " + highScore.ToString();
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }


    public void Restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void changeCanvas(GameObject canvas)
    {
        canvas.SetActive(canvas.activeSelf);
    }

    public void Volume(float value)
    {
        mixer.SetFloat("Volume", value);
        PlayerPrefs.SetFloat("Volume", value);
    }

}
