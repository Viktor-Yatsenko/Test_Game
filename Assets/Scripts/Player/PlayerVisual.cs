using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance {get; private set;}
    private Animator animator;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    private const string IS_ATTACK1 = "IsAttack1";
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, PlayerController.Instance.isRunning());
        animator.SetBool(IS_ATTACK1, PlayerController.Instance.isAttack());
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