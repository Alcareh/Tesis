using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class TargetManager : MonoBehaviour
{
    
    [SerializeField]   
    public StringBuilder csv= new StringBuilder();

    public bool seguroTarget=true;
    public int intentos = 0;
    public string targetText;


    public void AddAttempt()
    {
        seguroTarget = false;
        intentos += 1;
        targetText = (intentos).ToString();
        Debug.Log("intento:"+targetText);
    }

    public void ChangeTarget()
    {
        var newLine = string.Format("{0}", targetText);
        csv.AppendLine(newLine);
        Debug.Log("Este target quedó con "+targetText+" número de intentos");
        intentos = 0;
        targetText= intentos.ToString();
    }
    
    public void SaveCSV()
    {
        File.WriteAllText(Application.dataPath+"/DATA_CSV/TargetText.csv", csv.ToString());
    }
}
