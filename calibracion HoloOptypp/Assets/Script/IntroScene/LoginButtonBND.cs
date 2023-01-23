using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginButtonBND : MonoBehaviour 
{
    private string host;
    private WWWForm secureForm;
    public string nameDB;
    public string password;
    
    [Header("Scripts")]
    public IntroManager introManager;
    private SesionManager mySesionManager;
    
    
    private void Start()
    {
        mySesionManager = FindObjectOfType<SesionManager>();
        this.host = mySesionManager.host;
    }
    
    //Trae los datos de los gameobjects a variables y los manda al Task
    public async void  EnviarSesion()
    {
        nameDB = introManager.nameDBLogin.text;
        password = introManager.passwordLogin.text; 

        await InicioSesion(nameDB,password);
    }

    public async Task InicioSesion(string name, string password)
    {
        secureForm = new WWWForm();
        secureForm.AddField("name", name);
        secureForm.AddField("password",password);
        UnityWebRequest www = UnityWebRequest.Post(host+"user/Login",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            //Debug.Log(temp);
            mySesionManager._id = x._id;
            mySesionManager.nameDB = name;
            mySesionManager.Sesion = true;
            SceneManager.LoadScene("Menu");
            //inicia sesion cambio de escena con carga y user
        }
        else
        {
            //Debug.Log(temp);
            introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Usuario o contraseña incorrectos";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");//no inicia sesion
        }

    }
}
