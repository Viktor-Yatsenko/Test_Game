using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    void Update()
    {
        if(PlayerController.Instance.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
