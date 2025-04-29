//Timer Manager for Unity
using System;
using System.Collections.Generic;
using UnityEngine;

//INSTRUCTION AND EXAMPLE
// Options (Можливості):
// RunAfter — Play with delay (запуск через затримку)
// RunLoop — Loop with interval (повторювати з інтервалом)
// Cancel("id") — Cancel by name (відмінити за ім'ям(id))
// Binding to an object (Прив'язка до об'єкту): boundTo: gameObject

// Accepts parameters (Принимает параметры)
// Does not depend on Invoke or Coroutine — clean timer system (Не зависит от Invoke или Coroutine — чистая система таймеров)

// public void Play(string clip)
// {
//     Debug.Log($"Грає звук: {clip}");
// }

// public void PlayWithDelay()
// {
//     TimerManagerPro.Instance.RunAfter(1.5f, () => Play("jumpClip"), id: "jump");
// }

// public void LoopAlert()
// {
//     TimerManagerPro.Instance.RunLoop(2f, () => Play("enemyAlert"), id: "alert", boundTo: gameObject);
// }

// public void StopAlert()
// {
//     TimerManagerPro.Instance.Cancel("alert");
// }

public class TimerManager : MonoBehaviour
{
    private class TimerTask
    {
        public float TimeRemaining;
        public float Interval;
        public bool Loop;
        public Action Callback;
        public GameObject BoundObject;
        public string Id;
    }

    private List<TimerTask> tasks = new();
    private static TimerManager instance;

    public static TimerManager Instance
    {
        get
        {
            if (instance == null)
            {
                var go = new GameObject("TimerManager");
                instance = go.AddComponent<TimerManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    private void Update()
    {
        for (int i = tasks.Count - 1; i >= 0; i--)
        {
            var task = tasks[i];

            // Удалить, если привязанный объект уничтожен
            if (task.BoundObject == null && task.BoundObject != null)
            {
                tasks.RemoveAt(i);
                continue;
            }

            task.TimeRemaining -= Time.deltaTime;

            if (task.TimeRemaining <= 0f)
            {
                task.Callback?.Invoke();

                if (task.Loop)
                {
                    task.TimeRemaining = task.Interval;
                }
                else
                {
                    tasks.RemoveAt(i);
                }
            }
        }
    }

    public void RunAfter(float delay, Action callback, string id = null, GameObject boundTo = null)
    {
        tasks.Add(new TimerTask
        {
            TimeRemaining = delay,
            Interval = delay,
            Callback = callback,
            Loop = false,
            Id = id,
            BoundObject = boundTo
        });
    }

    public void RunLoop(float interval, Action callback, string id = null, GameObject boundTo = null)
    {
        tasks.Add(new TimerTask
        {
            TimeRemaining = interval,
            Interval = interval,
            Callback = callback,
            Loop = true,
            Id = id,
            BoundObject = boundTo
        });
    }

    public void Cancel(string id)
    {
        tasks.RemoveAll(t => t.Id == id);
    }
}