using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Efectividad : MonoBehaviour
{
    [SerializeField] private RectTransform[] bars;
    [SerializeField] private TMP_Text Message;
    private int[] histCounters;
    private float sum;
    private bool running = false;
    public void Calcular()
    {
        if (running)
        {
            return;
        }

        running = true;
        Message.text = "";
        foreach (var bar in bars)
        {
            bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }

        histCounters = new[] { 0, 0, 0, 0 };
        sum = 0;

        for (int i = 0; i < 500; i++)
        {
            int rand;
            int x, y, z;
            
            rand = Random.Range(0, 100);
            if (rand <= 9)
            {
                x = 1;
            }else if (rand <= 29)
            {
                x = 2;
            }else if (rand <= 54)
            {
                x = 3;
            }else if (rand <= 79)
            {
                x = 4;
            }else if (rand <= 94)
            {
                x = 5;
            }else
            {
                x = 6;
            }
            
            rand = Random.Range(0, 100);
            if (rand <= 24)
            {
                y = 1;
            }else if (rand <= 54)
            {
                y = 2;
            }else if (rand <= 79)
            {
                y = 3;
            }else 
            {
                y = 4;
            }
            
            rand = Random.Range(0, 10);
            if (rand <= 2)
            {
                z = 1;
            }else if (rand <= 7)
            {
                z = 2;
            }else
            {
                z = 3;
            }
            
            int w = WEcuation(x, y, z);
            sum += w;
            if (w <= 10)
            {
                histCounters[0] += 1;
                bars[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, histCounters[0]);
            }else if (w <= 20)
            {
                histCounters[1] += 1;
                bars[1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, histCounters[1]);
            }else if (w <= 30)
            {
                histCounters[2] += 1;
                bars[2].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, histCounters[2]);
            }else
            {
                histCounters[3] += 1;
                bars[3].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, histCounters[3]);
            }
        }

        Message.text = $"Podemos observar el comportamiento de la variable W. El promedio fue {sum/1000}";
        running = false;
    }

    public int WEcuation(int x, int y, int z)
    {
        return x + (4 * y) + (3 * z);
    }
}
