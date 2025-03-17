using UnityEngine;
using UnityEngine.InputSystem;



public class NewMonoBehaviourScript : MonoBehaviour
{
    public InputActionReference customButton;
    public GameObject a;
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
    }

    void ActionWasPerformed(InputAction.CallbackContext context){

    }

    void ButtonWasReleased(InputAction.CallbackContext context){
       a.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
