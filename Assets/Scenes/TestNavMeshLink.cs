using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNavMeshLink : MonoBehaviour
{
    public LineRenderer line;
    public UnityEngine.AI.NavMeshAgent nav;
    public UnityEngine.AI.NavMeshPath path;
    public Transform end_Point;

    private void Start()
    {
    }
    public void SetPath()
    {
        nav.SetDestination(end_Point.position);
        Invoke("CalculatePath", 0.5f);
    }
    private void CalculatePath()
    {
        if (end_Point.position != null)
        {
            path = nav.path;
            if (nav == null || path == null)
            {
                Debug.Log("null");
                return;
            }
            line.positionCount = path.corners.Length;
            Debug.Log(line.positionCount);
            for (int i = 0; i < path.corners.Length; i++)
            {
                line.SetPosition(i, path.corners[i]);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SetPath();
        }
    }
}
