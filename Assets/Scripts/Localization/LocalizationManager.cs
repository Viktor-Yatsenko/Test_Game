using UnityEngine;
using System;

public class LocalizationManager : MonoBehaviour
{
public static LocalizationManager Instance { get; private set; }

    public LocalizedTextTable localizedTextTable;

    public LocalizedTextTable.Language currentLanguage = LocalizedTextTable.Language.English;

    public event Action OnLanguageChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ApplyLanguage(currentLanguage);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyLanguage(LocalizedTextTable.Language language)
    {
        currentLanguage = language;
        localizedTextTable.SetLanguage(language);
        OnLanguageChanged?.Invoke();
    }

    public string GetLocalizedText(string key)
    {
        return localizedTextTable.Get(key);
    }
}
