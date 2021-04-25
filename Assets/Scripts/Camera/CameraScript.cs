using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float Offset;
    [SerializeField] private int Framerate;
    [SerializeField] private GameObject PauseScene;
    [SerializeField] private Vector2 Min, Max;

    private Vector3 vec;

    void Awake()
    {
        Application.targetFrameRate = Framerate;
        QualitySettings.vSyncCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Pause();
            var target = Target.position;
            if (Target.position.x >= Max.x) target.x = Max.x;
            if (Target.position.y >= Max.y) target.y = Max.y;
            if (Target.position.x <= Min.x) target.x = Min.x;
            if (Target.position.y <= Min.y) target.y = Min.y;
            target.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref vec, Offset);
        }
    }

    public void Pause()
    {
        if (!SceneLoader.isLoading)
        {
            Time.timeScale = 0;
            PauseScene.SetActive(true);
        }
    }
}
