using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleScreenCanvas;  // Reference to the title screen
    public GameObject gameSceneCanvas;   // Reference to the game canvas (e.g., PatientEntryCanvas)
    public GameObject instructionsPopup; // Reference to the instructions popup

    public void OnPlayButtonPressed()
    {
        titleScreenCanvas.SetActive(false);  // Hide the title screen
        instructionsPopup.SetActive(true);   // Show the instructions popup
    }
    public void OnCloseInstructionsPressed()
{
    instructionsPopup.SetActive(false);  // Hide the instructions popup
    gameSceneCanvas.SetActive(true);    // Show the main game canvas
}

}
