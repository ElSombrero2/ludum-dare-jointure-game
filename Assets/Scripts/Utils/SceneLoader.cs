using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{

    private static SceneLoader instance;
    public static bool isLoading=false;

    private SceneLoader()
    {

    }

    public static SceneLoader GetSceneLoader()
    {
        if(instance==null)instance=new SceneLoader();
        return instance;
    }

    public IEnumerator Load(string scene)
    {
        isLoading = true;
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
        isLoading = true;
    }

    public IEnumerator LoadAsync(string scene)
    {
        isLoading = true;
        yield return new WaitForSecondsRealtime(3);
        var op = SceneManager.LoadSceneAsync(scene);
        op.completed += CompleteFunction;
    }

    public IEnumerator LoadWithTransitionSceneAsync(string scene,GameObject transitionScene)
    {
        isLoading = true;
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        var op = SceneManager.LoadSceneAsync(scene);
        op.completed += CompleteFunction;
    }

    private void CompleteFunction(AsyncOperation obj)
    {
        isLoading = false;
    }

    public IEnumerator LoadWithTransitionScene(string scene, GameObject transitionScene)
    {
        isLoading = true;
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
        isLoading = false;
    }

    public IEnumerator Reload()
    {
        isLoading = true;
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isLoading = false;
    }

    public IEnumerator ReloadAsync()
    {
        isLoading = true;
        yield return new WaitForSecondsRealtime(3);
        var op=SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        op.completed += CompleteFunction;
    }

    public IEnumerator ReloadWithTransition(GameObject transitionScene)
    {
        isLoading = true;
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isLoading = false;
    }

    public IEnumerator ReloadWithTransitionAsync(GameObject transitionScene)
    {
        isLoading = true;
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        var op=SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        op.completed += CompleteFunction;
    }
}
