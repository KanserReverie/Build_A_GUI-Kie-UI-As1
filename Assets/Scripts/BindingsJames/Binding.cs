using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// BINDING DOES NOT INHERET FROM MONO
public class Binding
{ 
    // publicly gets and shows that 
    public string Name { get { return name; } }

    public KeyCode Value {  get { return value; } }

    public string ValueDisplay { get { return BindingUtils.TranslateKeycode(value); } }

    [SerializeField] private string name;
    [SerializeField] private KeyCode value;

    public Binding(string _name, KeyCode _defaultValue)
    {
        name = _name;
        value = _defaultValue;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(name, (int)value);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        value = (KeyCode)PlayerPrefs.GetInt(name, (int)value);
    }

    public void Rebind(KeyCode _new)
    {
        value = _new;
        Save();
    }

    public bool Pressed()
    {
        return Input.GetKeyDown(value);
    }

    // Returns if being held down.
    public bool Held()
    {
        return Input.GetKey(value);
    }
    public bool Release()
    {
        return Input.GetKeyUp(value);
    }
}

