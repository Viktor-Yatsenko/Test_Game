using UnityEngine;

public class PlayerSound : SoundController
{
    public void Start() 
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        RunningAudioSource = sources[1];
        LoadFileSound();
    }

    private void LoadFileSound()
    {
        LoadSound("Assets/Sound/Sound Effects/Player/Sound miss attack.wav", clip => PlayerMissSound = clip);
        LoadSound("Assets/Sound/Sound Effects/Player/Sound hit attack.wav", clip => PlayerHitSound = clip);
        LoadSound("Assets/Sound/Sound Effects/Player/Player Running on Grass.wav", clip => PlayerRunningSound = clip);
        LoadSound("Assets/Sound/Sound Effects/Player/Take damage.wav", clip => DamageSound = clip);
    }
    //Player attack
    public void StartAttackSound(bool _hitEnemy) {hitEnemy = _hitEnemy;}

    public void PlayAttackSound()//Animation event
    {
        if(hitEnemy) {audioSource.PlayOneShot(PlayerHitSound);}
        else {audioSource.PlayOneShot(PlayerMissSound);}
    }

    //Player running sfxSource
    public void StartRunningSound(bool _isRunning)
    {
        isRunning = _isRunning;
        PlayerVisual.Instance.animator.SetBool("IsRunning", _isRunning);
        if (isRunning)
        {
            if (!RunningAudioSource.isPlaying) 
            {
                RunningAudioSource.clip = PlayerRunningSound;
                RunningAudioSource.loop = true;
                RunningAudioSource.Play();
            }
        }
        else
        {
            if (RunningAudioSource.isPlaying) {RunningAudioSource.Stop();}
        }
    }

    //Player takes damage
    public void PlayDamageSound(bool _takeDamage)//float delaySeconds =  0.7f
    {
        takeDamage = _takeDamage;
        audioSource.PlayOneShot(DamageSound);
        //PlayDamageSound(_takeDamage);
        //StartCoroutine(PlayDamageSoundCoroutine(_takeDamage, delaySeconds));
    }



    // public void PlayDamageSound(bool _takeDamage)//float delaySeconds =  0.7f
    // {
    //     takeDamage = _takeDamage;
    //     audioSource.PlayOneShot(DamageSound);
    //     //PlayDamageSound(_takeDamage);
    //     //StartCoroutine(PlayDamageSoundCoroutine(_takeDamage, delaySeconds));
    // }
    // private bool cache_takeDamage;
    // public void PlayDamageSoundWithDelay(bool _takeDamage, float delay)
    // {
    //     cache_takeDamage = _takeDamage;
    //     Invoke(nameof(PlayDamageSoundWithWrapper), delay);
    // }
    // private void PlayDamageSoundWithWrapper()
    // {
    //     PlayDamageSound(cache_takeDamage);
    // }






    // private System.Collections.IEnumerator PlayDamageSoundCoroutine(bool _takeDamage, float delaySeconds)
    // {
    //     if (delaySeconds > 0f)
    //     {
    //         yield return new WaitForSeconds(delaySeconds);
    //     }
    //     takeDamage = _takeDamage;
    //     audioSource.PlayOneShot(DamageSound);
    // }
}