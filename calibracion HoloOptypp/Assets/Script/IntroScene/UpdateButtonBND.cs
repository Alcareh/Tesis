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
    public string _id;
    public string nameDB;
    public string password1;
    public string password2;
    
    [Header("Scripts")]
    public IntroManager introManager;
    
    public async void  CheckInfo()
    {
        _id = introManager._idRecover;
        nameDB = introManager.nameDBRecover;
        password1= introManager.password1Recover.text;
        password2= introManager.password2Recover.text;
        await UpdateUser(_id, password1);
    }
    
    public async Task UpdateUser(string _id, string password)
    {
        userClass myUser = new userClass();
        myUser._id = _id;
        myUser.password = password;
        string jsonToSend = JsonUtility.ToJson(myUser);
        Debug.Log(jsonToSend);
        UnityWebRequest www = UnityWebRequest.Put(host+"/update",jsonToSend);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
            Debug.Log(temp);
            //todogud
        }
        else
        {
            Debug.Log(temp);
            //todonogud
            /*introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Datos incorrectos";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");*/
        }
    }
}
