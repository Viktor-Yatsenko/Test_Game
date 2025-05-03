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
        //Destroy enemy for player in new game don`t take damage
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

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