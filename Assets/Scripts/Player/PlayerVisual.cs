using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance {get; private set;}
    private Animator animator;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    //private const string IS_ATTACK1BOOL = "IsAttack1Bool";
    //private const string IS_ATTACK1TEST = "Test";
    //private const string TEST = "Test";
    //private static readonly int AttackHash = Animator.StringToHash("Attack");
       ///private bool isHoldingAttack;
    //private const string IS_ATTACK1INT = "IsAttack1Int";
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, PlayerController.Instance.isRunning());
        //animator.SetInteger(IS_ATTACK1INT, PlayerController.Instance.isAttack());
        //animator.SetBool(IS_ATTACK1BOOL, PlayerController.Instance.isAttackBool());
        animator.SetTrigger(PlayerController.Instance.Attack());

            // if (Input.GetMouseButtonDown(0)) // Однократный удар при клике
            // {
            //     animator.SetTrigger("Attack");
            // }

        // if (Input.GetMouseButton(0)) // Повторяющаяся атака при удержании
        // {
        //     if (!isHoldingAttack)
        //     {
        //         isHoldingAttack = true;
        //         animator.SetBool("IsAttacking", true);
        //     }
        // }
        // else if (isHoldingAttack) // Остановка повторной атаки при отпускании
        // {
        //     isHoldingAttack = false;
        //     animator.SetBool("IsAttacking", false);
        // }
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