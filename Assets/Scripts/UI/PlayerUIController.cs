using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public static PlayerUIController Instance {get; private set;}
    private PlayerSound playerSound;
    //Health
    [SerializeField] private Image imageHealth;
    internal float currentHealth;
    //Mana
    [SerializeField] private Image imageMana;
    private float maxMana = 100f;
    internal float currentMana;
    //Stamina
    [SerializeField] private Image imageStamina;
    internal float maxStamina = 100f;
    internal float currentStamina;
    internal float regenerateStamina = 15f;
    //Experience
    [SerializeField] private Image imageExperience;
    //private float maxExperience = 100f;
    internal float currentExperience;

    private void Awake() {Instance = this;}

    void Start()
    {
        playerSound = FindAnyObjectByType<PlayerSound>();
        currentHealth = PlayerController.Instance.hp;
        UpdateHealthBar();
        currentMana = maxMana;
        UpdateManaBar();
        currentStamina = maxStamina;
        UpdateExperienceBar();
    }

    public void TakeDamage(float damage)
    {
        //PlayerUIController.Instance.TakeDamageWithDelay(damage, 0.7f);
        //добавить задержку в 0.7f
        currentHealth -= damage;
        playerSound.PlayDamageSound(true);
        //playerSound.PlayDamageSoundWithDelay(true, 0.7f);
        currentHealth = Mathf.Clamp(currentHealth, 0f, PlayerController.Instance.hp);
        UpdateHealthBar();
    }
    //Wrapper
    private float cacheDamage;
    public void TakeDamageWithDelay(float damage, float delay)
    {
        cacheDamage = damage;
        Invoke(nameof(TakeDamageWithWrapper), delay);
    }
    private void TakeDamageWithWrapper()
    {
        TakeDamage(cacheDamage);
    }

    

    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / PlayerController.Instance.hp;
        imageHealth.fillAmount = fillAmount;
    }

    public void TakeManaBar()
    {

    }

    private void UpdateManaBar()
    {

    }

    public void TakeStamina(float stamina)
    {
        currentStamina -= stamina;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    public void UpdateStaminaBar(float current, float max)
    {
        float fill = current / max;
        imageStamina.fillAmount = fill;
    }
    
    private void UpdateExperienceBar()
    {

    }
}