using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using TMPro;

public class ColorHover : MonoBehaviour
{
    public Button button;
    public Color wantedColor;
    public Color wantedTextColor;
    public TextMeshProUGUI text;

    private Color originalColor;
    private Color originalTextColor;
    private ColorBlock cb;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = button.colors.selectedColor;
        cb = button.colors;

        originalTextColor = text.color;
    }

    public void WhenHover()
    {
        // This part is used to make the button change colors even after it's clicked, when the mouse is hovering in the button;

        cb.selectedColor = wantedColor;
        button.colors = cb;

        text.color = wantedTextColor;
    }

    public void WhenLeave()
    {
        // This part is used to make the button change colors even after it's clicked, when the mouse is leaving in the button;

        cb.selectedColor = originalColor;
        button.colors = cb;

        text.color = originalTextColor;
    }
}
