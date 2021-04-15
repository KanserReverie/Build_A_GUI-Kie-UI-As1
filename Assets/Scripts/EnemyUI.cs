using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Gets Cam
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // healthbar follows camera
        transform.rotation = cam.transform.rotation;
    }
}
