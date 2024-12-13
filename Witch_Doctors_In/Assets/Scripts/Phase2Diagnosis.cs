using UnityEngine;
using TMPro;
using System.Collections;

public class Phase2Diagnosis : MonoBehaviour
{
    public TextMeshProUGUI feedbackText; // Reference for feedback display
    public GameObject groupAButtons; // Parent object for Group A buttons (Bone Salve, Monster Syrup, etc.)
    public GameObject minigameButtons; // Parent object for Minigame buttons (Spell Check, Temp Check, Vital Check)
    public TextMeshProUGUI dialogueText; // Reference for dialogue display
    private string currentSymptom;
    public GameObject[] ingredientObjects; // Assign Phase 2 ingredients in the Inspector

    public void StartPhase2(string symptom)
    {
        currentSymptom = symptom;
        Debug.Log($"Symptom for Phase 2: {currentSymptom}");
    }

    public void CheckGroupAIngredient(string ingredient)
    {
        string correctIngredient = GetCorrectIngredientForSymptom(currentSymptom);

        if (ingredient == correctIngredient)
        {
            feedbackText.text = "This ingredient works.";
            Debug.Log("Phase 2 Complete!");

            // Start coroutine to clear feedback after 2 seconds
            StartCoroutine(ClearFeedback());

            // Hide Group A buttons
            groupAButtons.SetActive(false);

            // Show Minigame buttons
            minigameButtons.SetActive(true);

            // Update dialogue text
            dialogueText.text = "Pick a test you'd like to perform!";
        }
        else
        {
            feedbackText.text = "Hm... I need to check my notes again.";
            Debug.Log("Strike added!");
            // Start coroutine to clear feedback after 2 seconds
            StartCoroutine(ClearFeedback());
        }
    }

    private IEnumerator ClearFeedback()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Clear the feedback text
        feedbackText.text = "";
    }

    private string GetCorrectIngredientForSymptom(string symptom)
    {
        // Map symptoms to the correct ingredients
        if (symptom == "Runny nose") return "Tissue";
        if (symptom == "Monster cough") return "Monster Syrup";
        if (symptom == "Sore bones") return "Bone Salve";
        return null;
    }

    public void ResetPhaseIngredients()
    {
        foreach (GameObject ingredient in ingredientObjects)
        {
            ingredient.SetActive(true); // Re-enable ingredients
            ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset position
        }

        Debug.Log("Phase 2 ingredients reset.");
    }
}
