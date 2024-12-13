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

    // Define the default positions for the ingredients
    private Vector3[] ingredientPositions = new Vector3[]
    {
        new Vector3(182.98f, 82.9f, 0f),   // Position for Ingredient 1
        new Vector3(182.8f, 0f, 0f),      // Position for Ingredient 2
        new Vector3(184f, -86.9f, 0f)     // Position for Ingredient 3
    };

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
        Debug.Log("ResetIngredients called in PotionVial.");

        for (int i = 0; i < ingredientObjects.Length; i++)
        {
            GameObject ingredient = ingredientObjects[i];

            if (ingredient != null)
            {
                // Re-enable the ingredient
                ingredient.SetActive(true);

                // Reset position and scale
                RectTransform rect = ingredient.GetComponent<RectTransform>();
                if (rect != null)
                {
                    rect.localPosition = ingredientPositions[i]; // Reset position
                }

                // Reset CanvasGroup properties
                CanvasGroup canvasGroup = ingredient.GetComponent<CanvasGroup>();
                if (canvasGroup != null)
                {
                    canvasGroup.alpha = 1f; // Fully visible
                    canvasGroup.interactable = true; // Make clickable
                    canvasGroup.blocksRaycasts = true; // Enable raycasts
                }

                // Log state
                Debug.Log($"Ingredient {ingredient.name}: Active = {ingredient.activeSelf}, Position = {rect?.localPosition}, Scale = {rect?.localScale}");
            }
            else
            {
                Debug.LogWarning($"Ingredient at index {i} is null.");
            }
        }

        addedIngredients.Clear(); // Clear tracking
        potionFailed = false; // Allow new potion attempts
        Debug.Log("Potion ingredients reset.");
    }
}