using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    ComponentBase[] components;
    
    void Start()
    {
        UpdateCompomentsList();
    }

    public void UpdateCompomentsList()
    {
        components = GetComponentsInChildren<ComponentBase>();
    }

    public ComponentBase Component<T>() where T : class
    {
        foreach (var item in components)
        {
            if (item.GetType() == typeof(T))
                return item;
        }

        return null;
    }

    public ComponentBase ComponentAssignable<T>() where T : class
    {
        foreach (var item in components)
        {
            if (typeof(T).IsAssignableFrom(item.GetType()))
                return item;
        }

        return null;
    }
}
