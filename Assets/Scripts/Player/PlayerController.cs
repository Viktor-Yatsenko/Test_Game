using System.Runtime.CompilerServices;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    public float movingSpeed;
    private Rigidbody2D rb;
    private float minMovingSpeed = 0.1f;
    private bool Running = false;
    //private bool AttackBool = false;
    //private int AttackBool = 0;
    //private bool Attack = false;
    private bool isHoldingAttack;
    //private string Attack;
    private string IsAttacking;
    //private int AttackDamage = 5;
    
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Однократный удар при клике
        {
            Attack();
            //Attack = "Attack";
        }

        if (Input.GetMouseButton(0)) // Повторяющаяся атака при удержании
        {
            if (!isHoldingAttack)
            {
                isHoldingAttack = true;
                IsAttacking = "IsAttacking";
                //animator.SetBool("IsAttacking", true);
            }
        }
        else if (isHoldingAttack) // Остановка повторной атаки при отпускании
        {
            isHoldingAttack = false;
            //animator.SetBool("IsAttacking", false);
        }

        // if (Input.GetMouseButton(0))
        // {
        //     //Attack = 1;
        //     AttackBool = true;
        //     Debug.Log("Mouse Down");
        //     //Attack = 1;
        // }
        // else
        // {
        //     //Attack = 0;
        //     AttackBool = false;
        //     //Attack = 0;
        // }



        // if (Input.GetMouseButtonDown(0))
        // {
        //     AttackBool = true;
        //     Debug.Log("Mouse Down");
        //     //AttackBool = 1;
        // }
        // else
        // {
        //     //AttackBool = 0;
        //     AttackBool = false;
        // }
        // if (Input.GetMouseButtonUp(0))
        // {
        //     //AttackBool = true;
        //     Debug.Log("Mouse Down");
        //     AttackBool = true;
        // }
        // else
        // {
        //     AttackBool = false;
        //     //AttackBool = false;
        // }
    }
    // public bool isAttackBool()
    // {
    //     return isAttack;
    // }
    public string Attack()
    {
        return "Attack";
    }
    // public bool isAttack()
    // {
    //     return Attack;
    // }
    // public bool isAttackBool()
    // {
    //     return AttackBool;
    // }
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerVisual.Instance.FlipPlayer(-1);
            inputVector.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerVisual.Instance.FlipPlayer(1);
            inputVector.x = 1f;
        }
        rb.MovePosition(rb.position + inputVector.normalized * movingSpeed * Time.fixedDeltaTime);
        //Player is running ?
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            Running = true;
        }
        else
        {
            Running = false;
        }
    }
    public bool isRunning()
    {
        return Running;
    }
}
