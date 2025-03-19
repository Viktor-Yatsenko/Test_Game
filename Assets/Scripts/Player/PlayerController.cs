using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    public float movingSpeed;
    private Rigidbody2D rb;
    private float minMovingSpeed = 0.1f;
    private bool Running = false;
    private bool AttackBool = false;
    //private int AttackBool = 0;
    private int Attack = 0;
    //private int AttackDamage = 5;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack = 1;
            //AttackBool = true;
            Debug.Log("Mouse Down");
            //Attack = 1;
        }
        else
        {
            //Attack = 0;
            //AttackBool = false;
            Attack = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //AttackBool = true;
            Debug.Log("Mouse Down");
            AttackBool = true;
        }
        else
        {
            AttackBool = false;
            //AttackBool = false;
        }
    }
    public int isAttack()
    {
        return Attack;
    }
    public bool isAttackBool()
    {
        return AttackBool;
    }
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
