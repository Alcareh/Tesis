using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

public class LoginButtonBND : MonoBehaviour 
{
    private string host= "http://localhost:3000/user";
    private WWWForm secureForm;
    public string nameDB;
    public string password;
    
    [Header("Scripts")]
    public IntroManager introManager;
    
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
        UnityWebRequest www = UnityWebRequest.Post(host+"/Login",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            Debug.Log(temp);
            //inicia sesion cambio de escena con carga y user
        }
        else
        {
            Debug.Log(temp);
            introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Usuario o contraseña incorrectos";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");//no inicia sesion
        }

    }
}
