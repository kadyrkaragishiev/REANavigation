#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BakingMono))]
public class BakingScript : Editor
{
    public override void OnInspectorGUI()
    {
        BakingMono bm = (BakingMono)target;
        if (GUILayout.Button("DisableAud"))
        {
            bm.AudienceWork();
        }
        if (GUILayout.Button("DisableMeshPlanes"))	
        {
            bm.MPlanesWork();
        }
        if (GUILayout.Button("DisableDisPlanes"))
        {
            bm.PlanesWork();
        }
        base.OnInspectorGUI();
    }
}
#endif
