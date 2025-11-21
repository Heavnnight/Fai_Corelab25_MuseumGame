using UnityEngine;
using System.Collections;

public class RadioScareEvent : MonoBehaviour
{
    public RadioInteract radio;
    public GameObject zombie;
    public float scareDelay = 57f;  

    bool scareTriggered = false;

    void Update()
    {
        if (radio.isOn && !scareTriggered)
        {
            scareTriggered = true;
            StartCoroutine(ScareRoutine());
        }
    }

    IEnumerator ScareRoutine()
    {
        
        yield return new WaitForSeconds(scareDelay);

        if (zombie != null)
        {
            zombie.SetActive(true);  
        }
    }
}
