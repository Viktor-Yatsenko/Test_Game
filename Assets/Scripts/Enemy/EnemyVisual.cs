using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject deathAnimation;
    public static EnemyVisual Instance {get; private set;}
    private Animator animator;
    public void Awake() 
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }
    public void EnemyAttack() {animator.SetTrigger("Attack");}
    private void Update()
    {
        //Flip enemy
        if(PlayerController.Instance.transform.position.x > transform.position.x) {spriteRenderer.flipX = true;}
        else {spriteRenderer.flipX = false;}
    } 
}
