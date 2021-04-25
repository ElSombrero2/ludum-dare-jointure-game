using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{

    [SerializeField] private TargetJoint2D Joint;
    [SerializeField] private GameObject Player;
    [SerializeField,Range(0.0f,1.0f)] private float Offset;
    [SerializeField] private Rigidbody2D Body;
    [SerializeField,Range(0.0f,1.0f)] private float Radius;
    [SerializeField] private LayerMask Mask;
    [SerializeField] private CircleCollider2D Collider2D;
    [SerializeField] private GameObject Explosion;

    private Vector2 vec;

    void FixedUpdate()
    {
        Joint.target = Vector2.SmoothDamp(transform.position, Player.transform.position, ref vec, Offset);
    }

    public Rigidbody2D GetBody()
    {
        return Body;
    }

    public bool CanAttack()
    {
        return Physics2D.OverlapCircle(transform.position, Radius,Mask);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
            enemy.TakeDamage();
        }
        var instance = Instantiate(Explosion, collision.gameObject.transform.position,collision.gameObject.transform.rotation);
        Destroy(instance, 0.5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }

    public void ChangeTag(string name)
    {
        gameObject.layer = LayerMask.NameToLayer(name);
    }

    public bool IsDeactivate()
    {
        return gameObject.layer== LayerMask.NameToLayer("Deactivate");
    }
}
