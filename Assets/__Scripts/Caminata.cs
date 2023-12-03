using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Caminata : MonoBehaviour
{
    [SerializeField] private Transform drunk;
    public GameObject radioB;
    private bool toggleCardinal = true;
    public Transform center;
    [SerializeField] private LineRenderer _lineRenderer;

    private Vector2 movDir;
    [SerializeField] private float stepLength = 5;
    [SerializeField] private int steps = 20;

    public void flip()
    {
        toggleCardinal = !toggleCardinal;
    }
    public void Empezar()
    {
        //toggleCardinal = radioB.GetComponent<Toggle>().value;
        //drunk.position = new Vector3(0, 0, -1);
        //drunk.position = center.position;
        for (int i = 1; i < steps; i++)
        {
            if (toggleCardinal)
            {
                Vector2[] moves = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};
                int rand = Random.Range(0, 4);
                movDir = moves[rand] * stepLength;
            }
            else
            {
                Vector2 randVec = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                randVec.Normalize();
                movDir = randVec * stepLength;
            }
            
            //drunk.Translate(movDir);
            _lineRenderer.positionCount = i + 1;
            _lineRenderer.SetPosition(i, (Vector3)movDir + _lineRenderer.GetPosition(i - 1));
        }
        // _lineRenderer.positionCount = steps + 1;
        // _lineRenderer.SetPosition(steps, drunk.position + new Vector3(0, 1, 0));

    }
}
