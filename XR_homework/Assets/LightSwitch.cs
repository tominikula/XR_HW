using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light lightObj;
    public InputActionReference lightButtonPressed;
    // Start is called before the first frame update
    void Start()
    {
        lightObj = GetComponent<Light>();
        lightButtonPressed.action.Enable();
        lightButtonPressed.action.performed += (context) => {lightObj.color = Color.red;};
    }

    // Update is called once per frame
    void Update()
    {

    }
}
/*
        bool value = lightSwitchPressed.action.ReadValue<bool>();
        if(value){
            light.color = new Color(1,0,0,1);
        }
*/

/*      
        light = GetComponent<Light>();
        lightButtonPressed.action.Enable();
        lightButtonPressed.action.performed += (context) => {light.color = Color.red;};
*/

/*
        lightButtonPressed.action.Enable();
        lightObj = GetComponent<Light>();
        bool value = lightButtonPressed.action.ReadValue<bool>();
        if(value){
            lightObj.color = Color.red;
        }
*/