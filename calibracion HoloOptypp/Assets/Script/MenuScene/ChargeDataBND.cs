using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.Utilities;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Networking;

public class ChargeDataBND : MonoBehaviour
{
    private SesionManager mySesionManager;
    private WWWForm secureForm;
    
    [Header("Sesion")]
    public bool Sesion;
    public string host;
    public string _id;
    public string name;
    
    [Header("Referenncias")] 
    [SerializeField] private MenuManager menuManager;

    private void Start()
    {
        mySesionManager = FindObjectOfType<SesionManager>();
        this.Sesion = mySesionManager.Sesion;
        this.host = mySesionManager.host;
        this._id = mySesionManager._id;
        this.name = mySesionManager.name;
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
            menuManager.FirstChargeData(x.newAccount);
            //introManager.CorrectSignUp();
        }
        else
        {
            Debug.Log(temp);
           /* introManager.toastPanel.transform.GetChild(0).GetComponent<TMP_Text>().text =
                "Error al conectar con el servidor";
            introManager.toastPanel.GetComponent<Animator>().SetTrigger("ActivarToast");*/
        }
    }
}
