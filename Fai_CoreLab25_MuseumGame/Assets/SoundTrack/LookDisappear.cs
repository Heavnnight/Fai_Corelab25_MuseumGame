using UnityEngine;

public class LookDisappear : MonoBehaviour
{
    public Camera playerCam;       
    public float triggerAngle = 8f;  
    public float lookTime = 0.2f; 

    float timer = 0f;

    void Update()
    {
        if (playerCam == null) return;

       
        Vector3 forward = playerCam.transform.forward;

        
        Vector3 toObject = (transform.position - playerCam.transform.position).normalized;

       
        float angle = Vector3.Angle(forward, toObject);

        if (angle < triggerAngle)
        {
            
            timer += Time.deltaTime;

            if (timer >= lookTime)
            {
                gameObject.SetActive(false);  
            }
        }
        else
        {
           
            timer = 0f;
        }
    }
}
