using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public GameObject questPanel;         // UI панель с текстом квеста
    public Text questText;                // Текст квеста
    public Button startButton;            // Кнопка "Начать"
    public GameObject questCompletePanel; // Панель "Квест выполнен"
    public Text questCompleateText;

    private int killCount = 0;
    private int killGoal = 2;
    private bool questStarted = false;
     void Awake()
    {
        Instance = this;
        startButton.onClick.AddListener(StartQuest);
        questPanel.SetActive(true);
        questCompletePanel.SetActive(false);
        //Quest Text settings
        questText.text = "Завдання:\n Тобі потрібно вбити 5 вовків";
        questText.fontSize = 40;
        questText.alignment = TextAnchor.UpperCenter;
        questText.alignment = TextAnchor.MiddleCenter;
    }
    void FixedUpdate()
    {
        questCompleateText.text = "Завдання виконано!";
        questCompleateText.fontSize = 60;
        questCompleateText.alignment = TextAnchor.UpperCenter;
        questCompleateText.alignment = TextAnchor.MiddleCenter;
    }
    void StartQuest()
    {
        questStarted = true;
        questPanel.SetActive(false);
    }
    public void AddKill()
    {
        if (!questStarted) return;

        killCount++;

        if (killCount >= killGoal)
        {
            StartCoroutine(CompleteQuestRoutine());
        }
    }
    private IEnumerator CompleteQuestRoutine()
    {
        GamePause.Instance.PauseGame(2f);
        yield return new WaitForSeconds(2f);
        questCompletePanel.SetActive(true);
    }
}
