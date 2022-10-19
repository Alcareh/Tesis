using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palpar : MonoBehaviour
{
    public static bool EstaPalpando=true;
    int Z =0;
    public GameObject Target2;
    public GameObject Target3;
    public GameObject Target4;
    public GameObject Target5;
    //public GameObject Target6;
    //public GameObject Target7;
   // public GameObject Target8;



    void Update()
    {
        if (Target2.activeSelf == false && Z == 0)
        {
            
            Z += 1;
            Debug.Log("aquiii0");
        }

        if (Target3.activeSelf == false&& Z == 1 )
        {
            EstaPalpando = false;
            Z += 1;
            Debug.Log("aquiii");
        }

        if (Target4.activeSelf == false && Z == 2)
        {
            EstaPalpando = false;
            Z += 1;
            Debug.Log("aquiii2");
        }
       /* if (Target5.activeSelf == false && Z == 3)
        {
            EstaPalpando = false;
            Z += 1;
            Debug.Log("aquiii3");
        }
        if (Target7.activeSelf == false && Z == 4)
        {
            EstaPalpando = false;
            Z += 1;
            Debug.Log("aquiii4");
        }*/
    }

        public void OnTriggerEnter()
    {
         EstaPalpando = true;
        Debug.Log("entro");
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        EstaPalpando = false;
        Debug.Log("salio" );
    }
    //void OnTriggerStay(Collider other)
    //{
    //    if (EstaPalpando == true && X == 0)
    //    {
    //        EstaPalpando = false;
    //        X = 1;
    //         Debug.Log(EstaPalpando);
    //    }
    //}

}
