using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject deathAnimation;
    public static EnemyController Instance {get; private set;}
    private Vector2 direction;
    //private int EnemyDamage = 25;
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
            //PlayerController.Instance.hp = PlayerController.Instance.hp - EnemyDamage;
            SliderController.Instance.TakeDamage(25f);
            Destroy(gameObject);
            Instantiate(deathAnimation, transform.position, transform.rotation);
        }
    }
}