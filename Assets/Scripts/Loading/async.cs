using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class async : MonoBehaviour
{
    [SerializeField] private Image Image;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            Debug.Log("LOAD SCENE: Progress: " + operation.progress);
            Debug.Log(operation.allowSceneActivation);
            Image.fillAmount = operation.progress;
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
