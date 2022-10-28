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
    [SerializeField] private TMPro.TMP_InputField password1;
    [SerializeField] private TMPro.TMP_InputField password2;
    [SerializeField] private Image eye1;
    [SerializeField] private Image eye2;



    public void CheckSignUpDropdown()
    {
        if (qDropdown.value == 0)
        {
            warningText4.gameObject.SetActive(true);
        }
    }

    public void CheckPasswords()
    {
        if (password1.text!=password2.text)
        {
            var yellowColor = new Color(249, 230, 91, 1);
            password1.image.color = yellowColor;
            password2.image.color = yellowColor;
            eye1.color = yellowColor;
            eye2.color = yellowColor;
            warningText2.gameObject.SetActive(true);
            warningText3.gameObject.SetActive(true);
        }
    }

    public void CleanAll()
    {
        warningText2.gameObject.SetActive(false);
        warningText3.gameObject.SetActive(false);
        warningText4.gameObject.SetActive(false);
        var whiteColor = new Color(236, 245, 248, 1);
        password1.image.color = whiteColor;
        password2.image.color = whiteColor;
        eye1.color = whiteColor;
        eye2.color = whiteColor;
    }
}
