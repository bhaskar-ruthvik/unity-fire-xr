using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabCheck : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    [SerializeField] private GameObject hose;

    void Start()
    {   
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {  
        Vector3 hosePosition= hose.transform.position;
        float hoseXRotation = hose.transform.rotation.eulerAngles.x;
      
        float hoseYRotation = hose.transform.rotation.eulerAngles.y;
        float hoseZRotation = hose.transform.rotation.eulerAngles.z;
        Debug.Log(hoseXRotation + ", " + hoseYRotation + ", " + hoseZRotation);
        hose.transform.SetPositionAndRotation(hosePosition, Quaternion.Euler(new Vector3(hoseXRotation-40f,hoseYRotation+60f,hoseZRotation-80f)));
        hoseXRotation = hose.transform.rotation.eulerAngles.x;
      
        hoseYRotation = hose.transform.rotation.eulerAngles.y;
        hoseZRotation = hose.transform.rotation.eulerAngles.z;
        Debug.Log(hoseXRotation + ", " + hoseYRotation + ", " + hoseZRotation);
        Debug.Log(gameObject.name + " has been grabbed!");
    }

    private void OnRelease(SelectExitEventArgs args)
    {   
        Vector3 hosePosition= hose.transform.position;
        float hoseXRotation = hose.transform.rotation.eulerAngles.x;
      
        float hoseYRotation = hose.transform.rotation.eulerAngles.y;
        float hoseZRotation = hose.transform.rotation.eulerAngles.z;
        Debug.Log(hoseXRotation + ", " + hoseYRotation + ", " + hoseZRotation);
        hose.transform.SetPositionAndRotation(hosePosition, Quaternion.Euler(new Vector3(hoseXRotation+40f,hoseYRotation-60f,hoseZRotation+80f)));
        hoseXRotation = hose.transform.rotation.eulerAngles.x;
      
        hoseYRotation = hose.transform.rotation.eulerAngles.y;
        hoseZRotation = hose.transform.rotation.eulerAngles.z;
        Debug.Log(hoseXRotation + ", " + hoseYRotation + ", " + hoseZRotation);
        Debug.Log(gameObject.name + " has been released!");
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}

//Vector3(355.970001,90,0)