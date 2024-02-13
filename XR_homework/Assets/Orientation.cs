using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public Transform mainCamera;
    public Transform lensCamera;
    public Transform lens;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerDirection = lens.InverseTransformPoint(mainCamera.position);
        Vector3 viewDirection = lens.TransformPoint(new Vector3(-playerDirection.x, -playerDirection.y, -playerDirection.z));
        lensCamera.transform.LookAt(viewDirection, lens.up);
    }
}
