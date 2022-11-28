using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedAvatar2 : MonoBehaviour
{
  
  [Header("Static BG")]
  [SerializeField] private List<GameObject> bgList;

  public void ActivarOrden() //Ordena los BGFijos
  {
    foreach (var staticBG in bgList)
    {
      staticBG.GetComponent<BaseBGAvatar>().ordenarFondos();
    }
  }
}
