using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    /*
    [SerializeField] private float animationDuration = 5f;
    
    private LineRenderer lineRenderer;
    public Transform[] linePoints;
    private Vector3 [] aux;

    private int pointsCount;
        // Start is called before the first frame update
    void Start()
    {
        Vector3 [] aux = new Vector3[pointsCount];
        lineRenderer = GetComponent<LineRenderer>();
       
        pointsCount = lineRenderer.positionCount;
       // linePoints = new Transform[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            aux[i] = linePoints[i].position;
        }
         lineRenderer.SetPositions(aux);
        StartCoroutine(AnimateLine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator AnimateLine(){
        float segmentDuration = animationDuration/pointsCount;
        for (int i = 0; i < pointsCount-1; i++)
        {
        float startTime = Time.time;
        Vector3 startPosition = linePoints[i].position;
        Vector3 endPosition = linePoints[i+1].position;

        Vector3 pos = startPosition;
        while(pos != endPosition){
            float t = (Time.time - startTime) / animationDuration;
            pos = Vector3.Lerp(startPosition, endPosition,t);
            for (int j = i+1; j < pointsCount; j++)
            {
                lineRenderer.SetPosition(j,pos);
            }
            
            yield return null;
            }  
        }
    }*/
}
