using UnityEngine;
public class PlayerVisual : MonoBehaviour
{
    public static PlayerVisual Instance {get; private set;}
    public Animator animator;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;
    //Audio
    [Header("Audio attack")]
    [SerializeField] private AudioClip missSound;
    [SerializeField] private AudioClip hitSound;
    private AudioSource audioSource;
    private bool hitEnemy = false;
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void SpendStaminaOnAttack() //Animation event
    {
        PlayerUIController.Instance.TakeStamina(PlayerController.Instance.staminaCostPerAttack);
    }
    //Sounds
    public void StartAttackSound(bool _hitEnemy)
    {
        hitEnemy = _hitEnemy;
        animator.SetTrigger("Attack");
    }
    public void PlayAttackSound()
    {
        if(hitEnemy) {audioSource.PlayOneShot(hitSound);}
        else {audioSource.PlayOneShot(missSound);}
    }
    //Animation
    public void Death() {animator.SetTrigger("Death");}
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