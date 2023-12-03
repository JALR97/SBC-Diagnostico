using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Window;
    public void Salir()
    {
        Application.Quit();
    }

    public void atras()
    {
        Window.SetActive(false);
    }
    
    public void MostrarVentana()
    {
        Window.SetActive(true);
        
    }
}
