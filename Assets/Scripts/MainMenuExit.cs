using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuExit : MonoBehaviour
{
    public void closeMenu()
    {
        Destroy(this, 1);
    }
}
