using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton main;
    public FirstPersonController controller;
    public RotateTowardsMouse mouseLook;
    void Awake()
    {
        if (main == null)
        {
            main = gameObject.GetComponent<PlayerSingleton>();
        }
        controller = gameObject.GetComponent<FirstPersonController>();
        mouseLook = gameObject.GetComponent<RotateTowardsMouse>();
    }
}
