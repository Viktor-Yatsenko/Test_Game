using UnityEngine;
public class SoundController : MonoBehaviour
{
    public static SoundController Instance {get; private set;}
    [Header("Player attack")]
    [SerializeField] private AudioSource AttackAudioSource;
    [SerializeField] private AudioClip PlayerMissSound;
    [SerializeField] private AudioClip PlayerHitSound;
    private bool hitEnemy = false;
    [Header("Player running")]
    [SerializeField] private AudioSource RunningAudioSource;
    [SerializeField] private AudioClip PlayerRunningSound;
    private bool isRunning = false;
    private void Awake()
    {
        Instance = this;
        //Set all AudioSource
        AudioSource[] sources = GetComponents<AudioSource>();
        AttackAudioSource = sources[0]; //First source for attack
        RunningAudioSource = sources[1]; //Second source for running
        //Settings sourse for running
        RunningAudioSource.clip = PlayerRunningSound;
        RunningAudioSource.loop = true;
    }
    //Player attack
    public void StartAttackSound(bool _hitEnemy)
    {
        hitEnemy = _hitEnemy;
        PlayerVisual.Instance.animator.SetTrigger("Attack");
    }
    public void PlayAttackSound()
    {
        if(hitEnemy) {AttackAudioSource.PlayOneShot(PlayerHitSound);}
        else {AttackAudioSource.PlayOneShot(PlayerMissSound);}
    }
    //Player running
    public void StartRunningSound(bool _isRunning)
    {
        isRunning = _isRunning;
        PlayerVisual.Instance.animator.SetBool("IsRunning", _isRunning);
        if (isRunning)
        {
            if (!RunningAudioSource.isPlaying) {RunningAudioSource.Play();}
        }
        else
        {
            if (RunningAudioSource.isPlaying) {RunningAudioSource.Stop();}
        }
    }
}
