using System.Collections;
using System;
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

    public UIController uIController;


    public GameObject place_point;

    void Start()
    {
    }
    public void SetPath()
    {
        nav.SetDestination(_endPoint._pointPosition);
        Invoke("CalculatePath", 0.5f);

    }
    private void CalculatePath()
    {
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
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            ray.direction *= 20f;
            Debug.DrawRay(ray.origin, ray.direction*20f);
            if (Physics.Raycast(ray, out hit))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                else
                {
                    place_point.transform.position = hit.point;
                    _setPoint = hit.point;
                }
            }
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(t.position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) && t.phase == TouchPhase.Stationary)
            {
                if (IsPointerOverUIObject(t.position))
                {
                    return;
                }
                else
                {
                    place_point.transform.position = hit.point;
                    _setPoint = hit.point;
                }

            }
        }
#endif
    }
    bool IsPointerOverUIObject(Vector2 pos)
    {
        if (EventSystem.current == null)
        {
            return false;
        }
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
public class Point
{
    public Vector3 _pointPosition;
}
