using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EndScript : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject LoadingScene;
    [SerializeField] private Light2D Light;
    private bool canEnd = false;
    private int initialCount=0;

    void Start()
    {
        initialCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (initialCount == 0)
        {
            canEnd = true;
            Light.color = new Color(0.6f, 0.6f, 0.6f);
        }
        }

    void FixedUpdate()
    {
        if (!canEnd)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            var count = 0;
            if (initialCount != enemies.Length)
            {
                initialCount = enemies.Length;
                foreach (var e in enemies)
                {
                    if (e.GetComponent<EnemyAI>().MustDie()) count++;
                }
                if (count > 0)
                {
                    Light.color = new Color(0.1f, 0.1f, 0.2f);
                    canEnd = false;
                }
                else
                {
                    Light.color = new Color(0.6f, 0.6f, 0.6f);
                    canEnd = true;
                }
            }
        }
    }

    public void NextScene()
    {
        if(canEnd)
        StartCoroutine(SceneLoader.GetSceneLoader().LoadWithTransitionScene(SceneName,LoadingScene));
    }
}
