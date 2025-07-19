using UnityEngine;
using UnityEngine.Windows.Speech;
using TMPro;
using System.Collections;

public class VoiceDisassemble : MonoBehaviour
{
    public TMP_Text displayText;
    public TMP_Text referenceText;

    public GameObject p1, p2, p3, p4;

    public GameObject cmosObject;
    public AudioSource cmosAudioSource;

    public GameObject processorObject;
    public AudioSource processorAudioSource;

    public GameObject memoryObject;
    public AudioSource memoryAudioSource;

    private DictationRecognizer dictationRecognizer;
    private GameObject[] objects;
    private Vector3[] originalPositions;
    private Color[] originalColors;

    void Start()
    {
        Debug.Log("Starting DictationRecognizer...");

        objects = new GameObject[] { p1, p2, p3, p4 };
        originalPositions = new Vector3[objects.Length];
        originalColors = new Color[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                originalPositions[i] = objects[i].transform.position;
                Renderer rend = objects[i].GetComponent<Renderer>();
                if (rend != null)
                {
                    originalColors[i] = rend.material.color;
                }
            }
        }

        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.Log("Recognized: " + text);
            displayText.text += "\n" + text;

            string lowerText = text.ToLower();

            if (lowerText.Contains("disassemble"))
            {
                Debug.Log("Disassemble command detected!");
                MoveObjectsAndChangeColor();
            }
            else if (lowerText.Contains("assemble"))
            {
                Debug.Log("Assemble command detected!");
                ResetObjects();
            }
            else if (lowerText.Contains("cmos"))
            {
                Debug.Log("CMOS command detected!");
                ActivateWithText(cmosObject, cmosAudioSource,
                    "CMOS (Complementary Metal-Oxide-Semiconductor) is used in processors and memory chips for low-power operation and fast switching.");
            }
            else if (lowerText.Contains("processor"))
            {
                Debug.Log("Processor command detected!");
                ActivateWithText(processorObject, processorAudioSource,
                    "The microprocessor is a multipurpose, clock-driven, register-based, digital integrated circuit that accepts binary data as input, processes it according to instructions stored in its memory, and provides results (also in binary form) as output.");
            }
            else if (lowerText.Contains("memory"))
            {
                Debug.Log("Memory command detected!");
                ActivateWithText(memoryObject, memoryAudioSource,
                    "Memory is the faculty of the mind by which data or information is encoded, stored, and retrieved when needed. It is the retention of information over time for the purpose of influencing future action.");
            }
        };

        dictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.Log("Hypothesis: " + text);
        };

        dictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
            {
                Debug.LogError("Dictation completed unexpectedly: " + completionCause);
            }
        };

        dictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogError("Dictation error: " + error);
        };

        dictationRecognizer.Start();
        Debug.Log("DictationRecognizer started.");
    }

    void MoveObjectsAndChangeColor()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                Vector3 newPos = objects[i].transform.position;
                newPos.y += 0.5f;
                objects[i].transform.position = newPos;

                Renderer rend = objects[i].GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = Random.ColorHSV();
                }
            }
        }
    }

    void ResetObjects()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                objects[i].transform.position = originalPositions[i];

                Renderer rend = objects[i].GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = originalColors[i];
                }
            }
        }
    }

    void ActivateWithText(GameObject targetObj, AudioSource audioSrc, string explanation)
    {
        if (targetObj != null && audioSrc != null && audioSrc.clip != null)
        {
            targetObj.SetActive(true);
            audioSrc.Play();

            if (referenceText != null)
            {
                referenceText.text = explanation;
            }

            // Call clear after audio is done
            Invoke(nameof(ClearObjectAndText), audioSrc.clip.length);
        }
    }

    void ClearObjectAndText()
    {
        if (cmosObject != null) cmosObject.SetActive(false);
        if (processorObject != null) processorObject.SetActive(false);
        if (memoryObject != null) memoryObject.SetActive(false);

        if (referenceText != null)
            referenceText.text = "";

        // Reset positions/colors of parts
       // ResetObjects();

        // Restart recognizer after short delay
        Invoke(nameof(RestartRecognizer), 1f);  // wait 1 second
    }

    void RestartRecognizer()
    {
        if (dictationRecognizer != null)
        {
            if (dictationRecognizer.Status == SpeechSystemStatus.Running)
            {
                dictationRecognizer.Stop();
            }

            dictationRecognizer.Start();
            Debug.Log("DictationRecognizer restarted.");
        }
    }

    void OnDestroy()
    {
        if (dictationRecognizer != null)
        {
            if (dictationRecognizer.Status == SpeechSystemStatus.Running)
            {
                dictationRecognizer.Stop();
            }
            dictationRecognizer.Dispose();
        }
    }
}
