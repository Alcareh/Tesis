using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;
using UnityEngine.Networking;
using UnityEngine;

public class RegisterButtonBND : MonoBehaviour
{
    private string host= "http://localhost:3000/user";
    private WWWForm secureForm;
    public string nameDB;
    public string mail;
    public string password;
    public string securityqOp;
    public string securityqAn;
    
    [Header("Scripts")]
    public IntroManager introManager;
    

    public async void  EnviarRegistro() //Trae los datos de los gameobjects a variables y los manda al Task
    {
        nameDB = introManager.nameDB.text;
        mail = introManager.mail.text;
        password = introManager.password1.text;
        securityqOp = introManager.securityqOp.value.ToString();
        securityqAn = introManager.securityqAn.text;
        
        await VerificarExistencia(nameDB);
    }

    public async Task VerificarExistencia(string name)
    {
        secureForm = new WWWForm();
        secureForm.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post(host+"/getUserSignUp",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Elige un nombre de usuario diferente por favor";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
        else
        {
            await EnviarDatos();
        }
    }

    public async Task EnviarDatos()
    {
        secureForm = new WWWForm();
        secureForm.AddField("name", nameDB);
        secureForm.AddField("mail", mail);
        secureForm.AddField("password", password);
        secureForm.AddField("securityqOp", securityqOp);
        secureForm.AddField("securityqAn", securityqAn);
        UnityWebRequest www = UnityWebRequest.Post(host+"/auth/create",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            //Debug.Log(temp);
            await Task.Delay(1000); //en milisegundos
            introManager.CorrectSignUp();
        }
        else
        {
            //Debug.Log(temp);
            introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Error al conectar con el servidor";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
        
    }
}
