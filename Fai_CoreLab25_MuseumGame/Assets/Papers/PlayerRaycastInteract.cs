using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycastInteract : MonoBehaviour
{
    public Camera cam;
    public float range = 15f;
    public Image crosshair;

    Color normalColor = Color.white;
    Color interactColor = Color.red;

    NoteController note;
    RadioInteract radio;

    void Update()
    {
        crosshair.color = normalColor;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            // 1) check note
            note = hit.collider.GetComponentInParent<NoteController>();
            if (note != null)
            {
                crosshair.color = interactColor;

                if (Input.GetMouseButtonDown(0))
                {
                    note.ShowNote();
                }
                return;
            }

            // 2) check radio
            radio = hit.collider.GetComponent<RadioInteract>();
            if (radio != null)
            {
                crosshair.color = interactColor;

                if (Input.GetMouseButtonDown(0))
                    radio.ToggleOn();

                if (Input.GetMouseButtonDown(1))
                    radio.ToggleOff();

                return;
            }
        }
    }
}
