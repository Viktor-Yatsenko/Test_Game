using UnityEngine;
public class EnemyVisual : MonoBehaviour
{
    public static EnemyVisual Instance {get; private set;}
    private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject deathAnimation;
    public void Awake() 
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }
    public void EnemyAttack() {animator.SetTrigger("Attack");}
    public void EnemyDeath() {animator.SetTrigger("Death");}
    private void Update()
    {
        //Flip enemy
        float direction = PlayerController.Instance.transform.position.x - transform.position.x;
        if (Mathf.Abs(direction) > 0.1f)
        {
            spriteRenderer.flipX = direction > 0;
        }
    } 
}
