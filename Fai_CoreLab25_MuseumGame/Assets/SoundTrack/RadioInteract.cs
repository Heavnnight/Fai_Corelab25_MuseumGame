using UnityEngine;

public class RadioInteract : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isOn = false;      

    public void ToggleOn()
    {
        if (!isOn)
        {
            audioSource.Play();
            isOn = true;
        }
    }

    public void ToggleOff()
    {
        if (isOn)
        {
            audioSource.Stop();
            isOn = false;
        }
    }
}
