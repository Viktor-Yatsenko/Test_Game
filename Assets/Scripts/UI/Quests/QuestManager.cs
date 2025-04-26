using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public GameObject questPanel;
    public Text questText;
    public Button startButton;
    public GameObject questCompletePanel;
    public Text questCompleateText;
    private int killCount = 0;
    private int killGoal = 5;
    private bool questStarted = false;
    void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
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
        Time.timeScale = 1f;
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
        yield return new WaitForSeconds(2f);
        AudioListener.pause = false;
        PlayerVisual.Instance.animator.enabled = false;
        EnemyVisual.Instance.animator.enabled = false;
        questCompletePanel.SetActive(true);
        PlayerController.Instance.enabled = false;
    }
}