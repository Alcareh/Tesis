using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Header Objects")]
    [SerializeField] private GameObject headerBar;
    [SerializeField] public TMP_Text inicioText;
    [SerializeField] public TMP_Text logrosText;
    [SerializeField] public TMP_Text inventarioText;
    [SerializeField] public TMP_Text retosText;
    [SerializeField] public GameObject toastPanel;

    [Header("Primera vez avatar")] 
    [SerializeField] private GameObject welcomeOnce;
    [SerializeField] private GameObject bgContainer;
    [SerializeField] private GameObject avatarContainer;

    [Header("Profile Info")] 
    [SerializeField] private GameObject fakeProfile;
    [SerializeField] private GameObject profileBG;
    [SerializeField] private GameObject profileAvatar;

    [Header("MenuView")] 
    [SerializeField] private GameObject homeMenu;
    [SerializeField] private GameObject homeMenuOnce;
    [SerializeField] private GameObject homeGoals;
    [SerializeField] private GameObject homeInventory;
    [SerializeField] private GameObject homeChallenges;

    [Header("Referenncias")] 
    [SerializeField] private InventoryManager inventoryManager;

  
    public void Inicio()//Cambia a menú inicio
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inicioText.transform.position, -10f);
        //Check si es la primera vez que ingresa prender WelcomeOnceContainer, de lo contrario solo el container de Inicio
        Desactivar();
        homeMenuOnce.SetActive(true);
    }
    
    public void Logros()//Cambia a menú logros
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(logrosText.transform.position, -10f);
        Desactivar();
        homeGoals.SetActive(true);
    }
    
    public void Inventario()//Cambia a menú inventario
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inventarioText.transform.position, -10f);
        Desactivar();
        homeInventory.SetActive(true);
        inventoryManager.MostrarAvatares();
    }
    
    public void Retos()//Cambia a menú retos
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(retosText.transform.position, -10f);
    }

    public void Desactivar()
    {
        //homeMenu.SetActive(false);
        homeMenuOnce.SetActive(false);
        homeGoals.SetActive(false);
        homeInventory.SetActive(false);
        //homeChallenges.SetActive(false);
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
        }else{ //Muestra mensaje de error en toast.
            toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
    }
}
