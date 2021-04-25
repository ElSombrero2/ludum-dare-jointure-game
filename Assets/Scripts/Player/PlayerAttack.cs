using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Lance LanceObject;
    [SerializeField, Range(0.0f, 100.0f)] private float AttackForce;
    [SerializeField] private PlayerController Controller;
    private bool isAttack;


    // Update is called once per frame
    void Update()
    {
        isAttack = Input.GetKeyDown(KeyCode.V) && LanceObject.CanAttack();
    }

    void FixedUpdate()
    {
        if (isAttack)
        {
            LanceObject.ChangeTag("Weapon");
            LanceObject.GetBody().velocity = new Vector2(AttackForce * 10 * Controller.GetDirection(), LanceObject.GetBody().velocity.y);
        }
        else
        {
            if(!LanceObject.IsDeactivate())LanceObject.ChangeTag("Deactivate");
        }
    }
}
