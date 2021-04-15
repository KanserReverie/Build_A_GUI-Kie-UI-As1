using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindingManager : MonoBehaviour
{
    // This makes it a singleton part 1/2
    private static BindingManager instance = null;
    
    //used to actually access the bindings by their names when handing input
    private Dictionary<string, Binding> bindingMap = new Dictionary<string, Binding>();
    
    // contains all bindings for easy interation over all  over them
    private List<Binding> bindingsList = new List<Binding>();
    
    [SerializeField] private List<Binding> defaultBindings = new List<Binding>();

    private void Awake()
    {
        // This makes it a singleton part 2/2
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }

        PopulateBindingDictionaries();
        LoadBindings();
    }

    private void PopulateBindingDictionaries()
    {
        // Populate bindings map IF it doesn't have a value already
        foreach(Binding binding in defaultBindings)
        {
            if (bindingMap.ContainsKey(binding.Name))
            {
                continue;
            }

            bindingMap.Add(binding.Name, binding);
            bindingsList.Add(binding);
        }
    }

    private void LoadBindings()
    {
        foreach(Binding binding in bindingsList)
        {
            binding.Load();
        }
    }

    // Returns if held in the KeybindTest.
    public static bool BindingHeld(string _key)
    {
        // We get a binding.
        Binding binding = GetBinding(_key);

        if (binding != null)
        {
            // We have a binding, is it being held down?
            return binding.Held();
        }

        // We dont have a binding.
        Debug.LogWarning("No binding matches the passed key: " + _key);
        return false;
    }

    public static Binding GetBinding(string _key)
    {
        if(instance.bindingMap.ContainsKey(_key))
        {
            return instance.bindingMap[_key];
        }

        return null;
    }
    
    public static void Rebind(string _name, KeyCode _value)
    {
        Binding binding = GetBinding(_name);

        if(binding != null)
        {
            binding.Rebind(_value);
        }
    }
}
