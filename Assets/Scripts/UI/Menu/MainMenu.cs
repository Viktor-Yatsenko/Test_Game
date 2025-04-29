using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Continue()
    {
        //SceneManager.LoadScene
    }

    public void NewGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
