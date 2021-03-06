using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;
using System.Collections;

public class ITTest : MonoBehaviour
{
    public ARTrackedImageManager manager;
    public TextMeshProUGUI TextAbout;
    public TheAudience[] audiences;
    public CreatePath createPath;
    private Dictionary<int, TheAudience> viewPanels = new Dictionary<int, TheAudience>();
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        foreach(var audience in audiences)
        {
            viewPanels.Add(audience.audienceNumber, audience);
        }
    }
    void OnEnable()
    {
        manager.trackedImagesChanged += OnTrackedImagesChanged;
    }
    void OnDisable()
    {
        manager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private ARTrackedImage _lastTracked;
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            if(trackedImage.trackingState == TrackingState.Tracking)
            {
                if (trackedImage != _lastTracked)
                {
                    _lastTracked = trackedImage;
                    int f = int.Parse(trackedImage.referenceImage.name);
                    GetInformation(viewPanels[f]);
                    createPath.transform.position = viewPanels[f]._point.position;
                    break;
                }
            }
        }
    }
    void GetInformation(TheAudience audience){
        
    }
}
