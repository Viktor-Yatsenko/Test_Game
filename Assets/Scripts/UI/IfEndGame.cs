using UnityEngine;
using UnityEngine.SceneManagement;
public class IfEndGame : MonoBehaviour
{
    public static IfEndGame Instance {get; private set;}
    private void Awake() {Instance = this;}
    public void IsDeath() 
    {
        AudioListener.pause = true;
        PlayerVisual.Instance.animator.enabled = true;
        EnemyVisual.Instance.animator.enabled = true;
        gameObject.SetActive(true);

    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainLevel");
    }
}