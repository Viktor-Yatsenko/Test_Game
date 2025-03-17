using UnityEngine;


public class Player : MonoBehaviour
{
    PlayerVisual ClassPlayerVisual;
    public static Player Instance {get; private set;}

    public float movingSpeed;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float minMovingSpeed = 0.1f;
    private bool Running = false;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
        }
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
            //ClassPlayerVisual.FlipPlayer(-1);
            FlipPlayer(-1);
            inputVector.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //ClassPlayerVisual.FlipPlayer(1);
            FlipPlayer(1);
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
        //return RunningForClassPlayerVisual;
        return Running;
        //return ClassPlayerVisual.Running;
    }
    public void FlipPlayer(float Horizontal)
    {
        if(isFacingRight && Horizontal < 0f || isFacingRight == false && Horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            var localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
