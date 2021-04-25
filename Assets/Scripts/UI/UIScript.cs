using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject loadingScene;
    [SerializeField] private GameObject pauseMenu;

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string scene)
    {
        SceneLoader sc=SceneLoader.GetSceneLoader();
        if (Time.timeScale < 1) Time.timeScale = 1;
        if (loadingScene != null) loadingScene.SetActive(true);
        StartCoroutine(sc.LoadAsync(scene));
    }

    public void LoadSceneSync(string scene)
    {
        SceneLoader sc =SceneLoader.GetSceneLoader();
        if (Time.timeScale < 1) Time.timeScale = 1;
        if (loadingScene != null) loadingScene.SetActive(true);
        StartCoroutine(sc.Load(scene));
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
