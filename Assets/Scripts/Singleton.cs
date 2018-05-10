using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T ms_instance = null;

    public static T Instance
    {
        get
        {
            ms_instance = FindObjectOfType<T>();

            if (ms_instance == null)
            {
                GameObject temp = new GameObject("Singleton " + typeof(T).ToString());
                T instance = temp.AddComponent<T>();
                ms_instance = instance;
            }

            return ms_instance;
        }
    }
}
