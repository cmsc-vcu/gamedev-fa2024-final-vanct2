using UnityEngine;
using TMPro;

public class PatientEntry : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // TextMeshPro for dialogue
    private string monsterSpecies;
    private string groupASymptom;

    public PotionVial potionVial;         // Reference to the PotionVial script

    void Start()
    {
        ShowPatient();
    }

    void ShowPatient()
    {
        // Randomly select a species (orc, vampire, demon)
        string[] species = { "Orc", "Vampire", "Demon" };
        monsterSpecies = species[Random.Range(0, species.Length)];

        // Randomly select a Group A symptom
        string[] groupASymptoms = { "Runny nose", "Monster cough", "Sore bones" };
        groupASymptom = groupASymptoms[Random.Range(0, groupASymptoms.Length)];

        // Display the introduction dialogue
        dialogueText.text = $"I am a {monsterSpecies} and I have a {groupASymptom}. Can you help me?";

        // Pass the species to the PotionVial to set correct ingredients
        potionVial.SetCorrectIngredients(monsterSpecies);
    }

    public string GetMonsterSpecies()
    {
        return monsterSpecies;
    }

    public string GetGroupASymptom()
    {
        return groupASymptom;
    }
}
