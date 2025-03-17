using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    //Player player;
    private Animator animator;
    //private bool isFacingRight = true;
    
    //protected internal bool Running = false;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    //private const string IS_ATTACK = "IsAttack";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // private void Update()
    // {
    //     animator.SetBool(IS_RUNNING, isRunning());
    // }
    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.isRunning());
    }

    // public bool isRunning()
    // {
    //     return player.RunningForClassPlayerVisual;
    //     //return Running;
    //     //return ClassPlayerVisual.Running;
    // }
    // public void FlipPlayer(float Horizontal)
    // {
    //     if(isFacingRight && Horizontal < 0f || isFacingRight == false && Horizontal > 0f)
    //     {
    //         isFacingRight = !isFacingRight;
    //         var localScale = transform.localScale;
    //         localScale.x *= -1f;
    //         transform.localScale = localScale;
    //     }
    // }
}