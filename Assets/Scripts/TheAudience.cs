using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAudience : MonoBehaviour
{
    private int audienceCampus;
    private int audienceFloor;
    

    public string[] name_list;
    public int audienceNumber;
    public Transform[] enterPoint;
    public Transform _point;
    public int AudienceFloor { get => audienceFloor; set => audienceFloor = value; }
    public int AudienceCampus { get => audienceCampus; set => audienceCampus = value; }

    void Start(){
        if(_point == null)
            _point = transform;
        
    }
}
