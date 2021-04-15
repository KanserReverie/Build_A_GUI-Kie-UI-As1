using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale > 0.5f)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        ///FOR PAUSEING PSUDOCODE
        /// if you press pause
        /// controls script componnents
        /// else if unpause
        /// then controls script enable 
        /// GetComponent<Pause>().enable = false;
        /// 

        // COULD Time.timeScale = 0.05; 
    }
}
