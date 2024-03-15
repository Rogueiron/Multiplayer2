using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;

    public Transform orientation;

    float horizontalInput;
    float VerticalInput;

    [Header("GroundCheck")]

    public float groundDrag;
    public float playerHeight;
    public LayerMask whatisGround;
    bool grounded;

    Vector3 moveDirection;

    Rigidbody rb;

    private float cameraYOffset = 0.4f;
    private Camera playerCamera;
    float rotationX = 0;

    private Alteruna.Avatar avatar;
    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Alteruna.Avatar>();
        if(!avatar.IsMe)
        {
            return;
        }

        playerCamera = Camera.main;
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYOffset, transform.position.z);
        playerCamera.transform.SetParent(transform);
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * .5f + 0.2f, whatisGround);
        Debug.Log(grounded);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 5f;
        }

        Inputs();

        if(playerCamera != null)
        {
            rotationX += -Input.GetAxis("Mouse Y") * 2;
            rotationX = Mathf.Clamp(rotationX, -45, 45);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * 2, 0);
        }
    }

    private void Inputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {

        moveDirection = playerCamera.transform.forward * VerticalInput + playerCamera.transform.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

    }
}
