using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Body;

    void OnCollisionEnter2D(Collision2D coll)
    {
        var bonus=coll.collider.GetComponent<BonusScript>();
        var damage = coll.collider.GetComponent<PlayerDamage>();
        if (bonus&&damage)
        {
             TakeDamage(gameObject.CompareTag(bonus.GetColor()),damage);
             if (!gameObject.CompareTag(bonus.GetColor()))
             {
                 Body.constraints = RigidbodyConstraints2D.FreezePositionX;
                 Body.freezeRotation = true;
             }
             else Body.constraints=RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void TakeDamage(bool sameColor, PlayerDamage damage)
    {
        if(!sameColor)damage.TakeDamage();
    }
}
