using UnityEngine;

[System.Serializable]
public class InputBuffer
{
    public string axisName;

    [HideInInspector]
    public bool pressed;

    [Range(0.01f,0.5f)]
    public float bufferTimeLimit;

    [HideInInspector]
    public float bufferTime = 0;

    public void Reset()
    {
        bufferTime = 0;
        pressed = false;
    }
}
