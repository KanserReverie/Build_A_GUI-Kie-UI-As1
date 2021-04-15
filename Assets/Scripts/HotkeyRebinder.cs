using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotkeyRebinder : MonoBehaviour
{

    // Dictionary is static and used everywhere
    [SerializeField] public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();


    // struct is a mini Class but only holds some variables
    [System.Serializable]
    public struct KeyUISetup
    {
        public string keyName;
        public TextMeshProUGUI keyDisplayText;
        public string defaultKey;
    }

    public KeyUISetup[] baseSetup;
    public GameObject currentButton;
    public Color32 changedKey = Color.yellow;
    public Color32 selectedKey = Color.blue;

    private void Awake()
    {
        for (int i = 0; i < baseSetup.Length; i++)
        {
            // Make sure they are equal
            baseSetup[i].keyDisplayText.transform.parent.name = baseSetup[i].keyName;

            // Gets next key and changes
            keys.Add(baseSetup[i].keyName, (KeyCode)System.Enum.Parse(typeof(KeyCode),
                PlayerPrefs.GetString(baseSetup[i].keyName, baseSetup[i].defaultKey)));

            // Displays change
            baseSetup[i].keyDisplayText.text = keys[baseSetup[i].keyName].ToString();
        }
    }

    public void SaveKeys()
    {
        // Gets all the keys and updates the Dictionary
        foreach (var thisKey in keys)
        {
            PlayerPrefs.SetString(thisKey.Key, thisKey.Value.ToString());
        }

        // Save in system
        PlayerPrefs.Save();

        // When we save keys it change them to white
        WhiteButtons();
    }

    public void WhiteButtons()
    {
        // Makes all buttons turn white

        for (int i = 0; i < baseSetup.Length; i++)
        {
            string newKey = keys[baseSetup[i].keyName].ToString();

            newKey = PlayerPrefs.GetString(baseSetup[i].keyName);

            baseSetup[i].keyDisplayText.transform.parent.GetComponent<Image>().color = Color.white;
        }
    }
    public void ChangeKey(GameObject clickedButton)
    {
        // This current button pressed
        currentButton = clickedButton;

        // Incase something weird calls it and it crashes
        if (clickedButton != null)
        {
            clickedButton.GetComponent<Image>().color = selectedKey;
        }
    }

    private void OnGUI()
    {
        // Sets new Key
        string newKey = "";
        Event e = Event.current;

        // Skips if 
        if (currentButton == null)
            return;

        // checks if event is key instead of mouse
        if (e.isKey)
        {
            newKey = e.keyCode.ToString();
        }

        // Shift needs to be differentiated 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "LeftShift";
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            newKey = "RightShift";
        }

        //Now just to confirm if we have made an input... can't leave it null by accident
        if (newKey != "")
        {
            //Changes our key in the Dictionary to the key we just pressed.
            keys[currentButton.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);

            //Change the display text to match
            currentButton.GetComponentInChildren<TextMeshProUGUI>().text = newKey;

            //Change colour to display changed key
            currentButton.GetComponent<Image>().color = changedKey;

            //Reset to avoid errors with future rebinds.
            currentButton = null;
        }
    }
}