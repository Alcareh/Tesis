using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    // este script es para que haga algo parecido al 1, seleccionando en qué avatar está y lo ponga en profile.
    //y toca crear un nuevo botón de guardar y eso
    
    [Header("InventorySlots")] 
    [SerializeField] private GameObject bgSlot;
    [SerializeField] private List<GameObject> avatarSlots;

    [Header("VariablesFictis")]
    public int numeritoBack;

    public void MostrarAvatares()
    {
        foreach (var avatarGroup in avatarSlots) //primero los apaga por si entran en dos cuentas diferentes
        {
            avatarGroup.SetActive(false);
        }
        for (int i = 0; i <= numeritoBack; i++) //Prende los que lleguen del backend y ordena el BG
        {
            avatarSlots[i].SetActive(true);
            avatarSlots[i].GetComponent<SelectedAvatar2>().ActivarOrden();
        }
    }
}
