using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientHover : MonoBehaviour
{
    public string description;   // The ingredient's description
    public TextMeshProUGUI tooltipText;     // Reference to the Tooltip UI text

    public void ShowTooltip()
    {
        tooltipText.text = description;
        tooltipText.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false);
    }
}
