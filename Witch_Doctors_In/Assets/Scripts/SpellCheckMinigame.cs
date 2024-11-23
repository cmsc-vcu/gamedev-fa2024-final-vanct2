using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCheckMinigame : MonoBehaviour
{
    public Slider spellMeterSlider; // Assign in the Inspector
    public PatientEntry patientEntry; // Reference to PatientEntry for race
    public GameObject spellCheckCanvas; // Reference to the Spell Check Canvas
    public GameObject minigameSelectionCanvas; // Reference to the Minigame Selection Canvas
    public Button returnButton; // Reference to the Return Button
    public TextMeshProUGUI dialogueText; // Reference to the TextMeshPro dialogue box

    private bool isCharging = false; // Whether the button is being held down

    void Start()
    {
        // Ensure the Return Button and dialogue are hidden at the start
        returnButton.gameObject.SetActive(false);
        dialogueText.text = ""; // Clear dialogue text at start

        // Add a listener for the Return Button
        returnButton.onClick.AddListener(ReturnToSelection);
    }

    void Update()
    {
        // Continuously charge the meter while the button is being held down
        if (isCharging && spellMeterSlider.value < spellMeterSlider.maxValue)
        {
            ChargeMeter();
        }
    }

    public void StartCharging()
    {
        isCharging = true;
    }

    public void StopCharging()
    {
        isCharging = false;

        // Check if the slider is full when charging stops
        if (spellMeterSlider.value >= spellMeterSlider.maxValue)
        {
            FinishMinigame();
        }
    }

    void ChargeMeter()
    {
        spellMeterSlider.value += Time.deltaTime * 50; // Adjust charge speed as needed
    }

    void FinishMinigame()
    {
        string monsterSpecies = patientEntry.GetMonsterSpecies();
        string spellResult;

        // Determine if the spell is strong or weak based on the monster's species
        if (monsterSpecies == "Vampire" || monsterSpecies == "Demon")
        {
            spellResult = "Strong Spell!";
        }
        else if (monsterSpecies == "Orc")
        {
            spellResult = "Weak Spell!";
        }
        else
        {
            spellResult = "Unknown Spell Strength";
        }

        // Display the result in the dialogue box
        dialogueText.text = $"The spell is a {spellResult}";

        Debug.Log($"The spell was cast: {spellResult}");

        // Show the Return Button after finishing
        returnButton.gameObject.SetActive(true);

        // Stop further charging
        isCharging = false;
    }

    void ReturnToSelection()
    {
        // Hide the Spell Check Canvas
        spellCheckCanvas.SetActive(false);

        // Show the Minigame Selection Canvas
        minigameSelectionCanvas.SetActive(true);

        // Reset the minigame
        ResetMinigame();
    }

    void ResetMinigame()
    {
        spellMeterSlider.value = 0;
        isCharging = false; // Stop charging
        returnButton.gameObject.SetActive(false); // Hide the Return Button
        dialogueText.text = ""; // Clear the dialogue text
        Debug.Log("Minigame Reset!");
    }
}
