using UnityEngine;

public class TreatmentScreenManager : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject failureScreen;
    public GameObject potionBrewingCanvas;    // Reference to Potion Brewing Canvas
    public GameObject patientEntryCanvas;     // Reference to the Patient Entry Canvas
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
        Debug.Log("NextPatient method called.");

        // Hide success and failure screens
        successScreen.SetActive(false);
        failureScreen.SetActive(false);

        // Reset potion brewing ingredients
        if (potionBrewingCanvas != null)
        {
            PotionVial potionVial = FindObjectOfType<PotionVial>();
            if (potionVial != null)
            {
                potionVial.ResetIngredients();
                Debug.Log("Potion ingredients reset.");
            }
            else
            {
                Debug.LogWarning("PotionVial component not found in the scene.");
            }

            potionBrewingCanvas.SetActive(false);
            Debug.Log("Potion Brewing Canvas reset and set to inactive.");
        }

        // Check game over conditions
        if (livesManager.GetLives() <= 0 || livesManager.GetPatientsTreated() == 3)
        {
            Debug.Log("Game over! No further patients.");
            return;
        }

        // Load the next patient
        Debug.Log("Loading next patient...");
        patientEntry.ShowPatient();

        // Activate the Patient Entry Canvas
        if (patientEntryCanvas != null)
        {
            patientEntryCanvas.SetActive(true);
            Debug.Log("Patient Entry Canvas activated.");
        }
        else
        {
            Debug.LogError("Patient Entry Canvas reference not set!");
        }
    }
}
