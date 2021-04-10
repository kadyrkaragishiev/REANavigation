using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class CreatePath : MonoBehaviour
{
    public LineRenderer line;


    public Point _endPoint = new Point();
    public Vector3 _setPoint;


    public NavMeshAgent nav;
    public NavMeshPath path;
    public Camera cam;

    public GameObject place_point;

    void Start()
    {
        ARInterface.onStartPointChange += SetPath;
        ARInterface.onEndPointChange += SetPath;
    }
    public void SetPath(Vector3 pos)
    {
        Debug.Log(pos);
        transform.position = pos;
        if (_endPoint._pointPosition != null)
        {
            path = nav.path;
            if (nav.CalculatePath(_endPoint._pointPosition, path))
            {
                if (nav == null || path == null)
                    return;

                line.positionCount = path.corners.Length;

                for (int i = 0; i < path.corners.Length; i++)
                {
                    line.SetPosition(i, path.corners[i]);
                }
            }
        }
    }
    private void Update()
    {
        #if UNTIY_EDITOR
        if (Input.GetKeyDown(KeyCode.W))
        {
            cam.transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            cam.transform.position += new Vector3(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cam.transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            cam.transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cam.transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ARInterface.StartPointChange(Vector3.down);
        }
       if (Input.GetButtonDown("Fire1"))
       {
       Debug.Log("Mouse");
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           if (Physics.Raycast(ray,out hit,Mathf.Infinity))
           {
               if(EventSystem.current.IsPointerOverGameObject())
               {
                  return;
               }   
               else{
                    place_point.transform.position = hit.point;
                   _setPoint = hit.point;
               }
           }
       }
       #elif UNITY_ANDROID
       if (Input.touchCount > 0 )
        {
            UIDebug.Log("C");
            Touch t = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(t.position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && t.phase == TouchPhase.Stationary)
            {
                if(EventSystem.current.IsPointerOverGameObject())
                {
                   return;
                }   
                else{
                     place_point.transform.position = hit.point;
                    _setPoint = hit.point;
                }
                
            }
        }
        #endif

    }
}
public class Point
{
    public Vector3 _pointPosition;
}
