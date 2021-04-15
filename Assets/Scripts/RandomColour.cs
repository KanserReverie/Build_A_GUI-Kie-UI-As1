using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColour : MonoBehaviour
{

    public Image square;

    public void RandomiseColour()
    {
        float redCol = Random.Range(0.0f, 1.0f);
        float blueCol = Random.Range(0.0f, 1.0f);
        float greenCol = Random.Range(0.0f, 1.0f);
        float transpararentCol = Random.Range(0.0f, 1.0f);

        Color randomCol = new Color(redCol, blueCol, greenCol, transpararentCol);
        square.color = randomCol;
    }

    public void TogleEnable(bool value)             //Turn object on or off based on toggle
    {
        square.gameObject.SetActive(value);
    }

}
