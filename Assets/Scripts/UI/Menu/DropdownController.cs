using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownController : MonoBehaviour
{
    [SerializeField] public float itemHeight = 110f; // Height one options
    private float paddingTop = 0f;
    private float paddingBottom = 0f;

    void Start()
    {
        TMP_Dropdown TMPdropdown = GetComponent<TMP_Dropdown>();
        if (TMPdropdown == null || TMPdropdown.template == null) return;

        int optionCount = TMPdropdown.options.Count;
        if (optionCount == 0) return;

        RectTransform templateRect = TMPdropdown.template.GetComponent<RectTransform>();
        if (templateRect == null) return;

        // Calculate height
        float totalHeight = (itemHeight * optionCount) + paddingTop + paddingBottom;

        // Set height Template
        templateRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);
    }
}