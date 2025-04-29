using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    protected AudioSource audioSource;

    //Player
    //Player attack
    protected AudioClip PlayerMissSound;
    protected AudioClip PlayerHitSound;
    protected bool hitEnemy = false;
    //Player running
    protected AudioSource RunningAudioSource;
    protected AudioClip PlayerRunningSound;
    protected bool isRunning = false;
    //Player takes damage
    protected AudioClip DamageSound;
    protected bool takeDamage = false;
    //Enemy
    protected AudioSource EnemyAudioSource;
    //Enemy attack
    protected AudioClip EnemyAttackSound;
    protected bool attackEnemy;
    //Enemy death
    protected AudioClip EnemyDeathSound;
    protected bool enemyDeath;

    public void Awake()
    {
        //Instance = this;
        //Set all AudioSource
        //AudioSource[] sources = GetComponents<AudioSource>();
        // audioSource = sources[0];
        // RunningAudioSource = sources[1];
        //EnemyaudioSource = sources[2]; // пофиксить для врага (придумать как сделать его отдельным)

    }

    protected void LoadSound(string addressFile, System.Action<AudioClip> onLoaded)
    {
        Addressables.LoadAssetAsync<AudioClip>(addressFile).Completed += handle =>
        {
            onLoaded?.Invoke(handle.Result);
            Addressables.Release(handle);
        };
    }
}