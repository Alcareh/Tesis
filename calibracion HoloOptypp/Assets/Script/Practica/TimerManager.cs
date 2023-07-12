using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class TimerManager : MonoBehaviour
{
    public float time=0;
    public bool seguro=false;
    public string timeText;
    
    [SerializeField]   
    public StringBuilder csv= new StringBuilder();


    public void Update()
    {
        if (seguro)
        {
            time += Time.deltaTime;
            UpdateTimer(time);
        }
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void CambiarSeguro()
    {
        seguro = true;
    }

    public void SetLoop()
    {
        //tiempo2.text = tiempo1.text;
        var newLine = string.Format("{0}", timeText);
        csv.AppendLine(newLine);
    }
    
    public void SaveCSV()
    {
        File.WriteAllText(Application.dataPath+"/DATA_CSV/TimerText.csv", csv.ToString());
    }
}