using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


// To organise Scripts when "adding Component" - 'search'
[AddComponentMenu("Scene Management/Load Scene With Bar")]
public class LoadingLevel : MonoBehaviour
{
    // Headers organise variables into display
    [Header("Objects")]
    public GameObject LoadingScreen;
    [Tooltip("This is the bar that will be filling up the display")]
    public Image progressBar;
    [Space]

    public Text progressText;


    IEnumerator LoadingAscycrounously(int sceneIndex)
    {

        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.fillAmount = progress;

            progressText.text = Mathf.Round(progress * 100) + "%";

            yield return null;
        }

        yield return null;
    }

    public void LoadLevel(int sceneIndex)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadingAscycrounously(sceneIndex));
        Time.timeScale = 1;
    }
    public void LoadLevelSeparate(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
