using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Header Objects")]
    [SerializeField] private GameObject headerBar;
    [SerializeField] public TMP_Text inicioText;
    [SerializeField] public TMP_Text logrosText;
    [SerializeField] public TMP_Text inventarioText;
    [SerializeField] public TMP_Text retosText;

    [Header("Primera vez avatar")] 
    [SerializeField] private GameObject welcomeOnce;
    [SerializeField] private GameObject bgContainer;
    [SerializeField] private GameObject avatarContainer;

    [Header("Profile Info")] 
    [SerializeField] private GameObject fakeProfile;
    [SerializeField] private GameObject profileBG;
    [SerializeField] private GameObject profileAvatar;
    
    public void Inicio()//Cambia a menú inicio
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inicioText.transform.position, -10f);
    }
    
    public void Logros()//Cambia a menú logros
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(logrosText.transform.position, -10f);
    }
    
    public void Inventario()//Cambia a menú inventario
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inventarioText.transform.position, -10f);
    }
    
    public void Retos()//Cambia a menú retos
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(retosText.transform.position, -10f);
    }
    
    public void AceptarAvatarInicio(){
        if (bgContainer.GetComponent<SelectedAvatar>().selectedAvatar!=null&&avatarContainer.GetComponent<SelectedAvatar>().selectedAvatar!=null)
        {
            profileBG.GetComponent<Image>().sprite = bgContainer.GetComponent<SelectedAvatar>().selectedAvatar;
            profileAvatar.GetComponent<Image>().sprite = avatarContainer.GetComponent<SelectedAvatar>().selectedAvatar;
            //Por acá toca mandarle lo datos de selección del usuario al backend.
            if (fakeProfile.activeSelf)
            {
                fakeProfile.SetActive(false);
            }
            welcomeOnce.SetActive(false);
        }
        //Debería hacer un toast para decir que seleccione al menos uno xdxd
        Debug.Log("Escoja algo bruto");
    }
}
