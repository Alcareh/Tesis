using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Header Objects")]
    [SerializeField] private GameObject headerBar;
    [SerializeField] public TMP_Text inicioText;
    [SerializeField] public TMP_Text logrosText;
    [SerializeField] public TMP_Text inventarioText;
    [SerializeField] public TMP_Text retosText;
    
    public void Inicio()
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inicioText.transform.position, -10f);
    }
    
    public void Logros()
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(logrosText.transform.position, -10f);
    }
    
    public void Inventario()
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inventarioText.transform.position, -10f);
    }
    
    public void Retos()
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(retosText.transform.position, -10f);
    }
}
