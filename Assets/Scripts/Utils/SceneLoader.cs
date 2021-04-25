using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{

    private static SceneLoader instance;

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
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
    }

    public IEnumerator LoadAsync(string scene)
    {
        yield return new WaitForSecondsRealtime(3);
        var op = SceneManager.LoadSceneAsync(scene);
    }

    public IEnumerator LoadWithTransitionSceneAsync(string scene,GameObject transitionScene)
    {
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        var op = SceneManager.LoadSceneAsync(scene);
    }

    public IEnumerator LoadWithTransitionScene(string scene, GameObject transitionScene)
    {
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator ReloadAsync()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public IEnumerator ReloadWithTransition(GameObject transitionScene)
    {
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator ReloadWithTransitionAsync(GameObject transitionScene)
    {
        transitionScene.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
