using UnityEngine;

public class EnemySound : SoundController
{
    private void Start() 
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        EnemyAudioSource = sources[0];
        LoadFileSound();
    }

    private void LoadFileSound()
    {
        LoadSound("Assets/Sound Effects/Enemy/Enemy Attack.wav", clip => EnemyAttackSound = clip);
        LoadSound("Assets/Sound Effects/Enemy/Enemy Death.wav", clip => EnemyDeathSound = clip);
    }

    //Enemy attack
    public void StartAttackSound(bool _attackEnemy) 
    {
        attackEnemy = _attackEnemy;
    }

    public void PlayAttackSound()//Animation event
    {
        if(attackEnemy)
            EnemyAudioSource.PlayOneShot(EnemyAttackSound);
    }
}