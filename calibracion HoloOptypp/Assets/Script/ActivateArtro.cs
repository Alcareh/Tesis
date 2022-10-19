using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArtro : MonoBehaviour
{
    public GameObject ArtroC;
    public GameObject Streaming;
    //public GameObject Rigidbody;
    public GameObject Resto;
    public GameObject Torre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ArtroC.SetActive(true);
            Streaming.SetActive(true);
            //Rigidbody.SetActive(true);
            Resto.SetActive(true);
            Torre.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ArtroC.SetActive(false);
        }
    }
}

