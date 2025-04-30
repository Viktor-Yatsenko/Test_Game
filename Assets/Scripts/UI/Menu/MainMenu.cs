using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    //private Text OnButton;
    //private Color originalTextColor;
    private int originalFontSize = 60;
    private int onPointerEnterFontSize = 80;
    private Color hoverTextColor = Color.white;
    private Dictionary<Text, Color> originalColors = new();


    private void Start()
    {
        // Находим все кнопки в дочерних объектах Canvas
        Button[] buttons = GetComponentsInChildren<Button>(true);

        foreach (Button btn in buttons)
        {
            Text text = btn.GetComponentInChildren<Text>();
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
        
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}