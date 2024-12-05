using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonController : MonoBehaviour
{
    public CharacterController controller;
    public float groundAcceleration;
    public float airAcceleration;
    public float gravity;
    public float maxSpeed;
    public float maxFallSpeed;
    public float jumpHeight;
    public Vector3 inputVelocity = Vector3.zero;
    public Vector3 move = Vector3.zero;

    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask groundLayer;

    public GameObject endScreen;
    bool _freeze;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //End Sequence for good ending
        if (transform.position.y < -30)
        {
            endScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F)) SceneManager.LoadScene(0);
            Freeze();
            PlayerSingleton.main.mouseLook.Freeze();
            Timer.instance.currentTime = 99999f;
        }

        if (_freeze) return;
        //Grounded check, used for jumping and gravity, make sure that if we are moving up that we can't be grounded otherwise we'll get stuck in the floor
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer) && move.y <= 0;

        //Acceleration & deceleration
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (grounded)
            {
                inputVelocity.x += groundAcceleration * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
                if (!audio.isPlaying) audio.Play();
            }
            else
            {
                inputVelocity.x += airAcceleration * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            }
            //Apply the rotation to the velocity
        }
        else if (grounded)
        {
            //Make sure we don't overshoot when doing deceleration 
            if (Mathf.Sign(move.x - groundAcceleration * Mathf.Sign(move.x)) != Mathf.Sign(move.x))
            {
                move.x = 0f;
            }
            else
            {
                move.x -= groundAcceleration * Mathf.Sign(move.x);
            }

            inputVelocity.x = 0;
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (grounded)
            {
                inputVelocity.z += groundAcceleration * Mathf.Sign(Input.GetAxisRaw("Vertical"));
                if (!audio.isPlaying) audio.Play();
            }
            else
            {
                inputVelocity.z += airAcceleration * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            }
        }
        else if (grounded)
        {
            //Make sure we don't overshoot when doing deceleration 
            if (Mathf.Sign(move.z - groundAcceleration * Mathf.Sign(move.z)) != Mathf.Sign(move.z))
            {
                move.z = 0f;
            }
            else
            {
                move.z -= groundAcceleration * Mathf.Sign(move.z);
            }

            inputVelocity.z = 0;
        }


        if (!grounded)
        {
            move.y += gravity * -9.81f * Time.deltaTime;
            audio.Stop();
        }

        if (grounded)
        {
            move.y = 0f;
        }

        if (InputManager.instance.inputs["Jump"].pressed && grounded)
        {
            move.y = jumpHeight;
        }

        inputVelocity = clampVector(inputVelocity);

        //Don't let the input velocity mess with our y vector, this could be done without a temp variable of course but it looks significantly worse
        float tempMoveY = move.y;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            move = transform.rotation * inputVelocity;
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            audio.Stop();
        }

        move.y = tempMoveY;

        controller.Move(move * Time.deltaTime);
    }

    public void Freeze()
    {
        _freeze = true;
    }

    public void Unfreeze()
    {
        _freeze = false;
    }

    Vector3 clampVector(Vector3 vectorToClamp)
    {
        Vector3 tempVector;
        tempVector.x = Mathf.Clamp(vectorToClamp.x, -maxSpeed, maxSpeed);
        tempVector.y = Mathf.Clamp(vectorToClamp.y, -maxFallSpeed, 999);
        tempVector.z = Mathf.Clamp(vectorToClamp.z, -maxSpeed, maxSpeed);

        return tempVector;
    }
}
