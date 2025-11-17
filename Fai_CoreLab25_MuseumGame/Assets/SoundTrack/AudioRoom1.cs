using UnityEngine;

public class AudioRoom1 : MonoBehaviour
{
    [Header("Who can trigger")]
    public string playerTag = "Player";

    [Header("Audio")]
    public AudioSource audioSource;
    public bool playOnce = false; 
    bool hasPlayed = false;

    void Reset()
    {
        var col = GetComponent<Collider>();
        if (col) col.isTrigger = true;
        if (!audioSource) audioSource = GetComponent<AudioSource>();
        if (audioSource) audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag) || audioSource == null) return;

        if (playOnce)
        {
            if (!hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
        }
        else
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag) || audioSource == null) return;

        if (!playOnce && audioSource.isPlaying)
            audioSource.Stop();
    }
}