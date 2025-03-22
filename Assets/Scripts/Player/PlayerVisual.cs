using UnityEngine;
public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance {get; private set;}
    private Animator animator;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TriggerAttack() {animator.SetTrigger("Attack");}
    public void isAttack(bool attackBool) {animator.SetBool("IsAttacking", attackBool);}
    public void isRunning(bool Running) {animator.SetBool("IsRunning", Running);}
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