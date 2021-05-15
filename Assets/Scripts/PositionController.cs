using UnityEngine;
using System;
using Lean.Touch;
public class PositionController : MonoBehaviour
{
    [SerializeField]
    private float currentCampusFloorCount;
    [SerializeField]
    private int currentStep = 0;
    public float CurrentCampusFloorCount { get => currentCampusFloorCount; set => currentCampusFloorCount = value; }

    private void Start()
    {
    }
    private void OnEnable()
    {
        LeanTouch.OnFingerUpdate += CalculateDelta;
    }
    public void CalculateDelta(LeanFinger finger)
    {
        transform.position += new Vector3(finger.ScreenDelta.x * LeanTouch.ScreenFactor, 0, finger.ScreenDelta.y * LeanTouch.ScreenFactor) * -3f;
    }
    public void SetOnTop()
    {
        if ((currentStep + 1) < currentCampusFloorCount)
        {
            transform.position = new Vector3(transform.position.x, currentStep * 10 + 10f, transform.position.z);
            currentStep += 1;
        }
    }
    public void SetOnBottom()
    {
        if (currentStep > 0)
        {
            transform.position = new Vector3(transform.position.x, currentStep * 10f - 10f, transform.position.z);
            currentStep -= 1;
        }
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y,
            transform.position.z + vertical);
    }
}

