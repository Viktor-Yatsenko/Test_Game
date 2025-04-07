using UnityEngine;
using UnityEngine.SceneManagement;
public class IfEndGame : MonoBehaviour
{
    public static IfEndGame Instance {get; private set;}
    private void Awake() {Instance = this;}
    public void IsDeath()
    {
        gameObject.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }
}