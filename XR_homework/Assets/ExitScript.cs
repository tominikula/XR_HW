using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public PhysicsButton button;
    public XROrigin xRRig;
    public GameObject portal;
    public float minDistance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(xRRig.transform.position, portal.transform.position);
        if(button.GetPuzzleStatus()){
            Debug.Log(distance);
        }
        if(button.GetPuzzleStatus() && distance < minDistance){
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
