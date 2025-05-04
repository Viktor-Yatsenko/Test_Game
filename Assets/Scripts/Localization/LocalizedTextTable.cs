using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LocalizedTextTable", menuName = "Localization/Localized Text Table")]
public class LocalizedTextTable : ScriptableObject
{
    public enum Language
    {
        English,
        Ukrainian
    }

    [System.Serializable]
    public class EntryGroup
    {
        public string groupName;
        public List<SubGroup> subGroups = new List<SubGroup>();
    }

    [System.Serializable]
    public class SubGroup
    {
        public string subGroupName;
        public List<Entry> entries = new List<Entry>();
    }

    [System.Serializable]
    public class Entry
    {
        public string key;
        [TextArea] public string english;
        [TextArea] public string ukrainian;
    }

    public List<EntryGroup> groups = new List<EntryGroup>();

    private Dictionary<string, string> currentDictionary;

    public void SetLanguage(Language language)
    {
        currentDictionary = new Dictionary<string, string>();
        foreach (var group in groups)
        {
            foreach (var subGroup in group.subGroups)
            {
                foreach (var entry in subGroup.entries)
                {
                    string value = language switch
                    {
                        Language.English => entry.english,
                        Language.Ukrainian => entry.ukrainian,
                        _ => entry.english
                    };
                    currentDictionary[entry.key] = value;
                }
            }
        }
    }

    public string Get(string key)
    {
        if (currentDictionary != null && currentDictionary.TryGetValue(key, out var value))
            return value;

        return $"[MISSING:{key}]";
    }
}
