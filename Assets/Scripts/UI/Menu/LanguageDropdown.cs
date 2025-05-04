using UnityEngine;
using TMPro;

public class LanguageDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown.onValueChanged.AddListener(OnLanguageSelected);
        dropdown.value = (int)LocalizationManager.Instance.currentLanguage;
    }

    private void OnLanguageSelected(int index)
    {
        LocalizationManager.Instance.ApplyLanguage((LocalizedTextTable.Language)index);
    }
}
