using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance {get; private set;}
    public float movingSpeed;
    public int hp = 100;
    [SerializeField] private IfEndGame ifEndGame;
    private Rigidbody2D rb;
    private float minMovingSpeed = 0.1f;
    private bool Running = false;
    private bool attackBool;
    private bool attackTriggered;
    private Collision2D collision;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {attackTriggered = true;}
        if (Input.GetMouseButton(0)) {if (!attackBool) {attackBool = true;}}
        else if (attackBool) {attackBool = false;}
        Debug.Log(hp);
    }
    void FixedUpdate()
    {
        Vector2 inputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) {inputVector.y = 1f;}
        if (Input.GetKey(KeyCode.A)) {PlayerVisual.Instance.FlipPlayer(-1); inputVector.x = -1f;}
        if (Input.GetKey(KeyCode.S)) {inputVector.y = -1f;}
        if (Input.GetKey(KeyCode.D)) {PlayerVisual.Instance.FlipPlayer(1); inputVector.x = 1f;}
        rb.MovePosition(rb.position + inputVector.normalized * movingSpeed * Time.fixedDeltaTime);
        //Player is running ?
        if (Mathf.Abs(inputVector.x) > minMovingSpeed || 
        Mathf.Abs(inputVector.y) > minMovingSpeed) {Running = true;}
        else {Running = false;}
        //Call animations
        PlayerVisual.Instance.isRunning(Running);
        PlayerVisual.Instance.isAttack(attackBool);
        if (attackTriggered)
        {
            PlayerVisual.Instance.TriggerAttack();
            attackTriggered = false;
        }
        if (SliderController.Instance.currentHealth <=0)
        {
            ifEndGame.IsDeath();
        }
    }
}