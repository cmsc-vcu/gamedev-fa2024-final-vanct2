using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public Image[] hearts; // Assign 3 heart images in the Inspector
    private int lives = 3; // Start with 3 lives
    private int patientsTreated = 0; // Track successfully treated patients
    public GameObject victoryScreen; // White screen for victory
    public GameObject lossScreen; // Black screen for loss

    public void LoseLife()
    {
        if (lives > 0)
        {
            hearts[--lives].enabled = false; // Disable the last heart
        }

        if (lives <= 0)
        {
            EndGame(false); // Show loss screen
        }
    }
 
    public void PatientTreated()
    {
        patientsTreated++;

        if (patientsTreated == 3 && lives > 0)
        {
            EndGame(true); // Show victory screen
        }
    }

    private void EndGame(bool victory)
    {
        if (victory)
        {
            victoryScreen.SetActive(true); // Show victory screen
        }
        else
        {
            lossScreen.SetActive(true); // Show loss screen
        }

        Time.timeScale = 0f; // Optionally pause the game
    }

    // Getter for patientsTreated
    public int GetPatientsTreated()
    {
        return patientsTreated;
    }

    // Getter for lives if needed
    public int GetLives()
    {
        return lives;
    }
} 