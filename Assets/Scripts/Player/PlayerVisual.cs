using UnityEngine;
public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance;
    public Animator animator;
    private bool isFacingRight = true;
    private bool isDead = false;
    private SpriteRenderer spriteRenderer;
    
    
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SpendStaminaOnAttack() //Animation event
    {
        PlayerUIController.Instance.TakeStamina(PlayerController.Instance.staminaCostPerAttack);
    }

    //Animation
    public void TriggerAttack() {animator.SetTrigger("Attack");}
    public void isAttack(bool attackBool) {animator.SetBool("IsAttacking", attackBool);}
    public void isRunning(bool Running) {animator.SetBool("IsRunning", Running);}
    public void Death()
    {
        if(isDead) return;
        isDead = true;
        animator.SetTrigger("Death");
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