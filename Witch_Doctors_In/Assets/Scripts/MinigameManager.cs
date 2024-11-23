using UnityEngine;
using UnityEngine.SceneManagement; // Import this to handle scene transitions

public class MinigameManager : MonoBehaviour
{
    public GameObject minigameSelectionPanel; // Reference to the Minigame Selection Screen
    public GameObject tempCheckPanel;        // Reference to the Temp Check Minigame Panel
    public GameObject vitalCheckPanel;       // Reference to the Vital Check Minigame Panel

    public void PlaySpellCheck()
    {
        Debug.Log("Playing Spell Check Minigame...");
        // Add functionality to show Spell Check Panel if necessary
        DisableButton("SpellCheckButton");
    }

    public void PlayTempCheck()
    {
        Debug.Log("Playing Temp Check Minigame...");
        // Switch to Temp Check Minigame
        minigameSelectionPanel.SetActive(false);
        tempCheckPanel.SetActive(true);

        DisableButton("TempCheckButton");
    }

    public void PlayVitalCheck()
    {
        Debug.Log("Playing Vital Check Minigame...");
        // Hide the minigame selection screen
        minigameSelectionPanel.SetActive(false);

        // Show the Vital Check minigame panel
        vitalCheckPanel.SetActive(true);
    }

    public void BackToSelectionScreen()
    {
        Debug.Log("Returning to Minigame Selection Screen...");
        // Hide all minigame panels and return to selection screen
        tempCheckPanel.SetActive(false);
        minigameSelectionPanel.SetActive(true);
    }

    public void VitalBackToSelectionScreen()
    {
        Debug.Log("Returning to Minigame Selection Screen...");
        // Hide all other panels and return to the selection screen
        vitalCheckPanel.SetActive(false); // Hide the Vital Check Panel
        minigameSelectionPanel.SetActive(true); // Show the selection panel
    }

    // New Method: Go to the Potion Brewing Page
    public void GoToPotionBrewingPage()
    {
        Debug.Log("Navigating to Potion Brewing Page...");
        SceneManager.LoadScene("PotionBrewingPage"); // Replace with your actual scene name
    }

    private void DisableButton(string buttonName)
    {
        GameObject button = GameObject.Find(buttonName);
        if (button != null)
        {
            button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }
}
