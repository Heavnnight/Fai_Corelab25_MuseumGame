using UnityEngine;

public class RoomEntrance : MonoBehaviour
{
    public GameObject exitBlocker;  
    public GameObject messagePanel;  

    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        if (exitBlocker != null)
            exitBlocker.SetActive(true);

        if (messagePanel != null)
        {
            messagePanel.SetActive(true);
            Invoke(nameof(HideMessage), 3f);
        }
    }

    void HideMessage()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}
