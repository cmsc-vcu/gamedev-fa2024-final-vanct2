using UnityEngine;

public class PotionBrewingManager : MonoBehaviour
{
    public GameObject minigameScreen;   // Reference to the Minigame UI
    public GameObject potionBrewingMenu; // Reference to the Potion Brewing UI

    public void ShowPotionBrewingMenu()
    {
        // Hide the Minigame screen
        minigameScreen.SetActive(false);

        // Show the Potion Brewing Menu
        potionBrewingMenu.SetActive(true);

        Debug.Log("Switched to Potion Brewing Menu.");
    }
}
