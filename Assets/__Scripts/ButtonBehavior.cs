using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject WindowTarget;
    [SerializeField] private GameObject Window_Self;
    public void Salir()
    {
        Application.Quit();
    }

    public void atras()
    {
        Window_Self.SetActive(false);
    }
    
    public void MostrarVentana()
    {
        WindowTarget.SetActive(true);
    }
    public void NextVentana()
    {
        WindowTarget.SetActive(true);
        Window_Self.SetActive(false);
    }
}
