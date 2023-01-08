using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit.Utilities;
using TMPro;

public class RecoverButtonBND : MonoBehaviour
{
 private string host;
    private WWWForm secureForm;
    public string mail;
    public string securityqOp;
    public string securityqAn;
    
    [Header("Scripts")]
    public IntroManager introManager;
    private SesionManager mySesionManager;
    
    
    private void Start()
    {
        mySesionManager = FindObjectOfType<SesionManager>();
        this.host = mySesionManager.host;
    }
    
    public async void  CheckInfo() //Trae los datos de los gameobjects a variables y los manda al Task
    {
        mail = introManager.mailRecover.text;
        securityqOp = introManager.securityqOpRecover.value.ToString();
        securityqAn = introManager.securityqAnRecover.text;
        await CheckUser(mail, securityqOp, securityqAn);
    }
    
    public async Task CheckUser(string mail, string securityqOp, string securityqAn)
    {
        secureForm = new WWWForm();
        secureForm.AddField("mail", mail);
        secureForm.AddField("securityqOp",securityqOp);
        secureForm.AddField("securityqAn",securityqAn);
        UnityWebRequest www = UnityWebRequest.Post(host+"/CheckRecover",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
           //Debug.Log(temp);
            introManager.nameDBRecover = x.name;
            introManager._idRecover = x._id;
            introManager.recover1.SetActive(false);
            introManager.recover2.SetActive(true);
            introManager.nameRecover.text = x.name;
        }
        else
        {
            //Debug.Log(temp);
            introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Datos incorrectos";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");
        }
    }
}
