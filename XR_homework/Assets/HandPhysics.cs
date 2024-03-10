using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = target.position;
        rb.rotation = target.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //position
        var positionWithOffset = target.position + positionOffset;
        rb.velocity = (positionWithOffset - transform.position) / Time.fixedDeltaTime;

        //rotation
        var rotationWithOffset = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion rotationDifference = rotationWithOffset * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleinDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleinDegree * rotationAxis;
        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad) / Time.fixedDeltaTime;
    }
}

/*        
        
    [SerializeField] private float followSpeed = 1800f;
    [SerializeField] private float rotateSpeed = 6000f;
        //position
        var positionWithOffset = target.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, rb.position);
        rb.velocity = (positionWithOffset - rb.position)/Time.fixedDeltaTime;

        //rotation
        var rotationWithOffset = target.rotation * Quaternion.Euler(rotationOffset);
        var rotationDifference = rotationWithOffset * Quaternion.Inverse(rb.rotation);
        rotationDifference.ToAngleAxis(out float angleinDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleinDegree * rotationAxis;
        rb.angularVelocity = rotationAxis * angleinDegree * Mathf.Deg2Rad * rotateSpeed * Time.fixedDeltaTime;


        //position
        var positionWithOffset = target.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, rb.position);
        rb.velocity = (positionWithOffset - rb.position).normalized * (followSpeed * distance);

        //rotation
        var rotationWithOffset = target.rotation * Quaternion.Euler(rotationOffset);
        var rotationDifference = rotationWithOffset * Quaternion.Inverse(rb.rotation);
        rotationDifference.ToAngleAxis(out float angleinDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleinDegree * rotationAxis;
        rb.angularVelocity = rotationAxis * (angleinDegree * Mathf.Deg2Rad * rotateSpeed);


        //position
        var positionWithOffset = target.position + positionOffset;
        rb.velocity = (positionWithOffset - transform.position) / Time.fixedDeltaTime;

        //rotation
        var rotationWithOffset = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion rotationDifference = rotationWithOffset * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleinDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleinDegree * rotationAxis;
        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad) / Time.fixedDeltaTime;
*/
