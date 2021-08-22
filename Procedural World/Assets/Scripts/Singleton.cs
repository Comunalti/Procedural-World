using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance.Equals(null))
            {
                instance = GameObject.FindObjectOfType<T>();
                if (instance.Equals(null)) Debug.LogError($"No Singleton of type {typeof(T)}");
            }
            return instance;
        }
    }
    
}