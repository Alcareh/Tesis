using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereManager : MonoBehaviour {

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
    public List<GameObject> TargetList = new List<GameObject>(new GameObject[17]);

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
    private int W=0;
    [Header("nivel 1")]
    public GameObject DescripcionVizual;
    public GameObject DescripcionPalpa;

    [Header("nivel2")]
    public GameObject Paso1;
    public GameObject Paso2;
    public GameObject Paso3;
    public GameObject Paso4;
    public GameObject Paso5;
    public GameObject Paso6;
    public GameObject Paso7;
    public GameObject Paso8;
    public GameObject Paso9;

    public GameObject MensajeFinLv2;


    public static bool Palpa; //*************************************************************************

    public GameObject[] TareasPracticas { get => tareasPracticas; set => tareasPracticas = value; }

    //public Vector3 ArtroRo;
    //public GameObject Artro;


    [Header("nivel2 rodilla")]
    public GameObject RodillaRotula;
    public GameObject RodillaCompartimientoMedial;
    public GameObject Rodilla4;

    [Header("Target Lv2")]
    public GameObject Target1LV2;
    public GameObject Target2LV2;
    public GameObject Target3LV2;
    public GameObject Target4LV2;
    public GameObject Target5LV2;
    public GameObject Target6LV2;
    public GameObject Target7LV2;
    public GameObject Target8LV2;
    public GameObject Target9LV2;
    [Header("Descricion lv1")]
    public GameObject visualiza1a;
    public GameObject visualiza1b;
    public GameObject visualiza2a;
    public GameObject visualiza2b;

    
    [Header("Scripts")]
    public TimerManager timerManager;
    public TargetManager targetManager;

    void Start () {
        tiempo_Transcurrido = 0f;
    }
	
	void Update () {
        EscogerTarget();
        Palpa = Palpar.EstaPalpando;//*************************************************************************



    }

    void EscogerTarget()
    {


            if (TargetList.Count == 17)
        {
            if (W == 0)
            {
                W += 1;
                TareasPracticas[0].SetActive(true);
            }
        }

        if (TargetList.Count == 16)
        {
            if (W == 1)
            {// vio la Esfera 1
                W += 1;
                contador[0].material = MaterialesContador;
                TareasPracticas[0].SetActive(false);
                TareasPracticas[1].SetActive(true);
                ArtroSeñal.SetActive(false);
            }
        }

        if (TargetList.Count == 15)
        {
            if (W == 2)
            { // Esfera 2
                W += 1;
                contador[1].material = MaterialesContador;
                TareasPracticas[1].SetActive(false);
                TareasPracticas[2].SetActive(true);

            }
        }

        if (TargetList.Count == 14)
        {
            if (W == 3)
            {// Esfera 3
                W += 1;
                contador[2].material = MaterialesContador;
                TareasPracticas[2].SetActive(false);
                TareasPracticas[3].SetActive(true);
                MensajePal.SetActive(true);//***************
                visualiza1a.SetActive(false);
                visualiza1b.SetActive(false);
                visualiza2a.SetActive(true);
                visualiza2b.SetActive(true);

            }
        }
        
        if (TargetList.Count == 13)
        {
            if (W == 4)
            {
                W += 1;
                contador[3].material = MaterialesContador;
                TareasPracticas[3].SetActive(false);
                TareasPracticas[4].SetActive(true);
                DescripcionPalpa.SetActive(true);
                DescripcionVizual.SetActive(false);
                
                //MensajePal.SetActive(true);

            }
        }

        if (TargetList.Count == 12)
        {
            if (W == 5)
            {
                W += 1;
                contador[4].material = MaterialesContador;
                TareasPracticas[4].SetActive(false);
                TareasPracticas[5].SetActive(true);
                //PalpaSeñal.SetActive(false);****************
                MensajeFin.SetActive(true);
                //como esto se llama en update toca es cambiar de escena o hacer algo que pare ese update
                Debug.Log("Se acabó esto xdxd");
            }
        }

       /* if (TargetList.Count ==11)
        {
            if (W == 6)
            {
                W += 1;
                contador[5].material = MaterialesContador;
                TareasPracticas[5].SetActive(false);
                TareasPracticas[6].SetActive(true);
            }

        }
        if (TargetList.Count == 10)
        {
            if (W == 7)
            {
                W += 1;
                contador[6].material = MaterialesContador;
                TareasPracticas[6].SetActive(false);
                TareasPracticas[7].SetActive(true);
            }

        }
        if (TargetList.Count == 9)
        {
            if (W == 8)
            {
                W += 1;
                contador[7].material = MaterialesContador;
                TareasPracticas[7].SetActive(false);
                
            }
        }*/

            // ----------------------------Nivel 2-----------------------
        
        if (TargetList.Count ==11)
        {
            contador[0].material = MaterialesContador;
            Paso1.SetActive(false);
            Paso2.SetActive(true);
            RodillaRotula.SetActive(false);
            RodillaCompartimientoMedial.SetActive(true);




        }
        if (TargetList.Count == 10)
        {
            contador[1].material = MaterialesContador;
            Paso2.SetActive(false);
            Paso3.SetActive(true);


            Target3LV2.SetActive(true);

        }
        if (TargetList.Count == 9)
        {
            contador[2].material = MaterialesContador;
            Paso3.SetActive(false);
            Paso4.SetActive(true);

            Target4LV2.SetActive(true);

        }
        if (TargetList.Count == 8)
        {
            contador[3].material = MaterialesContador;
            Paso4.SetActive(false);
            Paso5.SetActive(true);

            RodillaCompartimientoMedial.SetActive(false);
            Rodilla4.SetActive(true);

        }
        if (TargetList.Count == 7)
        {
            contador[4].material = MaterialesContador;
            Paso5.SetActive(false);
            Paso6.SetActive(true);
            Target6LV2.SetActive(true);
        }
        if (TargetList.Count == 6)
        {
            contador[5].material = MaterialesContador;

            Paso6.SetActive(false);
            Paso7.SetActive(true);
            Target7LV2.SetActive(true);

        }
        if (TargetList.Count == 5)
        {
            contador[6].material = MaterialesContador;
            Paso7.SetActive(false);
            Paso8.SetActive(true);
            Target8LV2.SetActive(true);
        }
        if (TargetList.Count == 4)
        {
            contador[7].material = MaterialesContador;
            Paso8.SetActive(false);
            Paso9.SetActive(true);
            Target9LV2.SetActive(true);
        }
        if (TargetList.Count == 3)
        {
            Paso9.SetActive(false);
            contador[8].material = MaterialesContador;
            MensajeFinLv2.SetActive(true);
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
                    Debug.Log("Tocó objetivo");
                    Encendido();
                    tiempo_Transcurrido += Time.deltaTime;

                    if (tiempo_Transcurrido >= tiempo_Final && Palpa == true)
                    {
                        Debug.Log("Tocó objetivo por 3 segundos");
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
            timerManager.SetLoop(); //Loop del timer?
            targetManager.ChangeTarget();// Change target counter.
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
            //targetManager.AddAttempt(); //Add attempt? (me toca buscarle un if pq se hace muchas veces)
            Debug.Log(("Agregando intento xdxd"));
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


