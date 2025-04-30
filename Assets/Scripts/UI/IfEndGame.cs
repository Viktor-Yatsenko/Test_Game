using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IfEndGame : MonoBehaviour
{
    public static IfEndGame Instance {get; private set;}

    private void Awake() 
    {
        Instance = this;
    }
    
    public void Death() 
    {
        PlayerVisual.Instance.animator.enabled = true;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainLevel");
    }
}