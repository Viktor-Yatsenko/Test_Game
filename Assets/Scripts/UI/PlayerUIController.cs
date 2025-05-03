using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public static PlayerUIController Instance {get; private set;}
    private PlayerSound playerSound;
    //Health
    [SerializeField] private Image imageHealth;
    internal float currentHealth = 100f;
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
        //currentHealth = PlayerController.Instance.hp;
        UpdateHealthBar();
        currentMana = maxMana;
        UpdateManaBar();
        currentStamina = maxStamina;
        UpdateExperienceBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerSound.PlayDamageSound(true);
        currentHealth = Mathf.Clamp(currentHealth, 0f, PlayerController.Instance.hp);
        UpdateHealthBar();
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