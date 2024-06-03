using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{
    public float sensitivity;
    public Transform player;

    private float verticalAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * sensitivity;
        float inputY = Input.GetAxis("Mouse Y") * sensitivity;
        // Rotate camera up/down
        verticalAngle = Mathf.Clamp(verticalAngle - inputY, -90f, 90f);
        transform.localEulerAngles = Vector3.right * verticalAngle;

        // Rotate player left/right
        player.Rotate(Vector3.up, inputX);
    }
}
