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
    //Enemy attack
    protected AudioClip EnemyAttackSound;
    protected bool attackEnemy;
    //Enemy death
    protected AudioClip EnemyDeathSound;
    protected bool enemyDeath;

    public void Awake()
    {
        Instance = this;
        //Set all AudioSource
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        RunningAudioSource = sources[1];

    }
    
    private void Start() {LoadFileSound();}

    private void LoadFileSound()
    {
        //Player
        LoadSound("Assets/Sound Effects/Player/Sound miss attack.wav", clip => PlayerMissSound = clip);
        LoadSound("Assets/Sound Effects/Player/Sound hit attack.wav", clip => PlayerHitSound = clip);
        LoadSound("Assets/Sound Effects/Player/Player Running on Grass.wav", clip => PlayerRunningSound = clip);
        LoadSound("Assets/Sound Effects/Player/Take damage.wav", clip => DamageSound = clip);
        //Enemy
        LoadSound("Assets/Sound Effects/Enemy/Enemy Attack.wav", clip => EnemyAttackSound = clip);

    }

    private void LoadSound(string addressFile, System.Action<AudioClip> onLoaded)
    {
        Addressables.LoadAssetAsync<AudioClip>(addressFile).Completed += handle =>
        {
            onLoaded?.Invoke(handle.Result);
            Addressables.Release(handle);
        };
    }
}