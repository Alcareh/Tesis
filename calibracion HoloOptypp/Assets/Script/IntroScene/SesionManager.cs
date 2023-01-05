using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesionManager : MonoBehaviour
{
    [Header("Daticos")] 
    public bool Sesion;
    public static SesionManager inst;
    public string _id;
    public string nombre;

    
    
    private void Awake()
    {
        if (SesionManager.inst == null)
        {
            SesionManager.inst=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
        
    }

}