using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T>: MonoBehaviour where T:MonoBehaviour
{
    // Start is called before the first frame update
    protected static T instance;
    public static T Instance
    {
        get
        {
            instance = (T)FindObjectOfType(typeof(T));
            if (instance == null)
            {
                Debug.LogError("An instance of " + typeof(T) + " is needed in the scene , but there is none.");
            }
            return instance;
        }
    }
}
