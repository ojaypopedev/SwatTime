using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerLook : MonoBehaviour
{

    [SerializeField] private float speed = 3f;

    Camera cam;

    PlayerInput controls;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // controls.Player.Shoot.performed += Move();
        SetupControls();

    }

    void SetupControls()
    {
        controls = GetComponent<PlayerInput>();
        InputActionMap master = controls.currentActionMap;


    }

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        cam = GetComponentInChildren<Camera>();
    }

    public void testPrint(InputAction.CallbackContext context)
    {
        print("Hello I have been Pressed");
    }

    // Update is called once per frame
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    void Update()
    {

        if (FindObjectOfType<GameManager>().play)
        {

            Debug.Log(cam.transform.rotation.eulerAngles);
            yaw -= speedH * -Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, -60, 60);

            transform.eulerAngles = new Vector3(0, yaw, 0.0f);
            cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

            DoMovement();
        }
    }


    void DoMovement()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Vector3 direction3D = new Vector3(direction.x, 0, direction.y);

        transform.Translate(inputDir * speed * Time.deltaTime);

        Debug.DrawRay(transform.position, transform.forward * 4);
    }



}
