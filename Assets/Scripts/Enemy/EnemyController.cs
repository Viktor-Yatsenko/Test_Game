using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject deathAnimation;
    public static EnemyController Instance {get; private set;}
    private Vector2 direction;
    private float EnemyDamage = 25f;
    void Update()
    {

    }
    public void FixedUpdate()
    {
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EnemyVisual.Instance.EnemyAttack();
            PlayerController.Instance.HP = PlayerController.Instance.HP - EnemyDamage;
            //if (PlayerController.Instance.HP <= 0) {Destroy(gameObject, PlayerVisual.Instance.animator.GetAnimatorTransitionInfo(0));}
            Destroy(gameObject);
            Instantiate(deathAnimation, transform.position, transform.rotation);
        }
    }
}