using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.UIElements;

public class Buffon : MonoBehaviour
{
    [SerializeField] private GameObject needlePrefab, NContainer, EmptyPrefab;
    public Collider2D box;

    [SerializeField] private int needleNum;
    [SerializeField] private TMP_InputField field;
    [SerializeField] private TMP_Text final;
    
    public void startAg()
    {
        final.text = "";
        Destroy(NContainer);
        NContainer = GameObject.Instantiate(EmptyPrefab, transform);
        int.TryParse(field.text, out needleNum);
        Bounds bounds = box.bounds;

        for (int i = 0; i < needleNum; i++)
        {
            float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
 
            Vector3 position = bounds.center + new Vector3(offsetX, offsetY, -1);
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            GameObject newNeedle = GameObject.Instantiate(needlePrefab, position, rotation, NContainer.transform);
                    
        }
    }

    public void CountAg()
    {
        if (NContainer.transform.childCount == 0 )
            return;

        int touchCount = 0;
        Debug.Log($"Childs {NContainer.transform.childCount}");
        for (int i = 0; i < NContainer.transform.childCount; i++)
        {
            if (NContainer.transform.GetChild(i).GetComponent<Needle>().toca)
            {
                touchCount += 1;
            }
        }

        final.text = $"Con n:{touchCount} agujas tocando una linea, de N:{needleNum} agujas lanzadas. El calculo de pi a partir de estos N/n es igual a: {(float)needleNum/touchCount}";
    }
}
