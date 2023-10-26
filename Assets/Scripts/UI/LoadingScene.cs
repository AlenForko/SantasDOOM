using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBarFill;

    public void Start()
    {
        loadingBarFill.fillAmount = 0f;
    }

    public void LoadScene(int index)
    {
        StartCoroutine(LoadSceneAsync(index));
    }
    IEnumerator LoadSceneAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        
        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.fillAmount = progressValue;
            yield return null;
        }
    }
}
