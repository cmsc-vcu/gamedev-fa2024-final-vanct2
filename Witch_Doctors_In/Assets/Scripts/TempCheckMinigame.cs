using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempCheckMinigame : MonoBehaviour
{
    public RectTransform thermometer;
    public RectTransform dragBar;
    public RectTransform successArea;
    public TextMeshProUGUI resultText;

    private bool isDragging = false;

    // Reference to the PatientEntry script to get the species
    private PatientEntry patientEntry;

    void Start()
    {
        // Find the PatientEntry script in the scene
        patientEntry = FindObjectOfType<PatientEntry>();
    }

    void Update()
    {
        if (isDragging)
        {
            // Follow the mouse while dragging
            Vector2 mousePosition = Input.mousePosition;
            thermometer.position = new Vector2(
                Mathf.Clamp(mousePosition.x, dragBar.position.x - dragBar.rect.width / 2, dragBar.position.x + dragBar.rect.width / 2),
                thermometer.position.y
            );
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            CheckResult();
        }
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    private void CheckResult()
    {
        // Check if thermometer is within the success area
        if (RectTransformUtility.RectangleContainsScreenPoint(successArea, thermometer.position))
        {
            // Get the patient's species
            string patientSpecies = patientEntry.GetMonsterSpecies();
            Debug.Log($"Patient species: {patientSpecies}");

            // Check the species and display the result
            if (patientSpecies.ToLower() == "demon")
            {
                resultText.text = "Flaming Fever!";
                resultText.color = Color.red; // Optional: Change text color for fever
                Debug.Log("Result: Flaming Fever!");

            }
            else
            {
                resultText.text = "Temperature Normal.";
                resultText.color = Color.green; // Optional: Change text color for normal
                Debug.Log("Result: Temperature Normal.");
            }
        }
        else
        {
            resultText.text = "Temperature Normal.";
            resultText.color = Color.green; // Optional: Change text color for normal
            Debug.Log("Result: Temperature Normal (outside success area).");
        }
    }
}
