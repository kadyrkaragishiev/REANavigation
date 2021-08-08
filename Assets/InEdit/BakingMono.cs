using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakingMono : MonoBehaviour
{
    public bool AudBool;
    public bool MPlanesBool;
    public bool PlanesBool;
    public GameObject[] aud;
    public GameObject[] mplanes;
    public GameObject[] planes;
    public void AudienceWork()
    {
        aud = GameObject.FindGameObjectsWithTag("Audience");
        foreach (var g in GameObject.FindGameObjectsWithTag("Audience"))
        {
            g.GetComponent<MeshRenderer>().enabled = AudBool;
        }
    }
    public void MPlanesWork()
    {
        mplanes = GameObject.FindGameObjectsWithTag("MeshPlanes");
        foreach (var g in mplanes)
        {
            g.GetComponent<MeshRenderer>().enabled = MPlanesBool;
        }
    }
    public void PlanesWork()
    {
        planes = GameObject.FindGameObjectsWithTag("Planes");
        foreach (var g in planes)
        {
            g.GetComponent<MeshRenderer>().enabled = PlanesBool;
        }
    }
}
