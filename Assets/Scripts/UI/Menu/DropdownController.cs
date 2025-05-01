using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DropdownController : MonoBehaviour
{
    public float itemHeight = 40f; // Height one options
    public float paddingTop = 0f;
    public float paddingBottom = 0f;

    void Start()
    {
        Dropdown dropdown = GetComponent<Dropdown>();
        if (dropdown == null || dropdown.template == null) return;

        int optionCount = dropdown.options.Count;
        if (optionCount == 0) return;

        RectTransform templateRect = dropdown.template.GetComponent<RectTransform>();
        if (templateRect == null) return;

        // Calculate height
        float totalHeight = (itemHeight * optionCount) + paddingTop + paddingBottom;

        // Set height Template
        templateRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);
    }
}