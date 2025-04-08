using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    public static PlayerUIController Instance {get; private set;}
    //Health
    [SerializeField] private Image imageHealth;
    private float maxHealth = 100f;
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
        currentHealth = maxHealth;
        UpdateHealthBar();
        currentMana = maxMana;
        UpdateManaBar();
        currentStamina = maxStamina;
        UpdateExperienceBar();
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
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