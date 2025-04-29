using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IfEndGame : MonoBehaviour
{
    public static IfEndGame Instance {get; private set;}

    //GameObject restartButton;

    private void Awake() 
    {
        Instance = this;
        //endGameCanvas = GetComponent<Canvas>();
        //textLegacy = GameObject.Find("Text (Legacy)");
        //restartButton = GameObject.Find("RestartButton (Legacy)");
    }

    // public void DeathCoroutine()
    // {
    //     StartCoroutine(Death());
    // }
    // private IEnumerator Death()
    // {
    //     yield return new WaitForSeconds(2f);
    //     //AudioListener.pause = true;
    //     PlayerVisual.Instance.animator.enabled = true;
    //     EnemyVisual.Instance.animator.enabled = true;
    //     gameObject.SetActive(true);
    // }
    
    public void Death() 
    {
        PlayerVisual.Instance.animator.enabled = true;
        gameObject.SetActive(true);
    }

    // public void Death() {Invoke(nameof(IsDeath), 2f);}
    // private void IsDeath() 
    // {
    //     PlayerVisual.Instance.animator.enabled = true;
    //     gameObject.SetActive(true);
    // }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainLevel");
    }
}