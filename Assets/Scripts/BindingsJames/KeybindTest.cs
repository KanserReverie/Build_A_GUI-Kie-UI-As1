using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeybindTest : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void Update()
    {
        // Times by "Time.deltaTime" to be consistant to different frame rates.
        float moveSpeed = speed * Time.deltaTime;
    
        if(BindingManager.BindingHeld("Foward"))
        {
            transform.position += transform.forward * moveSpeed;
        }

        if (BindingManager.BindingHeld("Backward"))
        {
            transform.position += -transform.forward * moveSpeed;
        }

        if (BindingManager.BindingHeld("Left"))
        {
            transform.position += -transform.right * moveSpeed;
        }

        if (BindingManager.BindingHeld("Right"))
        {
            transform.position += transform.right * moveSpeed;
        }
    }
}
