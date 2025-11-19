using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycastInteract : MonoBehaviour
{
    public Camera cam;            
    public float range = 3f;     
    public Image crosshair;   

    Color normalColor = Color.white;
    Color interactColor = Color.red;

    void Update()
    {
        crosshair.color = normalColor;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            RadioInteract radio = hit.collider.GetComponent<RadioInteract>();

            if (radio != null)
            {
                crosshair.color = interactColor;

                if (Input.GetMouseButtonDown(0))
                {
                    radio.ToggleOn();
                }

                if (Input.GetMouseButtonDown(1))
                {
                    radio.ToggleOff();
                }
            }
        }
    }
}
