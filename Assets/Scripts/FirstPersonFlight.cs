using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonFlight : MonoBehaviour
{
    Transform form;
    Transform cam;
    public float moveSpeed = 3;
    public float mouseSpeed = 3;

    float yaw;
    float pitch;

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0);

        // Lock mouse to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame



    // Old Movement
    void Update()
    {
        if (Input.GetKey(HotkeyRebinder.keys["Forwards"]))
            transform.Translate(cam.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(HotkeyRebinder.keys["Backwards"]))
            transform.Translate(-cam.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(HotkeyRebinder.keys["Left"]))
            transform.Translate(-cam.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(HotkeyRebinder.keys["Right"]))
            transform.Translate(cam.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(HotkeyRebinder.keys["Up"]))
            transform.Translate(cam.up * moveSpeed * Time.deltaTime);
        if (Input.GetKey(HotkeyRebinder.keys["Down"]))
            transform.Translate(-cam.up * moveSpeed * Time.deltaTime);

        yaw += Input.GetAxisRaw("Mouse X") * mouseSpeed;

        pitch -= Input.GetAxisRaw("Mouse Y") * mouseSpeed;

        cam.eulerAngles = new Vector3(pitch, yaw, 0);


        // Old movement
        // up and down cammera movement
        /*
        float hMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vMove = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.Translate(cam.forward * vMove * moveSpeed);
        transform.Translate(cam.right * hMove * moveSpeed);
                
        if (Input.GetButton("Jump"))
        {
            transform.Translate(cam.up * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(-cam.up * moveSpeed * Time.deltaTime);
        }
        */

        // Up and down left and right cammera
    }
}
