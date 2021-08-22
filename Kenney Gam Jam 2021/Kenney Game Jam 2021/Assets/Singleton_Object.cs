using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_Object : MonoBehaviour
{
    private static Singleton_Object _instance;

    public static Singleton_Object Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
