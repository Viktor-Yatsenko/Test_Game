using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.TextCore.Text;

public class MainMenu : MonoBehaviour
{
    private int originalFontSize = 60;
    private int onPointerEnterFontSize = 80;
    private Color hoverTextColor = Color.white;
    private Dictionary<TextMeshProUGUI, Color> originalColors = new();
    //private Dictionary<Text, Color> originalColors = new();

    // Open menu animation
    [Header("Animation settings menu")]
    public Animator animator;
    private bool isSettingsOpen = false;

    private void Start()
    {
        // Find all buttons in children object Canvas
        Button[] buttons = GetComponentsInChildren<Button>(true);

        foreach (Button btn in buttons)
        {
            //Text text = btn.GetComponentInChildren<Text>();
            TextMeshProUGUI text = btn.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                originalColors[text] = text.color;
                
                // Добавляем обработчики событий
                EventTrigger trigger = btn.gameObject.GetComponent<EventTrigger>();
                if (trigger == null)
                    trigger = btn.gameObject.AddComponent<EventTrigger>();

                // OnPointerEnter
                EventTrigger.Entry enter = new();
                enter.eventID = EventTriggerType.PointerEnter;
                enter.callback.AddListener((_) =>
                {
                    text.color = hoverTextColor;
                    text.fontSize = onPointerEnterFontSize;
                });
                trigger.triggers.Add(enter);

                // OnPointerExit
                EventTrigger.Entry exit = new();
                exit.eventID = EventTriggerType.PointerExit;
                exit.callback.AddListener((_) =>
                {
                    text.color = originalColors[text];
                    text.fontSize = originalFontSize;
                });
                trigger.triggers.Add(exit);
            }
        }
    }

    private void Continue()
    {
      
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Settings()
    {
        if(isSettingsOpen)
        {
            animator.SetTrigger("CloseMenu");
        }
        else
        {
            animator.SetTrigger("OpenMenu");
        }
        isSettingsOpen = !isSettingsOpen;

    }

    // private void OpenMenu()
    // {
    //     animator.SetTrigger("OpenMenu 0");
    //     //animator.SetBool("OpenMenu", stateMenu);
    // }

    // private void CloseMenu()
    // {
    //     //animator.SetTrigger("CloseMenu 0");
    //     animator.SetBool("CloseMenu", true);
    // }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}