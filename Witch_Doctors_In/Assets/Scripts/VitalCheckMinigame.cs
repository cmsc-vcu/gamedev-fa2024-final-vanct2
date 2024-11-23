using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class VitalCheckMinigame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI resultText;    // Text to display the result
    public AudioSource audioSource;      // Audio source for heartbeat sounds
    public AudioClip growlingHeartbeat;  // Audio for Fickle Heartbeat
    public AudioClip normalHeartbeat;    // Audio for normal heartbeat

    private PatientEntry patientEntry;

    void Start()
    {
        // Find the PatientEntry script in the scene
        patientEntry = FindObjectOfType<PatientEntry>();
        if (patientEntry == null)
        {
            Debug.LogError("PatientEntry script not found in the scene!");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned in the Inspector.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered the hotspot.");
        PlayHeartbeat();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited the hotspot.");
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            Debug.Log("Heartbeat audio stopped.");
        }
    }

    private void PlayHeartbeat()
    {
        if (patientEntry == null) return;

        string patientSpecies = patientEntry.GetMonsterSpecies();
        Debug.Log($"Patient species: {patientSpecies}");

        if (patientSpecies.ToLower() == "vampire")
        {
            audioSource.clip = growlingHeartbeat;
            resultText.text = "Fickle Heartbeat!";
            resultText.color = Color.red;

        }
        else
        {
            audioSource.clip = normalHeartbeat;
            resultText.text = "Heartbeat Normal.";
            resultText.color = Color.green;
        }

        audioSource.Play();
        Debug.Log("Heartbeat audio started.");
    }
}
