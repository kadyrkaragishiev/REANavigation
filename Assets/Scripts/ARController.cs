using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARController : MonoBehaviour
{
    [SerializeField] ARSession _session;
    [SerializeField] private ARCameraManager _arCameraManager;
    bool isSupported;
    private void Start()
    {
        StartCoroutine(SessionCheck());
    }
    public void StartSession()
    {
            UIDebug.Log("start");
        if (isSupported)
        {
            UIDebug.Log("session started!");
            if (!_session.isActiveAndEnabled)
            {
                _arCameraManager.gameObject.SetActive(true);
                _session.enabled = true;
            }
            else
            {
                UIDebug.Log("session stopped!");
                _arCameraManager.gameObject.SetActive(false);
                _session.enabled = false;
            }
        }
    }
    private IEnumerator SessionCheck()
    {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            isSupported = false;
        }
        else
        {
            isSupported = true;
        }

    }
}
