using System;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance {get; private set;}
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 0.1f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float damage = 25f;
    [SerializeField] private GameObject deathAnimation;
    
    internal float health = 100f;

    private Transform player;
    private float lastAttackTime;
    private Vector2 direction;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer > attackRange) // Pursue player
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
        else // Player in radius attack
        {
            if(Time.time >= lastAttackTime + attackCooldown)
            {
                EnemyVisual.Instance.EnemyAttack();
                PlayerUIController.Instance.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
        if(health <= 0)
        {
            EnemyVisual.Instance.EnemyDeath();
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject, 3f);
        }
        Debug.Log(health);

    }
    public void TackeDamage(float playerDamage)
    {
        health -= playerDamage;
    }
    public void FixedUpdate()
    {
        direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}