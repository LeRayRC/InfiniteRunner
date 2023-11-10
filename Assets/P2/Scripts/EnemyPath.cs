using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public List<GameObject> pathPoints_;
    public Color pathColor_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        DrawPath(pathPoints_);
    }

    void DrawPath(List<GameObject> pathPoints) //drawing the path in the Editor
    {
        Gizmos.color = pathColor_;
        for (int i=1; i < pathPoints.Count; i++)
        {
            Gizmos.DrawLine(pathPoints[i-1].transform.position, pathPoints[i].transform.position);
        }
        //Vector3[] pathPositions = new Vector3[pathPoints.Count];
        //for (int i = 0; i < pathPoints.Count; i++)
        //{
        //    pathPositions[i] = pathPoints[i].transform.position;
        //}
        //Vector3[] newPathPositions = CreatePoints(pathPositions);
        //Vector3 previosPositions = Interpolate(newPathPositions, 0);
        //Gizmos.color = pathColor;
        //int SmoothAmount = pathPoints.Count * 20;
        //for (int i = 1; i <= SmoothAmount; i++)
        //{
        //    float t = (float)i / SmoothAmount;
        //    Vector3 currentPositions = Interpolate(newPathPositions, t);
        //    Gizmos.DrawLine(currentPositions, previosPositions);
        //    previosPositions = currentPositions;
        //}
    }
}
