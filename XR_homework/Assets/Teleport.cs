using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teleport : MonoBehaviour
{
    public GameObject xrRig;
    public InputActionReference teleportButton;
    private bool inStartingPosition = true;
    // Start is called before the first frame update
    void Start()
    {
        teleportButton.action.Enable();
        teleportButton.action.performed += ChangePosition;
    }

    void ChangePosition(InputAction.CallbackContext context){
        if(inStartingPosition){
            this.transform.position = new Vector3(-60f,2f,6f);
            inStartingPosition = false;
            Debug.Log("inStartingPosition = false");
        }else{
            this.transform.position = new Vector3(0f,2f,6f);
            inStartingPosition = true;
            Debug.Log("inStartingPosition = true");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
