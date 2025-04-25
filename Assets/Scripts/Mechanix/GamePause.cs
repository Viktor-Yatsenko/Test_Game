using System.Collections;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static GamePause Instance;
    void Awake()
    {
        Instance = this;
    }
    public void PauseGame(float seconds)
    {
        StartCoroutine(PauseRoutine(seconds));
    }
    private IEnumerator PauseRoutine(float seconds)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;
    }
}
