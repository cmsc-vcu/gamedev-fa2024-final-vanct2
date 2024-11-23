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
            feedbackText.text = "Correct! You chose the right ingredient.";
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
            feedbackText.text = "Incorrect! That ingredient doesn’t match the symptom.";
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

    string GetCorrectIngredientForSymptom(string symptom)
    {
        // Map symptoms to the correct ingredients
        if (symptom == "Runny nose") return "Tissue";
        if (symptom == "Monster cough") return "Monster Syrup";
        if (symptom == "Sore bones") return "Bone Salve";
        return null;
    }
}
