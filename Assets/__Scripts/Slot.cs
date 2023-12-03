using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private TMP_Text state;
    [SerializeField] private NGrama manager;
     
    // Update is called once per frame
    public void Flip() {
        if (manager.running)
        {
            return;
        }
        if (state.text == "H")
        {
            state.text = "T";
        }
        else
        {
            state.text = "H";
        }
    }

    public String GetFace()
    {
        return state.text;
    }
}
