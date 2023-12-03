using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public TMP_Text[] demand;

    public void Calcular()
    {
        for (int i = 0; i < demand.Length; i++)
        {
            int rand = Random.Range(0, 100);
            int valor;
            if (rand <= 4)
            {
                valor = 1;
            }else if (rand <= 14)
            {
                valor = 2;
            }else if (rand <= 29)
            {
                valor = 3;
            }else if (rand <= 59)
            {
                valor = 4;
            }else if (rand <= 89)
            {
                valor = 5;
            }else
            {
                valor = 6;
            }

            demand[i].text = valor.ToString();
        }
    }
}
    