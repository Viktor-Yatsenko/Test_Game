using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance {get; private set;}
    private Animator animator;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    //private const string IS_ATTACK1BOOL = "IsAttack1Bool";
    private const string IS_ATTACK1BOOL = "IsAttack1Bool";
    private const string IS_ATTACK1INT = "IsAttack1Int";
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, PlayerController.Instance.isRunning());
        animator.SetInteger(IS_ATTACK1INT, PlayerController.Instance.isAttack());
        animator.SetBool(IS_ATTACK1BOOL, PlayerController.Instance.isAttackBool());
        //animator.SetBool(IS_ATTACK1BOOL, PlayerController.Instance.isAttackBool());
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