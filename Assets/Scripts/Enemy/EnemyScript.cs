using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private GameObject FollowObject;
    [SerializeField]private GameObject Center;
    private bool canMove=true;
    private bool playerIsHere = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerSprite"))
        {
            FollowObject = collision.gameObject;
            canMove = true;
            playerIsHere = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerSprite"))
        {
            playerIsHere = false;
            FollowObject = null;
        }
    }

    public static explicit operator EnemyScript(GameObject v)
    {
        throw new NotImplementedException();
    }

    public Vector3 GetFollowObject()
    {
        var target = Center.transform.position;
        if (FollowObject != null)
        {
            return FollowObject.transform.position;
        }
        return target;
    }

    public bool CanMove()
    {
        return canMove;
    }

    public void StopMove()
    {
        canMove = false;
    }

    public bool PlayerIsOn()
    {
        return playerIsHere;
    }

}
