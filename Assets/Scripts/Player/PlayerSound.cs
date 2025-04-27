public class PlayerSound : SoundController
{
    //Player attack
    public void StartAttackSound(bool _hitEnemy)
    {
        
        hitEnemy = _hitEnemy;
        PlayerVisual.Instance.animator.SetTrigger("Attack");
    }

    public void PlayAttackSound()
    {
        if(hitEnemy) {audioSource.PlayOneShot(PlayerHitSound);}
        else {audioSource.PlayOneShot(PlayerMissSound);}
    }

    //Player running
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
    public void PlayDamageSound(bool _takeDamage)
    {
        takeDamage = _takeDamage;
        audioSource.PlayOneShot(DamageSound);
    }
}
