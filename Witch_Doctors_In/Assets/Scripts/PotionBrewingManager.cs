using UnityEngine;

public class PotionBrewingManager : MonoBehaviour
{
    public GameObject potionBrewingMenu; // Reference to the Potion Brewing UI
    public GameObject minigameScreen;   // Reference to the Minigame Selection UI (if applicable)
    public bool potionSuccess = false; // Track if the potion brewing was successful

    /// <summary>
    /// Displays the potion brewing menu and hides the minigame screen.
    /// </summary>
    public void ShowPotionBrewingMenu()
    {
        if (minigameScreen != null)
        {
            minigameScreen.SetActive(false); // Hide the Minigame screen
        }

        potionBrewingMenu.SetActive(true); // Show the Potion Brewing Menu
        Debug.Log("Switched to Potion Brewing Menu.");
    }

    /// <summary>
    /// Resets the potion brewing state and prepares for the next patient.
    /// </summary>
    public void ResetPotionBrewing()
    {
        potionSuccess = false; // Reset success state

        // Optionally reset any UI or interactive elements specific to the potion brewing phase
        if (potionBrewingMenu != null)
        {
            potionBrewingMenu.SetActive(true); // Ensure the menu is reactivated if needed
        }

        Debug.Log("Potion brewing state reset for the next patient.");
    }
}