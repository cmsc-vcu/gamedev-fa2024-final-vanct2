using UnityEngine;

public class TreatmentScreenManager : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject failureScreen;
    public LivesManager livesManager;
    public PatientEntry patientEntry;

    public void ShowResult(bool isSuccessful)
    {
        if (isSuccessful)
        {
            successScreen.SetActive(true);
            livesManager.PatientTreated();
        }
        else
        {
            failureScreen.SetActive(true);
            livesManager.LoseLife();
        }
    }

    public void NextPatient()
    {
        // Hide success and failure screens
        successScreen.SetActive(false);
        failureScreen.SetActive(false);

        // Reset potion brewing ingredients
        PotionBrewingManager potionBrewingManager = FindObjectOfType<PotionBrewingManager>();
        if (potionBrewingManager != null)
        {
            potionBrewingManager.ResetPotionBrewing();

            PotionVial potionVial = FindObjectOfType<PotionVial>();
            if (potionVial != null)
            {
                potionVial.ResetIngredients();
            }
        }

        // Reset Phase 1 and Phase 2 ingredients
        Phase1Diagnosis phase1 = FindObjectOfType<Phase1Diagnosis>();
        if (phase1 != null)
        {
            phase1.ResetPhaseIngredients();
        }

        Phase2Diagnosis phase2 = FindObjectOfType<Phase2Diagnosis>();
        if (phase2 != null)
        {
            phase2.ResetPhaseIngredients();
        }

        // Check if the game is over (Victory or Loss)
        if (livesManager.GetLives() <= 0 || livesManager.GetPatientsTreated() == 3)
        {
            return; // Stop further actions as the game has ended
        }

        // Load the next patient
        patientEntry.ShowPatient();
    }
}