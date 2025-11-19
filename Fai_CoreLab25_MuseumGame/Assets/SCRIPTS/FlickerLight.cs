using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light lamp;
    public float minWait = 0.05f;
    public float maxWait = 0.2f;

    void Start()
    {
        if (lamp == null)
            lamp = GetComponent<Light>();

        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            lamp.enabled = !lamp.enabled;
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        }
    }
}
