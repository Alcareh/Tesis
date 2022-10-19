using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SupraMedial : MonoBehaviour
{

    [Header("Información Raycast)]")]
    public GameObject currentHitObject;
    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;
    private float currentHitDistance;

    [Header("Contador Variable")]
    public TMP_Text TargetCounter;
    [SerializeField] private string Tag = "Circulito";
    [SerializeField] private Material nuevo_Color;
    [SerializeField] private Material ColorBase;
    public Image Mira;
    public Image MiraCompleta;
    public float tiempo_Transcurrido;

    private Transform selection1;
    private bool status = false;
    private float tiempo_Final = 3f;

    [Header("Vector Targets")]
    public List<GameObject> TargetList = new List<GameObject>(new GameObject[8]);

    [Header("UI contador")]
    public Material MaterialesContador;
    public Material MaterialMiraOn;
    public Material MaterialMiraOf;
    public Renderer ObjetoMira;

    public Renderer[] contador;
    [Header("Mensajes")]
    public GameObject[] tareasPracticas;
    [Header("Indicaciones UI")]
    public GameObject ArtroSeñal;
    public GameObject MensajeFin;
    public GameObject PalpaSeñal;
    public GameObject MensajePal;
    private int W = 0;

    public static bool Palpa; //*************************************************************************

    public GameObject[] TareasPracticas { get => tareasPracticas; set => tareasPracticas = value; }

    //public Vector3 ArtroRo;
    //public GameObject Artro;




    void Start()
    {
        tiempo_Transcurrido = 0f;
    }

    void Update()
    {
        EscogerTarget();
        Palpa = Palpar.EstaPalpando;//*************************************************************************



    }

    void EscogerTarget()
    {
        if (TargetList.Count == 8)
        {
            if (W == 0)
            {
                W += 1;
                TareasPracticas[0].SetActive(true);
            }
        }
        if (TargetList.Count == 7)
        {
            if (W == 1)
            {
                W += 1;
                contador[0].material = MaterialesContador;
                TareasPracticas[0].SetActive(false);
                TareasPracticas[1].SetActive(true);
                ArtroSeñal.SetActive(false);
            }
        }
        if (TargetList.Count == 6)
        {
            if (W == 2)
            {
                W += 1;
                contador[1].material = MaterialesContador;
                TareasPracticas[1].SetActive(false);
                TareasPracticas[2].SetActive(true);
            }
        }
        if (TargetList.Count == 5)
        {
            if (W == 3)
            {
                W += 1;
                contador[2].material = MaterialesContador;
                TareasPracticas[2].SetActive(false);
                TareasPracticas[3].SetActive(true);
                //MensajePal.SetActive(true);

            }

        }
        if (TargetList.Count == 4)
        {
            if (W == 4)
            {
                W += 1;
                contador[3].material = MaterialesContador;
                TareasPracticas[3].SetActive(false);
                TareasPracticas[4].SetActive(true);
                //MensajePal.SetActive(true);

            }
        }
        if (TargetList.Count == 3)
        {
            if (W == 5)
            {
                W += 1;
                contador[4].material = MaterialesContador;
                TareasPracticas[4].SetActive(false);
                TareasPracticas[5].SetActive(true);
                //PalpaSeñal.SetActive(false);
            }
        }
        if (TargetList.Count == 2)
        {
            if (W == 6)
            {
                W += 1;
                contador[5].material = MaterialesContador;
                TareasPracticas[5].SetActive(false);
                TareasPracticas[6].SetActive(true);
            }
        }
        if (TargetList.Count == 1)
        {
            if (W == 7)
            {
                W += 1;
                contador[6].material = MaterialesContador;
                TareasPracticas[6].SetActive(false);
                TareasPracticas[7].SetActive(true);
            }
        }
        if (TargetList.Count == 0)
        {
            if (W == 8)
            {
                W += 1;
                contador[7].material = MaterialesContador;
                TareasPracticas[7].SetActive(false);
                MensajeFin.SetActive(true);
                //como esto se llama en update toca es cambiar de escena o hacer algo que pare ese update
                Debug.Log("Se acabó esto xdxd");
            }
        }

        else
        {
            origin = transform.position;
            direction = transform.forward;
            if (Physics.SphereCast(origin, sphereRadius, direction, out RaycastHit hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                currentHitObject = hit.transform.gameObject;
                currentHitDistance = hit.distance;
                var selection = hit.transform;
                if (selection.CompareTag(Tag) && currentHitObject == TargetList[0] && Palpa == true)
                {
                    //Debug.Log("Tocó objetivo");
                    Encendido();
                    tiempo_Transcurrido += Time.deltaTime;

                    if (tiempo_Transcurrido >= tiempo_Final && Palpa == true)
                    {
                        //Debug.Log("Tocó objetivo por 3 segundos");
                        Seleccionar(selection);
                    }
                }
                else
                {
                    ResetTimer();
                    Apagado();
                    Deselecionar();
                }
            }
            else
            {
                currentHitDistance = maxDistance;
                currentHitObject = null;
                ResetTimer();
                Apagado();
                Deselecionar();
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
    void ResetTimer()
    {
        tiempo_Transcurrido = 0f;
        //Debug.Log("Reiniciando Timer");
    }

    void Seleccionar(Transform selection)
    {

        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            //Cambia color objetivo
            //selectionRenderer.material = nuevo_Color;
            //Desactiva objetivo
            selection.gameObject.SetActive(false);
            TargetList.RemoveAt(0);
            //Suma uno al contador visual en el canva TMPro type
            TargetCounter.text = (int.Parse(TargetCounter.text) + 1).ToString();
        }
        selection1 = selection;
    }

    void Deselecionar()
    {
        //Vuelve al color inicial al objetivo
        if (selection1 != null)
        {
            var selectionRenderer = selection1.GetComponent<Renderer>();
            selectionRenderer.material = ColorBase;
            selection1 = null;
        }
    }

    void Encendido()
    {
        //Inicia el timer de manera gráfica
        status = true;
        if (status == true)
        {
            Mira.gameObject.SetActive(false);
            ObjetoMira.material = MaterialMiraOn;
            MiraCompleta.gameObject.SetActive(true);
            MiraCompleta.fillAmount = tiempo_Transcurrido / tiempo_Final;
        }
    }

    void Apagado()
    {
        //Elimina el timer de manera gráfica
        ObjetoMira.material = MaterialMiraOf;
        Mira.gameObject.SetActive(true);
        MiraCompleta.gameObject.SetActive(false);
        MiraCompleta.fillAmount = 0;
    }

}
