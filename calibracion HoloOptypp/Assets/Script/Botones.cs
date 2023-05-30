using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class Botones : MonoBehaviour
{
    public VideoPlayer video;
    public GameObject LogoDora;
    public GameObject Inrtroduccion;
    public GameObject ModoDeJuego;
    public GameObject PantallaArtroscopio1;
    public GameObject PantallaArtroscopio2;
    public GameObject PantallaArtroscopio3;
    public GameObject MensajeMotivacion;
    public GameObject MensajeFin;
    public GameObject SujetarArtro;
    public GameObject Torre;
    public GameObject MensajePalpar;
    public GameObject SeñalPalpador;
    public GameObject DescripcionLV1;

    [Header("Targets reinicio")]
    public GameObject[] Targets;
    [Header("Contador OF")]
    public Material MaterialesContadorOf;
    public Renderer[] contadorOf;
    
    
    private int P;
    [Header("Nivel 2")]
    public GameObject PosteriorRotula;
    public GameObject Medial;
    public GameObject Intercondileo;
    public GameObject Lateral;
    [Header("iconos")]
    public GameObject IconoAvanzar;
    public GameObject IconoReinicio;
    public GameObject BotonEmpezar;
    [Header(" Ui Nivel 2")]
    public GameObject IntroduccionLv2;
    public GameObject InfoProcedimiento;
    public GameObject VideoIngreso;
    public GameObject MensajeIngreso;
    public GameObject Paso1;
    public GameObject Pantalla1Lv1;
    public GameObject Pantalla2Lv1;
    public GameObject RodillaPosterior;


    public void Dora(string text)
    {
        LogoDora.SetActive(false);
        Inrtroduccion.SetActive(true);
    }
    public void Intro(string text)
    {
        Inrtroduccion.SetActive(false);
        ModoDeJuego.SetActive(true);
    }
    public void Juego(string text)
    {
        ModoDeJuego.SetActive(false);
        PantallaArtroscopio1.SetActive(true);
        Torre.SetActive(true);
    }
    public void Artroscopio1(string text)
    {
        PantallaArtroscopio1.SetActive(false);
        PantallaArtroscopio2.SetActive(true);
    }
    public void Artroscopio2(string text)
    {
        PantallaArtroscopio2.SetActive(false);
        PantallaArtroscopio3.SetActive(true);
    }
    public void Artroscopio3(string text)
    {
        PantallaArtroscopio3.SetActive(false);
        MensajeMotivacion.SetActive(true);
        DescripcionLV1.SetActive(true);
    }
    public void MensajeMoti(string text)
    {
        MensajeMotivacion.SetActive(false);
        SujetarArtro.SetActive(true);
        SeñalPalpador.SetActive(false);
        SujetarArtro.SetActive(false);
    }
    public void torre(string text)
    {
        Torre.SetActive(true);
    }
    public void MensajePalpa(string text)
    {
        MensajePalpar.SetActive(false);
        SeñalPalpador.SetActive(true);
    }
    public void ModoDeJuegpBienvenida(string text)
    {
        ModoDeJuego.SetActive(false);
        Inrtroduccion.SetActive(true);
    }

    public void Pantalla2Pantalla1(string text)
    {
        PantallaArtroscopio2.SetActive(false);
        PantallaArtroscopio1.SetActive(true);
    }

    public void Pantalla3Pantalla2(string text)
    {
        PantallaArtroscopio3.SetActive(false);
        PantallaArtroscopio2.SetActive(true);
    }

    public void RepetirLv1 (string text)
    {
        Targets[0].SetActive(true);
        Targets[1].SetActive(true);
        Targets[2].SetActive(true);
        Targets[3].SetActive(true);
        Targets[4].SetActive(true);
        Targets[5].SetActive(true);
        Targets[6].SetActive(true);
        Targets[7].SetActive(true);
        MensajeFin.SetActive(false);
        MensajeMotivacion.SetActive(true);
        contadorOf[0].material = MaterialesContadorOf;
        contadorOf[1].material = MaterialesContadorOf;
        contadorOf[2].material = MaterialesContadorOf;
        contadorOf[3].material = MaterialesContadorOf;
        contadorOf[4].material = MaterialesContadorOf;
        contadorOf[5].material = MaterialesContadorOf;
        contadorOf[6].material = MaterialesContadorOf;
        contadorOf[7].material = MaterialesContadorOf;

    }
    public void Nivel2(string text)
    {
        MensajeFin.SetActive(false);
        IntroduccionLv2.SetActive(true);

        contadorOf[0].material = MaterialesContadorOf;
        contadorOf[1].material = MaterialesContadorOf;
        contadorOf[2].material = MaterialesContadorOf;
        contadorOf[3].material = MaterialesContadorOf;
        contadorOf[4].material = MaterialesContadorOf;
        contadorOf[5].material = MaterialesContadorOf;
        contadorOf[6].material = MaterialesContadorOf;
        contadorOf[7].material = MaterialesContadorOf;
    }
    public void InfoProcedimientoLv2(string text)
    {
        IntroduccionLv2.SetActive(false);
        InfoProcedimiento.SetActive(true);   
    }
    public void VideoIngresoCanula(string text)
    {
        InfoProcedimiento.SetActive(false);
        VideoIngreso.SetActive(true);
        

    
    }

    public void VideoPlay(string text)
    {
        video.Play();
    }

    public void VideoPause(string text)
    {
        video.Pause(); 
    }

    public void VideoContinuar(string text)
    {
        VideoIngreso.SetActive(false);
        MensajeIngreso.SetActive(true);
        RodillaPosterior.SetActive(true);
    }
    public void EmpezarLv2(string text)
    {
        MensajeIngreso.SetActive(false);
        Paso1.SetActive(true);
        Pantalla1Lv1.SetActive(false);
        Pantalla2Lv1.SetActive(false);
    }



    public void InfoLv2suma(string text)
    {

        P += 1;
        if (P==0)
        {


        }

        if (P == 1)
        {
            Intercondileo.SetActive(false);
            Lateral.SetActive(false);
            PosteriorRotula.SetActive(false);
            Medial.SetActive(true);
            
        }
        if (P == 2)
        {
            Lateral.SetActive(false);
            PosteriorRotula.SetActive(false);
            Medial.SetActive(false);
            Intercondileo.SetActive(true);
            
        }
        if (P == 3)
        {
            PosteriorRotula.SetActive(false);
            Medial.SetActive(false);
            Intercondileo.SetActive(false);
            Lateral.SetActive(true);
            IconoReinicio.SetActive(true);
            IconoAvanzar.SetActive(false);
            BotonEmpezar.SetActive(true);
        }
        if (P == 4)
        {
           
            PosteriorRotula.SetActive(true);
            Medial.SetActive(false);
            Intercondileo.SetActive(false);
            Lateral.SetActive(false);
            IconoReinicio.SetActive(false);
            IconoAvanzar.SetActive(true);
            P = 0;
        }


    }
    public void InfoLv2resta(string text)
    {
        PosteriorRotula.SetActive(true);
        Medial.SetActive(false);
        Intercondileo.SetActive(false);
        Lateral.SetActive(false);

    }
}
