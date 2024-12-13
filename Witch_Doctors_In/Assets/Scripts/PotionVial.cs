using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PotionVial : MonoBehaviour, IDropHandler
{
    public GameObject[] ingredientObjects; // Assign all possible ingredients in the Inspector
    private HashSet<GameObject> correctIngredients = new HashSet<GameObject>();
    private HashSet<GameObject> addedIngredients = new HashSet<GameObject>();
    public TreatmentScreenManager treatmentScreenManager;
    private bool potionFailed = false;

    public void SetCorrectIngredients(string species)
    {
        correctIngredients.Clear();

        switch (species.ToLower())
        {
            case "orc":
                correctIngredients.Add(ingredientObjects[2]); // Ingredient 3 (Weak Spells)
                break;
            case "demon":
                correctIngredients.Add(ingredientObjects[1]); // Ingredient 2 (Flaming Fever)
                break;
            case "vampire":
                correctIngredients.Add(ingredientObjects[0]); // Ingredient 1 (Fickle Heartbeat)
                break;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (potionFailed) return;

        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            if (addedIngredients.Contains(droppedObject)) return;

            addedIngredients.Add(droppedObject);
            droppedObject.SetActive(false); // Make the ingredient disappear

            if (correctIngredients.Contains(droppedObject))
            {
                if (addedIngredients.SetEquals(correctIngredients))
                {
                    TriggerResult(true);
                }
            }
            else
            {
                TriggerResult(false);
            }
        }
    }

    private void TriggerResult(bool success)
    {
        treatmentScreenManager.ShowResult(success);
        potionFailed = true; // Prevent further interaction
    }

    public void ResetIngredients()
    {
        foreach (GameObject ingredient in ingredientObjects)
        {
            ingredient.SetActive(true); // Re-enable ingredients
            ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset position
        }

        addedIngredients.Clear(); // Clear tracking
        potionFailed = false; // Allow new potion attempts
        Debug.Log("Potion ingredients reset.");
    }
}
