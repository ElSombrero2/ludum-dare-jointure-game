using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static readonly Color GREEN = new Color(1, 2, 1);
    public static readonly Color RED = new Color(2, 1, 1);
    public static readonly Color BLUE = new Color(1, 1, 2);


    [SerializeField,Range(0.0f,10.0f)] private float Speed;
    [SerializeField] private Rigidbody2D Body;
    [SerializeField] private Animator PlayerAnimator;

    [SerializeField, Range(0.0f, 10.0f)] private float JumpSpeed;

    [SerializeField] private Transform Feet;
    [SerializeField,Range(0.0f,1.0f)] private float Radius;
    [SerializeField] private LayerMask Mask;

    [SerializeField] private Transform DyingPoint;
    [SerializeField] private PlayerLight LightControl;

    private bool isJump;
    private float axisX;
    private float dir=1;

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxis("Horizontal");
        PlayerAnimator.SetFloat("Speed",axisX);
        isJump = CanJump() && Input.GetKeyDown(KeyCode.Space);
        if (axisX <= -0.01) dir = -1;
        if (axisX >= 0.01) dir = 1;
        if(IsDead())LightControl.Die();
    }

    public bool CanJump()
    {
        return Physics2D.OverlapCircle(Feet.position, Radius, Mask);
    }

    void FixedUpdate()
    {
        var target=new Vector2(axisX*Speed*100*Time.fixedDeltaTime,Body.velocity.y);
        if (isJump) target.y = JumpSpeed * 100 * Time.fixedDeltaTime;
        Body.velocity = target;
    }

    public float GetDirection()
    {
        return dir;
    }

    void OnDrawGizmos()
    {
        Gizmos.color=Color.green;
        Gizmos.DrawWireSphere(Feet.position,Radius);
    }

    public bool IsDead()
    {
        return transform.position.y<=DyingPoint.position.y;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("End"))
        {
            obj.gameObject.GetComponent<EndScript>().NextScene();
        }
    }

}
