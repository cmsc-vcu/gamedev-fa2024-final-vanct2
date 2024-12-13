using UnityEngine;
using TMPro;

public class Phase1Diagnosis : MonoBehaviour
{
    public GameObject[] ingredientObjects; // Assign Phase 1 ingredients in the Inspector
    public TextMeshProUGUI feedbackText; // For feedback display
    public GameObject phase1Buttons; // Parent GameObject containing the Phase 1 buttons
    public Phase2Diagnosis phase2Diagnosis; // Reference to Phase2Diagnosis script
    public GameObject phase2Buttons; // Parent GameObject containing the Phase 2 buttons
    public PatientEntry patientEntry; // Reference to PatientEntry

    public void CheckSpeciesIngredient(string ingredient)
    {
        string correctIngredient = GetCorrectIngredientForSpecies(patientEntry.GetMonsterSpecies());

        if (ingredient == correctIngredient)
        {
            feedbackText.text = "This looks good.";
            Debug.Log("Phase 1 Complete!");

            // Hide Phase 1 buttons
            phase1Buttons.SetActive(false);

            // Show Phase 2 buttons
            phase2Buttons.SetActive(true);

            // Start Phase 2 (pass the randomly generated symptom)
            phase2Diagnosis.StartPhase2(patientEntry.GetGroupASymptom());
        }
        else
        {
            feedbackText.text = "This can't be right... This patient is a different species.";
            Debug.Log("Strike added!");
            // Add strike logic here if applicable
        }
    }

    private string GetCorrectIngredientForSpecies(string species)
    {
        if (species == "Orc") return "Orc Herb";
        if (species == "Vampire") return "Vampire Fang";
        if (species == "Demon") return "Demon Horn";
        return null;
    }

    public void ResetPhaseIngredients()
    {
        foreach (GameObject ingredient in ingredientObjects)
        {
            ingredient.SetActive(true); // Re-enable ingredients
            ingredient.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset position
        }

        Debug.Log("Phase 1 ingredients reset.");
    }
}