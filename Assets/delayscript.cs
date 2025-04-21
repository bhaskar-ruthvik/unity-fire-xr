using UnityEngine;

public class delayscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("empty3",10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
