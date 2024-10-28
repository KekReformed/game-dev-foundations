using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 2f)] float interactDistance;
    [SerializeField] LayerMask triggerLayer;
    void Update()
    {
        Camera camera = Camera.main;

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactDistance, ~triggerLayer))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
