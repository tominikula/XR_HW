using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.NativeTypes;

public class CharacterMoveAssist : MonoBehaviour
{
    public XROrigin xRRig;
    public CharacterController characterController;
    public CharacterControllerDriver driver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterController();
    }
            /// <summary>
        /// Updates the <see cref="CharacterController.height"/> and <see cref="CharacterController.center"/>
        /// based on the camera's position.
        /// </summary>
        protected virtual void UpdateCharacterController()
        {
            if (xRRig == null || characterController == null)
                return;

            var height = Mathf.Clamp(xRRig.CameraInOriginSpaceHeight, driver.minHeight, driver.minHeight);

            Vector3 center = xRRig.CameraInOriginSpacePos;
            center.y = height / 2f + characterController.skinWidth;

            characterController.height = height;
            characterController.center = center;
        }
}
