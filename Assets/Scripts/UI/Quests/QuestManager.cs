using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public GameObject questPanel;
    public TextMeshProUGUI questText;
    //public Text questText;
    public Button startButton;
    public GameObject questCompletePanel;
    public TextMeshProUGUI questCompleateText;
    //public Text questCompleateText;
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
        questText.alignment = TextAlignmentOptions.MidlineGeoAligned;
    }

    void FixedUpdate()
    {
        questCompleateText.text = "Завдання виконано!";
        questCompleateText.fontSize = 60;
        questCompleateText.alignment = TextAlignmentOptions.MidlineGeoAligned;
        // questCompleateText.alignment = TextAnchor.UpperCenter;
        // questCompleateText.alignment = TextAnchor.MiddleCenter;
    }

    void StartQuest()
    {
        TimerManager.Instance.RunAfter(1f, () => PlayerController.Instance.enabled = true);
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
            Invoke(nameof(CompleteQuest), 2f);
        }
    }

    private void CompleteQuest()
    {
        AudioListener.volume = 0f;
        PlayerVisual.Instance.animator.enabled = false;
        EnemyVisual.Instance.animator.enabled = false;
        questCompletePanel.SetActive(true);
        PlayerController.Instance.enabled = false;
    }
}