using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 5f)] float interactDistance;
    [SerializeField] LayerMask triggerLayer;
    [SerializeField] GameObject interactIcon;
    public bool hideIcon;

    void Update()
    {

        Camera camera = Camera.main;

        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, ~triggerLayer))
        {
            Interactable interactable = hit.transform.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (interactable is not DoorInteractable) interactIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            interactIcon.SetActive(false);
        }

        if (hideIcon) interactIcon.SetActive(false);
    }
}
