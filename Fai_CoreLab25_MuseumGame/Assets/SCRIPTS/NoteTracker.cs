using UnityEngine;

public class NoteTracker : MonoBehaviour
{
    public static NoteTracker Instance;

    public int totalNotes = 5;     
    public int notesRead = 0;     
    public GameObject exitBlocker; 

    void Awake()
    {
        Instance = this;
    }

    public void RegisterNote()
    {
        notesRead++;
        Debug.Log("Notes read: " + notesRead);

        if (notesRead >= totalNotes && exitBlocker != null)
        {
            exitBlocker.SetActive(false);
        }
    }
}
