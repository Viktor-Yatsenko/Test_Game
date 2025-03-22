using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    public static EnemyController Instance {get; private set;}
    private Vector2 direction;
    // private int Damage = 5;
    // void Update()
    // {

    // }
    void FixedUpdate()
    {
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EnemyVisual.Instance.EnemyAttack();
            //Destroy(gameObject);
        }
    }
}