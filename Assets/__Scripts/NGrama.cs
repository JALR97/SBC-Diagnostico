using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class NGrama : MonoBehaviour
{
    [SerializeField] private Slot[] Player1, Player2;
    [SerializeField] private TMP_Text[] cinta;
    [SerializeField] private TMP_Text sign;
    private string[] Match1, Match2;
    public bool running = false;
    
    public void StartGame()
    {
        if (running)
        {
            return;
        }
        running = true;
        sign.text = "";
        
        for (int i = 0; i < cinta.Length; i++)
        {
            cinta[i].text = "-";
        }
        
        Match1 = new string[3]{Player1[0].GetFace(), Player1[1].GetFace(), Player1[2].GetFace()};
        Match2 = new string[3]{Player2[0].GetFace(), Player2[1].GetFace(), Player2[2].GetFace()};

        while (running)
        {
            for (int i = cinta.Length - 1; i > 0; i--)
            {
                cinta[i].text = cinta[i - 1].text;
            }
            cinta[0].text = FlipCoin();
            Check();
        }
    }
    
    private void Ganador(int player)
    {
        sign.text = $"El jugador {player} ha Ganado";
    }
    
    public string FlipCoin()
    {
        string[] choices = new string[2]{"H", "T"};
        return choices[Random.Range( 0, choices.Length)];
    }

    private void Check()
    {
        Debug.Log($"cinta {cinta[0].text}, {cinta[1].text}, {cinta[2].text}");
        Debug.Log($"P1 {Match1[0]}, {Match1[1]}, {Match1[2]}");
        Debug.Log($"P2 {Match2[0]}, {Match2[1]}, {Match2[2]}");
        if (cinta[0].text == Match1[0] && cinta[1].text == Match1[1] && cinta[2].text == Match1[2])
        {
            Ganador(1);
            running = false;
        }

        if (cinta[0].text == Match2[0] && cinta[1].text == Match2[1] && cinta[2].text == Match2[2])
        {
            Ganador(2);
            running = false;
        }
    }
}
