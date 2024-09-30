using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX, transform.rotation.eulerAngles.z);

        Vector3 rotation = new Vector3(camera.transform.localRotation.eulerAngles.x - mouseY, camera.transform.localRotation.eulerAngles.y, camera.transform.localRotation.eulerAngles.z);
;
        camera.transform.localRotation = Quaternion.Euler(rotation);
    }
}
