using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Here were using a singleton pattern for the manager component.


    public static InputManager instance;
    [SerializeField] private InputBuffer[] _inputs;
    public Dictionary<string, InputBuffer> inputs = new Dictionary<string, InputBuffer>();

    //Singleton pattern
    private void Awake()
    {
        if (instance == null) instance = gameObject.GetComponent<InputManager>();

        for (int i = 0; i < _inputs.Length; i++)
        {
            InputBuffer input = _inputs[i];

            inputs.Add(input.axisName, input);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var input in inputs.Values)
        {
            if (input.pressed) input.bufferTime += Time.deltaTime;
            if (input.bufferTime > input.bufferTimeLimit) input.Reset();

            if (Input.GetButtonDown(input.axisName))
            {
                input.pressed = true;
                input.bufferTime = 0;
            }
        }
    }
}
