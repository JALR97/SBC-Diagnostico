using System;

using UnityEngine;

public class Needle : MonoBehaviour
{
    public bool toca = false;
    
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Line"))
        {
            toca = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Line"))
        {
            toca = false;
        }
    }
}
