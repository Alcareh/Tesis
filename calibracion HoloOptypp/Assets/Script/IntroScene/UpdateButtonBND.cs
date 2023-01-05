using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

public class UpdateButtonBND : MonoBehaviour
{
    private string host= "http://localhost:3000/user";
    private WWWForm secureForm;
    public string _id;
    public string nameDB;
    public string password1;
    public string password2;
    
    [Header("Scripts")]
    public IntroManager introManager;
    
    public async void  CheckInfo() //Trae los datos de los gameobjects a variables y los manda al Task
    {
        _id = introManager._idRecover;
        nameDB = introManager.nameDBRecover;
        password1= introManager.password1Recover.text;
        password2= introManager.password2Recover.text;
        await UpdateUser(_id, password1);
    }
    
    public async Task UpdateUser(string _id, string password)
    {
        secureForm = new WWWForm();
        secureForm.AddField("_id", _id);
        secureForm.AddField("password",password);
        UnityWebRequest www = UnityWebRequest.Post(host+"/PasswordRecover",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            //Debug.Log(temp);
            introManager.RecoverPasswordOff();
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
