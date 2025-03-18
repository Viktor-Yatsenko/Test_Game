using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector2 direction;
    //private int Damage = 5;
    // void Update()
    // {
        
    // }
    void FixedUpdate()
    {
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    // [SerializeField] private SpriteRenderer spriteRenderer;
    // void Update()
    // {
    //     if(PlayerController.Instance.transform.position.x > transform.position.x)
    //     {
    //         spriteRenderer.flipX = true;
    //     }
    //     else
    //     {
    //         spriteRenderer.flipX = false;
    //     }
    // }
}
