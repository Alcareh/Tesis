using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ChargeDataBND : MonoBehaviour
{
    private SesionManager mySesionManager;
    private WWWForm secureForm;
    
    [Header("Sesion")]
    public bool Sesion;
    public string host;
    public string _id;
    public string nameDB;
    public bool newAccount;
    public string fondoAvatar;
    public string avatarUser;
    public string avatarLote;
    public string progreso;
    public string habilidad;
    public string nivel;
    public string puntos;
    public bool notify;
    public string logros;
    
    [Header("Referenncias")] 
    [SerializeField] private MenuManager menuManager;

    private void Start()
    {
        mySesionManager = FindObjectOfType<SesionManager>();
        this.Sesion = mySesionManager.Sesion;
        this.host = mySesionManager.host;
        this._id = mySesionManager._id;
        this.nameDB = mySesionManager.nameDB;
        TraerUser(_id);
    }

    public async void TraerUser(string _id)
    {
        await ConsultaBD(_id);
    }

    public async Task ConsultaBD(string _id)
    {
        secureForm = new WWWForm();
        secureForm.AddField("_id", _id);
        UnityWebRequest www = UnityWebRequest.Post(host+"/userByID",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            Debug.Log(temp);
            newAccount = x.newAccount;
            fondoAvatar = x.fondoAvatar;
            avatarUser= x.avatarUser;
            avatarLote= x.avatarLote;
            progreso= x.progreso;
            habilidad= x.habilidad;
            nivel= x.nivel;
            puntos= x.puntos;
            notify= x.notify;
            logros= x.logros;
            menuManager.FirstChargeData(newAccount);
        }
        else
        {
            Debug.Log(temp);
            menuManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Error al conectar con el servidor";
            menuManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
    }
    
    public async void SetFirstAvatar(string fondoAvatar,string avatarUser)
    {
        await UpdateAvatar(fondoAvatar,avatarUser);
    }
    
    public async Task UpdateAvatar(string fondoAvatar,string avatarUser)
    {
        secureForm = new WWWForm();
        secureForm.AddField("_id", _id);
        secureForm.AddField("fondoAvatar", fondoAvatar);
        secureForm.AddField("avatarUser", avatarUser);
        secureForm.AddField("newAccount","false");
        UnityWebRequest www = UnityWebRequest.Post(host+"/updateData",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            Debug.Log(temp);
            //menuManager.FirstChargeData(x.newAccount);
        }
        else
        {
            Debug.Log(temp);
            /* introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                 "Error al conectar con el servidor";
             introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");*/
        }
    }
    
    public void LogOut()
    {
        Destroy(mySesionManager);
        SceneManager.LoadScene("Intro");
    }
    
}
