using UnityEngine;

public class MaintainPosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public MeshRenderer mesh;
    float newX;
    float newY;
    float newZ;
    float rotationX;
    float rotationY;
    float rotationZ;
    void Start()
    {
        newX = mesh.transform.position.x-0.17f;
        newY = mesh.transform.position.y + 0.511f;
        newZ = mesh.transform.position.z + 0.059f;
        rotationX = mesh.transform.rotation.eulerAngles.x -262.44f;
        rotationY = mesh.transform.rotation.eulerAngles.y +41.554f;
        rotationZ = mesh.transform.rotation.eulerAngles.z + 358.87f;
        transform.SetPositionAndRotation(new Vector3(newX,newY,newZ), Quaternion.Euler(new Vector3(rotationX,rotationY,rotationZ)));
    }

    // Update is called once per frame
    void Update()
    {   
        newX = mesh.transform.position.x-0.17f;
        newY = mesh.transform.position.y + 0.511f;
        newZ = mesh.transform.position.z + 0.059f;
        rotationX = mesh.transform.rotation.eulerAngles.x -262.44f;
        rotationY = mesh.transform.rotation.eulerAngles.y +41.554f;
        rotationZ = mesh.transform.rotation.eulerAngles.z + 358.87f;
        transform.SetPositionAndRotation(new Vector3(newX,newY,newZ), Quaternion.Euler(new Vector3(rotationX,rotationY,rotationZ)));
    }
}


//Vector3(-13.5419998,-3.92000008,-44.2659988) Vector3(270,267.885315,0) Coordinates of Extinguisher
//Vector3(-13.71,-3.40899992,-44.2070007) Vector3(7.56201744,309.438843,358.871979) Coordinates of Smoke Effect
//Vector3(270,0,267.88315)
//Vector3(7.56199598,309.439026,358.871979)