using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseXandY;
    public float speed;
    private Rigidbody rb;
    public float gravity = -9.8f;
    public float sensitivity = 9.0f;

    public float maxVert = 45f;
    public float minVert = -45.0f;

    private float _rotationX = 0;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        #region MOVEMENT
        float xAxis = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        float zAxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 movement = new Vector3(xAxis, rb.velocity.y, zAxis);
        movement = transform.TransformDirection(movement);
        movement.y = 0;
        //Debug.Log(movement);
        rb.velocity = movement;
        #endregion MOVEMENT
        #region MouseRotation
        if (axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        else if(axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        #endregion
        
        #region JUMP
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        #endregion
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * 100f);
    }
}
