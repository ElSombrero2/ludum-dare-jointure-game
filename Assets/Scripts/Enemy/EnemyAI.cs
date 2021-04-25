using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyScript Script;
    [SerializeField] private Rigidbody2D Body;
    [SerializeField, Range(0, 100)] private float Speed;
    [SerializeField] private Animator EnemyAnimator;
    [SerializeField] private Light2D Light;
    [SerializeField] private GameObject Parent;
    [SerializeField] private bool mustDie;
    [SerializeField] private AudioSource Audio;
    private void FixedUpdate()
    {
        var follow = Script.GetFollowObject();
        var dir = follow.x - transform.position.x;
        if (dir < 0) dir = -1;
        else dir = 1;
        if (!Script.CanMove()) dir = 0;
        Body.velocity = new Vector3(Speed * Time.deltaTime * dir * 4, Body.velocity.y);
        EnemyAnimator.SetFloat("Speed", Mathf.Abs(Body.velocity.x));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Center") && !Script.PlayerIsOn())
        {
            Script.StopMove();
        }
    }

    public void TakeDamage()
    {
        Audio.Play();
        Light.intensity -= 0.2f;
        if (Light.intensity <= 0) Destroy(Parent);
    }

    public bool MustDie()
    {
        return this.mustDie;
    }

}
