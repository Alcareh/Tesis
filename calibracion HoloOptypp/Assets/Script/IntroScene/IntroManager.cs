using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [Header("User UX")] 
    [SerializeField] private TMPro.TMP_InputField passwordField;

    public void ShowHidePassword()
    {
        if (passwordField.contentType == TMP_InputField.ContentType.Password)
        {
            passwordField.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            passwordField.contentType = TMP_InputField.ContentType.Password;
        }
        passwordField.ForceLabelUpdate();
    }
}
