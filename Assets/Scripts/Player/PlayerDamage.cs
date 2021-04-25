using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Sprite;
    [SerializeField] private PlayerLight Light;
    [SerializeField] private float InvincibleTimeLapse;
    [SerializeField] private float BlinkDuration;

    private bool isInvincible;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            Light.LightDown();
            isInvincible = true;
            StartCoroutine(Invincibility());
            StartCoroutine(BlinkDamage());
        }
    }

    private IEnumerator BlinkDamage()
    {
        while (isInvincible)
        {
            Sprite.color=new Color(1,1,1,0);
            yield return new WaitForSeconds(BlinkDuration);
            Sprite.color=new Color(1,1,1,1);
            yield return new WaitForSeconds(BlinkDuration);
        }
    }

    private IEnumerator Invincibility()
    {
        yield return new WaitForSeconds(InvincibleTimeLapse);
        isInvincible = false;
    }
}
