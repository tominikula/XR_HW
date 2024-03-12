using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = 0.025f;
    public bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public GameObject secretDoor;
    private bool puzzleStatus = false;
    private bool doorCanOpen = false;
    public float speed;

    private Vector3 openDoorPos = new Vector3(-5.48699999f,0,-4.98000002f);
    private Vector3 doorCurrentPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

        doorCurrentPos = secretDoor.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed && GetValue() + threshold >= 1){
            Released();
        }
        if(!isPressed && GetValue() - threshold <= 0){
            Pressed();
        }
        if(doorCanOpen && puzzleStatus){
            doorCurrentPos.x = Mathf.MoveTowards(doorCurrentPos.x, openDoorPos.x, Time.deltaTime * speed);
            secretDoor.transform.localPosition = doorCurrentPos;
        }
    }

    private float GetValue(){
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if(Math.Abs(value) < deadZone){
            value = 0;
        }
        return Math.Clamp(value, -1f, 2f);
    }

    private void Pressed(){
        isPressed = true;
        if(puzzleStatus){
            doorCanOpen = true;
        }
        Debug.Log("pressed");
    }
    private void Released(){
        isPressed = false;
        Debug.Log("Released");
    }
    internal void SetPuzzleStatus(bool status)
    {
        puzzleStatus = status;
    }
    internal bool GetPuzzleStatus()
    {
        return puzzleStatus;
    }
}
