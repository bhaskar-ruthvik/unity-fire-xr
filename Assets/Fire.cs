using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    private float startIntensity = 5.0f;
    [SerializeField] private ParticleSystem firePS = null;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startIntensity = firePS.emission.rateOverTime.constant;
    }

    private void ChangeIntensity(){

        var emission = firePS.emission.rateOverTime;    
        emission.constant = currentIntensity * startIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntensity();
    }
}
