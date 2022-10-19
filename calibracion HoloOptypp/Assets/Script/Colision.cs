using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour {
    public bool IsColliding=false;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Circulo")
        {
            IsColliding = true;
            Debug.Log("Objetivo alcanzado, tocando: " + collision.gameObject.tag);
        }
        if (collision.gameObject.tag == "PlanoSave")
        {
            IsColliding = true;
            Debug.Log("Estás en un buen punto, plano: " + collision.gameObject.name);
        }
        if (collision.gameObject.tag == "PlanoPeligro")
        {
            IsColliding = true;
            Debug.Log("Auch!, estás usando mucha fuerza, plano: " + collision.gameObject.name);
        }
    }
}
