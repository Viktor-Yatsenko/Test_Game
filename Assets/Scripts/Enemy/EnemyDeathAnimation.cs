using UnityEngine;
public class EnemyDeathAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start() {Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);}
}