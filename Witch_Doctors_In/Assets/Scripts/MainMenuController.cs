using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // Replace with your main gameplay scene name.
    }

    public void ShowCredits()
    {
        Debug.Log("Credits screen coming soon!"); // Placeholder for now.
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed!"); // Debug message for the editor.
    }
}
