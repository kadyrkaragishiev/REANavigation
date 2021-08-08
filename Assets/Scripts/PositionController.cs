using UnityEngine;
using System;
using Lean.Touch;
using UnityEngine.Serialization;

public class PositionController : MonoBehaviour
{
    [SerializeField]
    private float currentCampusFloorCount;
    [FormerlySerializedAs("currentStep")]
    [SerializeField]
    private int CurrentStep = 0;

    [SerializeField]
    private float Sensitivity;
    public float CurrentCampusFloorCount { get => currentCampusFloorCount; set => currentCampusFloorCount = value; }

    private void Start()
    {
    }
    private void OnEnable()
    {
        LeanTouch.OnFingerUpdate += CalculateDelta;
        
    }

    private void CalculateDelta(LeanFinger finger)
    {
        transform.position += new Vector3(finger.ScreenDelta.x * LeanTouch.ScreenFactor, 0, finger.ScreenDelta.y * LeanTouch.ScreenFactor) * -7f;
    }
    public void SetOnTop()
    {
        if ((CurrentStep + 1) < currentCampusFloorCount)
        {
            transform.position = new Vector3(transform.position.x, CurrentStep * 10 + 10f, transform.position.z);
            CurrentStep += 1;
        }
    }
    public void SetOnBottom()
    {
        if (CurrentStep > 0)
        {
            var position = transform.position;
            position = new Vector3(position.x, CurrentStep * 10f - 10f, position.z);
            transform.position = position;
            CurrentStep -= 1;
        }
    }

    public void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.position = new Vector3(transform.position.x + horizontal, transform.position.y,
            transform.position.z + vertical);
        PinchWork();
    }

    private void PinchWork()
    {
        var pinchScale = LeanGesture.GetPinchScale(LeanTouch.Fingers);
        if (pinchScale != 1.0f)
        {
            pinchScale = Mathf.Pow(pinchScale, Sensitivity);
        }
        UIDebug.Log(pinchScale);

    }
}

