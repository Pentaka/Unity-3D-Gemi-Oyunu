using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject panel;
    public Slider slider;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }
    private void Update()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1f;
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        panel.SetActive(false);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress /.9f);

            slider.value = progress;

            Debug.Log(progress);

            yield return null;
            
        }
    }
}
   
