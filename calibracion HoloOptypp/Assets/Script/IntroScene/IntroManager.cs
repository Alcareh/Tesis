using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [Header("SignIn Menu")] 
    [SerializeField] private TMPro.TMP_Dropdown qDropdown;
    [SerializeField] private TMPro.TMP_Text warningText1;
    [SerializeField] private TMPro.TMP_Text warningText2;
    [SerializeField] private TMPro.TMP_Text warningText3;
    [SerializeField] private TMPro.TMP_Text warningText4;
    [SerializeField] public TMPro.TMP_InputField name;
    [SerializeField] public TMPro.TMP_InputField password1;
    [SerializeField] public TMPro.TMP_InputField password2;
    [SerializeField] private Image eye1;
    [SerializeField] private Image eye2;


[ContextMenu("Check Dropdown")]
    public void CheckSignUpDropdown() //Verifica que el dropdown no se encuentre en opción vacía.
    {
        if (qDropdown.value == 0)
        {
            warningText4.gameObject.SetActive(true);
        }
    }
[ContextMenu("Check Password")] 
    public void CheckPasswords() // Verifica que el texto de las contraseñas esté escrito 2 veces igual y cambia colores.
    {
        if (password1.text!=password2.text)
        {
            var yellowColor = new Color32(249, 230, 91, 255);
            password1.GetComponent<Image>().color = yellowColor;
            password2.GetComponent<Image>().color = yellowColor;
            password1.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().color = yellowColor;
            password2.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().color = yellowColor;
            password1.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().color = yellowColor;
            password2.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().color = yellowColor;
            eye1.GetComponent<Image>().color = yellowColor;
            eye2.GetComponent<Image>().color= yellowColor;
            warningText2.gameObject.SetActive(true);
            warningText3.gameObject.SetActive(true);
        }
    }

[ContextMenu("Check Cleaner")]
    public void CleanAll() //Limpia todos los errores y vuelve los colores a la normalidad.
    {
        warningText2.gameObject.SetActive(false);
        warningText3.gameObject.SetActive(false);
        warningText4.gameObject.SetActive(false);
        var whiteColor = new Color32(236, 245, 248, 255);
        password1.GetComponent<Image>().color = whiteColor;
        password2.GetComponent<Image>().color = whiteColor;
        password1.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().color = whiteColor;
        password2.transform.GetChild(0).transform.GetChild(1).GetComponent<TMP_Text>().color = whiteColor;
        password1.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().color = whiteColor;
        password2.transform.GetChild(0).transform.GetChild(2).GetComponent<TMP_Text>().color = whiteColor;
        eye1.GetComponent<Image>().color = whiteColor;
        eye2.GetComponent<Image>().color = whiteColor;
    }
    
    
    //Aquí debería poner un async parecido al de pad para cuando llegaba USER ya que necesito saber si la persona tiene avatar y todo eso
    //luego de cargar avatar sería necesario poder mostrar el menú de personajes si no tiene nada seleccionado, si si tiene, mostrar el perfil directamente.
}
