using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.Utilities;

using UnityEngine.Networking;
using UnityEngine;

public class RegisterButtonBND : MonoBehaviour
{
    private string host= "http://localhost:3000/user";
    private WWWForm secureForm;
    public string name;
    public IntroManager introManager;

    public async void  EnviarRegistro()
    {
        name = introManager.name.text;
        await VerificarExistencia(name);
    }

    public async Task VerificarExistencia(string name)
    {
        secureForm = new WWWForm();
        secureForm.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post(host+"/userByName",secureForm);
        await www.SendWebRequest();
        string temp = www.downloadHandler.text;
        var x = JsonUtility.FromJson<userClass>(temp);
        if (www.error == null)
        {
              //se debe llamar el otro método acá
              Debug.Log(temp);
              Debug.Log("todo salio bien");
        }
        else
        {
            Debug.Log(temp);
            Debug.Log("todo salio mal");
        }
    }
}
