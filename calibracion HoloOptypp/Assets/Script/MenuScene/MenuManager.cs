using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;
using Int32 = System.Int32;

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
    [SerializeField] private TMP_Text userNameText1;
    [SerializeField] private GameObject bgContainer;
    [SerializeField] private GameObject avatarContainer;

    [Header("Profile Info")] 
    [SerializeField] private GameObject fakeProfile;
    [SerializeField] public GameObject profileBG;
    [SerializeField] public GameObject profileAvatar;
    [SerializeField] public TMP_Text profileName;
    [SerializeField] public GameObject profileLvlImg;
    [SerializeField] public TMP_Text profileLvlTxt;
    [SerializeField] public GameObject profileProgressImg;
    [SerializeField] public TMP_Text profileProgressTxt;
    [SerializeField] public GameObject profileHabilityImg;
    [SerializeField] public TMP_Text profileHabilityTxt;
    [SerializeField] public TMP_Text profilePoints;
    [SerializeField] public GameObject profileNotify;
    [SerializeField] public List<Sprite> spritesBG;
    [SerializeField] public List<Sprite> spritesAvatar;
    [SerializeField] public List<Sprite> spritesGoal;
    [SerializeField] public List<String> nameLvl;

    [Header("Goal Menu")] 
    [SerializeField] private List<GameObject> goalsOff;
    [SerializeField] private List<GameObject> goalsOn;


    [Header("MenuView")] 
    [SerializeField] private GameObject homeMenu;
    [SerializeField] private GameObject homeMenuOnce;
    [SerializeField] private GameObject homeGoals;
    [SerializeField] private GameObject homeInventory;
    [SerializeField] private GameObject homeChallenges;
    [SerializeField] private GameObject notifyPanel;
    [SerializeField] private GameObject logOutPanel;

    [Header("Referenncias")] 
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ChargeDataBND chargeDataBND;

    public void Inicio()//Cambia a menú inicio
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inicioText.transform.position, -10f);
        //Check si es la primera vez que ingresa prender WelcomeOnceContainer, de lo contrario solo el container de Inicio
        Desactivar();
        if (chargeDataBND.newAccount)
        {
            homeMenuOnce.SetActive(true);
        }
        else
        {
            homeMenu.SetActive(true);
        }
    }
    
    public void Logros()//Cambia a menú logros
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(logrosText.transform.position, -10f);
        Desactivar();
        homeGoals.SetActive(true);
        ChargeGoals();
    }
    
    public void Inventario()//Cambia a menú inventario
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(inventarioText.transform.position, -10f);
        Desactivar();
        homeInventory.SetActive(true);
        inventoryManager.MostrarAvatares(chargeDataBND.nivel);
    }
    
    public void Retos()//Cambia a menú retos
    {
        headerBar.GetComponent<HeaderBar>().MoverBarra(retosText.transform.position, -10f);
        Desactivar();
        homeChallenges.SetActive(true);
    }

    public void Desactivar()
    {
        homeMenu.SetActive(false);
        homeMenuOnce.SetActive(false);
        homeGoals.SetActive(false);
        homeInventory.SetActive(false);
        homeChallenges.SetActive(false);
    }
   
    public void AceptarAvatarInicio(){
        if (bgContainer.GetComponent<SelectedAvatar>().selectedAvatar!=null&&avatarContainer.GetComponent<SelectedAvatar>().selectedAvatar!=null)
        {
            chargeDataBND.SetFirstAvatar(bgContainer.GetComponent<SelectedAvatar>().selectedName,avatarContainer.GetComponent<SelectedAvatar>().selectedName);
            welcomeOnce.SetActive(false);
            ChargeData();
        }else{ //Muestra mensaje de error en toast.
            toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Selecciona un fondo y un avatar.";
            toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
    }

    public void NotifyButton() //Apagar y prender el botón de notificaciones
    {
        if (!notifyPanel.activeSelf)
        {
            notifyPanel.SetActive(true);
        }
        else
        {
            notifyPanel.SetActive(false);
        }
    }
    public void ProfileButton() //Apagar y prender el botón de notificaciones
    {
        if (!logOutPanel.activeSelf)
        {
            logOutPanel.SetActive(true);
        }
        else
        {
            logOutPanel.SetActive(false);
        }
    }

    public void FirstChargeData(bool newAcc)
    {
        if (newAcc)
        {
            welcomeOnce.SetActive(true);
            homeMenuOnce.SetActive(true);
            userNameText1.text = "Bienvenid@ " + chargeDataBND.nameDB;
        }
        else
        {
            ChargeData();
        }
    }

    public void ChargeData()
    {
        homeMenu.SetActive(true);
        if (fakeProfile.activeSelf)
        {
            fakeProfile.SetActive(false);
        }

        foreach (var picture in spritesBG)
        {
            if (chargeDataBND.fondoAvatar==picture.name)
            {
                profileBG.GetComponent<Image>().sprite = picture;
            }
        }
        foreach (var picture in spritesAvatar)
        {
            if (chargeDataBND.avatarUser==picture.name)
            {
                profileAvatar.GetComponent<Image>().sprite = picture;
            }
        }

        profileName.text = chargeDataBND.nameDB;
        profileLvlImg.GetComponent<Image>().sprite = spritesGoal[Int32.Parse(chargeDataBND.logros)];
        profileLvlTxt.text = nameLvl[Int32.Parse(chargeDataBND.nivel) - 1];
        profileProgressImg.GetComponent<Image>().fillAmount = float.Parse(chargeDataBND.progreso)/100;
        profileProgressTxt.text = chargeDataBND.progreso;
        profileHabilityImg.GetComponent<Image>().fillAmount = float.Parse(chargeDataBND.habilidad)/100;
        profileHabilityTxt.text = chargeDataBND.habilidad;
        profilePoints.text = chargeDataBND.puntos;
        profileNotify.SetActive(chargeDataBND.notify);
    }

    public void ChargeGoals()
    {
        for (int i = 0; i <= Int32.Parse(chargeDataBND.logros)-1; i++)
        {
            goalsOff[i].SetActive(false);
            goalsOn[i].SetActive(true);
        }
    }
    

}
