using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverOrigenVuforia : MonoBehaviour
{
    private const int V = -1;
    public GameObject Vuforia;
    public GameObject RigidBodyOpti;
    public GameObject Camara;
    //public GameObject XR;
    private Vector3 OffSet;
    private Vector3 mover;
    public float Posicion = 0.05f;
    public float Rotacion = 0.1f;
    public float Scale = 0.1f;

    


    // Update is called once per frame
    void Update()
    {
        // mover la camara cerca del origen
        if (Input.GetKey(KeyCode.M))
        {
            //OffSet = Camara.transform.position;
            //mover = (Vuforia.transform.position - RigidBodyOpti.transform.position);
            //XR.transform.position = V * (OffSet + mover);
            //Debug.Log("funciona");
            OffSet = Camara.transform.position;
            mover = (Vuforia.transform.position - RigidBodyOpti.transform.position);
            this.transform.position = -1*(OffSet + mover);
        }

        // mover en X
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(-Posicion, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(Posicion, 0, 0);
        }

        // mover en Z
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(0, 0, -Posicion);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0, 0, Posicion);
        }
        // mover en Y 
        if (Input.GetKey(KeyCode.R))
        {
            transform.position += new Vector3(0, Posicion, 0);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.position += new Vector3(0, -Posicion, 0);
        }
        // rotar con tecla N yB
        if (Input.GetKey(KeyCode.N))
        {
            transform.Rotate(0,-Rotacion, 0);
        }

        if (Input.GetKey(KeyCode.B))
        {
            transform.Rotate(0, Rotacion, 0);
        }
        //escalar con tecl  LyK
        if (Input.GetKey(KeyCode.L))
        {
            transform.localScale += new Vector3(-Scale, -Scale, -Scale);
        }

        if (Input.GetKey(KeyCode.K))
        {
           transform.localScale += new Vector3(Scale, Scale, Scale);
        }

    }
    //void MoverOrigen()
    //{
    //    // OffSet = Camara.transform.position;
    //    //mover = (Vuforia.transform.position - RigidBodyOpti.transform.position);
    //    //this.transform.position =-1* (OffSet + mover);
    //    //Debug.Log(OffSet);
    //    //Debug.Log(mover);
    //    // Debug.Log(Camara.transform.position);

    //    // Debug.Log(Vuforia.transform.position - RigidBodyOpti.transform.position);
    //}
}
