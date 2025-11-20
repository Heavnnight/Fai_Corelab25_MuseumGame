using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light lamp;
    public float minWait = 0.05f;
    public float maxWait = 0.2f;

    public AudioSource flickerSound;  

    bool playerInside = false;        

    void Start()
    {
        if (lamp == null)
            lamp = GetComponent<Light>();

        if (flickerSound == null)
            flickerSound = GetComponent<AudioSource>();

        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            lamp.enabled = !lamp.enabled;

            if (playerInside && flickerSound != null && !flickerSound.isPlaying)
            {
                flickerSound.Play();
            }

            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
