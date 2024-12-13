using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TreatmentManager : MonoBehaviour
{
    public GameObject treatmentCanvas;  // The treatment screen canvas
    public TextMeshProUGUI treatmentResultText; // Displays SUCCESS or FAILURE
    public Button finishButton;        // Button to finalize treatment
    public GameObject livesContainer;  // Parent object containing the heart icons
    public GameObject patientEntryCanvas; // Canvas for the next patient

    private int lives = 3; // Number of lives
    public PatientEntry patientEntry;  // Reference to the PatientEntry script
    public GameObject diagnosisCanvas; // Reference to the diagnosis canvas
    public PotionBrewingManager potionBrewingManager; // Reference to the potion brewing manager

    void Start()
    {
        treatmentCanvas.SetActive(false); // Hide treatment screen initially
        UpdateLivesUI(); // Update the heart icons
        finishButton.onClick.AddListener(OnFinishTreatment); // Add listener to the Finish button
    }

    public void ShowTreatmentResult(bool success)
    {
        treatmentCanvas.SetActive(true); // Show the treatment screen
        if (success)
        {
            treatmentResultText.text = "SUCCESS! The potion worked!";
            treatmentResultText.color = Color.green;
        }
        else
        {
            treatmentResultText.text = "FAILURE! You lost 1 life.";
            treatmentResultText.color = Color.red;
            LoseLife();
        }
    }

    void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            Debug.Log("Game Over! Restart the game.");
            // Add Game Over logic here
        }
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < livesContainer.transform.childCount; i++)
        {
            livesContainer.transform.GetChild(i).gameObject.SetActive(i < lives);
        }
    }

    void OnFinishTreatment()
    {
        treatmentCanvas.SetActive(false);

        if (lives > 0)
        {
            // Transition to the next patient
            diagnosisCanvas.SetActive(true); // Show the diagnosis screen
            patientEntryCanvas.SetActive(true); // Show the patient entry UI
            patientEntry.ShowPatient(); // Load the next patient's data
        }
        else
        {
            Debug.Log("Game Over!");
            // Handle Game Over scenario here
        }
    }
}
