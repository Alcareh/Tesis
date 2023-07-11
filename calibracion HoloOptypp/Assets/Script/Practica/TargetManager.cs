using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class TargetManager : MonoBehaviour
{
    
    [SerializeField]   
    public StringBuilder csv= new StringBuilder();

    public int intentos = 0;
    public string targetText;


    public void AddAttempt()
    {
        intentos += 1;
        targetText = (intentos).ToString();
    }

    public void ChangeTarget()
    {
        var newLine = string.Format("{0}", targetText);
        csv.AppendLine(newLine);
        intentos = 0;
        targetText= intentos.ToString();
    }
    
    public void SaveCSV()
    {
        File.WriteAllText(Application.dataPath+"/DATA_CSV/TargetText.csv", csv.ToString());
    }
}
