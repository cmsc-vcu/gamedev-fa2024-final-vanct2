using UnityEngine;
using TMPro;
using System.Collections;

public class Phase1Diagnosis : MonoBehaviour
{
    public PatientEntry patientEntry; // Reference to PatientEntry
    public TextMeshProUGUI feedbackText; // For feedback display
    public GameObject phase1Buttons; // Parent GameObject containing the Phase 1 buttons
    public Phase2Diagnosis phase2Diagnosis; // Reference to Phase2Diagnosis script
    public GameObject phase2Buttons; // Parent GameObject containing the Phase 2 buttons

    public void CheckSpeciesIngredient(string ingredient)
    {
        string correctIngredient = GetCorrectIngredientForSpecies(patientEntry.GetMonsterSpecies());

        if (ingredient == correctIngredient)
        {
            feedbackText.text = "Correct! You chose the right ingredient for the species.";

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
            feedbackText.text = "Incorrect! That ingredient doesn’t match the species.";
            Debug.Log("Strike added!");
            // Add strike logic here
        }
    }

    string GetCorrectIngredientForSpecies(string species)
    {
        if (species == "Orc") return "Orc Herb";
        if (species == "Vampire") return "Vampire Fang";
        if (species == "Demon") return "Demon Horn";
        return null;
    }
}
