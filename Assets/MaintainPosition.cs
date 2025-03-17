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
  newX = mesh.transform.position.x;
        newY = mesh.transform.position.y + 0.5f;
        newZ = mesh.transform.position.z + 0.1f;
        rotationX = mesh.transform.rotation.eulerAngles.x +100f;
        rotationY = mesh.transform.rotation.eulerAngles.y +30f;
        rotationZ = mesh.transform.rotation.eulerAngles.z - 1f;
        transform.SetPositionAndRotation(new Vector3(newX,newY,newZ), Quaternion.Euler(new Vector3(rotationX,rotationY,rotationZ)));
    }

    // Update is called once per frame
    void Update()
    {   
        newX = mesh.transform.position.x;
        newY = mesh.transform.position.y + 0.5f;
        newZ = mesh.transform.position.z + 0.1f;
        rotationX = mesh.transform.rotation.eulerAngles.x +100f;
        rotationY = mesh.transform.rotation.eulerAngles.y;
        rotationZ = mesh.transform.rotation.eulerAngles.z - 1f;
        transform.SetPositionAndRotation(new Vector3(newX,newY,newZ), Quaternion.Euler(new Vector3(rotationX,rotationY,rotationZ)));
    }
}


//1.726, 2.96, 2.42 Coordinates of Extinguisher
//1.72, 3.497, 2.532 Coordinates of Smoke Effect