using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Feedback;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.OpenXR.Input;



public class NewMonoBehaviourScript : MonoBehaviour
{
    public InputActionReference customButton;
    public GameObject a;
    [SerializeField] HapticImpulsePlayer controller;
    public bool isPressed = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customButton.action.started += ButtonWasPressed;
        customButton.action.performed += ActionWasPerformed;
        customButton.action.canceled += ButtonWasReleased;
        a.SetActive(false);
  }
    
    void ButtonWasPressed(InputAction.CallbackContext context){
        a.SetActive(true);
        isPressed = true;
        controller.SendHapticImpulse(1, 3);
        
    }

    void ActionWasPerformed(InputAction.CallbackContext context){

    }

    void ButtonWasReleased(InputAction.CallbackContext context){
       a.SetActive(false);
        isPressed = false;
        controller.SendHapticImpulse(1, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
