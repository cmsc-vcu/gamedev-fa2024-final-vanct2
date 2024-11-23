using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class PotionVial : MonoBehaviour, IDropHandler
{
    public GameObject[] ingredientObjects; // Assign all possible ingredients in the Inspector
    private HashSet<GameObject> correctIngredients = new HashSet<GameObject>(); // Dynamically track correct ingredients
    private HashSet<GameObject> addedIngredients = new HashSet<GameObject>();  // Track added ingredients
    public TextMeshProUGUI resultText;                                         // Reference to Result Text UI
    private int correctIngredientCount = 0;                                    // Track how many correct ingredients have been added
    private bool potionFailed = false;                                         // Track if the potion has failed

    public void SetCorrectIngredients(string species)
    {
        correctIngredients.Clear();

        // Set correct ingredients based on species
        switch (species.ToLower())
        {
            case "orc":
                correctIngredients.Add(ingredientObjects[2]); // Ingredient 3 (Weak Spells)
                Debug.Log("Set correct ingredient: Weak Spells");
                break;
            case "demon":
                correctIngredients.Add(ingredientObjects[1]); // Ingredient 2 (Flaming Fever)
                Debug.Log("Set correct ingredient: Flaming Fever");
                break;
            case "vampire":
                correctIngredients.Add(ingredientObjects[0]); // Ingredient 1 (Fickle Heartbeat)
                Debug.Log("Set correct ingredient: Fickle Heartbeat");
                break;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (potionFailed)
        {
            Debug.Log("Potion already failed. No further additions allowed.");
            return;
        }

        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            Debug.Log($"Dropped: {droppedObject.name}");

            // Prevent double-counting by checking if already added
            if (addedIngredients.Contains(droppedObject))
            {
                Debug.Log($"Ingredient {droppedObject.name} already added.");
                return; // Skip if already added
            }

            addedIngredients.Add(droppedObject);
            droppedObject.SetActive(false); // Make the ingredient disappear

            if (addedIngredients.Count > correctIngredients.Count)
            {
                // If too many ingredients are added, fail the potion
                FailPotion();
                return;
            }

            // Check if the dropped ingredient is correct
            bool isCorrect = correctIngredients.Contains(droppedObject);

            if (isCorrect)
            {
                correctIngredientCount++;
                Debug.Log($"Correct ingredient: {droppedObject.name}");
                resultText.text = "Correct ingredient added!";
                resultText.color = Color.green;

                // Check if all correct ingredients have been added
                if (correctIngredientCount == correctIngredients.Count)
                {
                    Debug.Log("All correct ingredients added.");
                    resultText.text = "Potion brewed successfully!";
                    resultText.color = Color.green;
                    GetComponent<UnityEngine.UI.Image>().color = Color.green; // Turn the vial green
                }
            }
            else
            {
                Debug.Log("Incorrect ingredient!");
                FailPotion();
            }
        }
    }

    private void FailPotion()
    {
        potionFailed = true;
        GetComponent<UnityEngine.UI.Image>().color = Color.red; // Turn the vial red
        resultText.text = "I hope they signed a waver.";
        resultText.color = Color.red;
        Debug.Log("Potion failed due to incorrect or extra ingredient.");
    }
}
