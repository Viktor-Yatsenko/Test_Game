using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance {get; private set;}
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    private float playerDamage = 25f;
    public Animator animator;

    private float attackCooldown = 0.1f;
    private float lastAttackTime;
    public void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) & Time.time >= lastAttackTime + attackCooldown)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
            bool hitEnemy = enemies.Length > 0; //checking to see if
            SoundController.Instance.StartAttackSound(_hitEnemy: hitEnemy);
            for (int i =0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyController>().TackeDamage(playerDamage);
            }
            lastAttackTime = Time.time;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}