using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ARController : MonoBehaviour
{
    [SerializeField] private GameObject AR;
    [SerializeField] ARSession _session;
    [SerializeField] private GameObject _camera;
    bool isSupported;
    private void Start()
    {
        StartCoroutine(SessionCheck());
        Invoke("StartSession", 1f);
    }
    public void StartSession()
    {
            UIDebug.Log("start");
        if (isSupported)
        {
            UIDebug.Log("session started!");
            if (!_session.isActiveAndEnabled)
            {
                _session.enabled = true;
                _camera.SetActive(false);
            }
            else
            {
                UIDebug.Log("session stopped!");
                _session.enabled = false;
                _camera.SetActive(true);
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

public static class ARInterface
{
    public delegate void OnStartPointChange(Vector3 pos);
    public static event OnStartPointChange onStartPointChange;

    public static void StartPointChange(Vector3 position)
    {
        onStartPointChange?.Invoke(position);
    }
    public delegate void OnEndPointChange(Vector3 pos);
    public static event OnEndPointChange onEndPointChange;

    public static void EndPointChange(Vector3 position)
    {
        onEndPointChange?.Invoke(position);
    }
}
