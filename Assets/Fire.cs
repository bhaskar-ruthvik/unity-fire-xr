using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    private float startIntensity = 5.0f;
    [SerializeField] private ParticleSystem firePS = null;
    [SerializeField] private AudioSource fireSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startIntensity = firePS.emission.rateOverTime.constant;
        if (fireSound != null){
            fireSound.Play();
        }
    }

    private void ChangeIntensity(){

        var emission = firePS.emission.rateOverTime;    
        emission.constant = currentIntensity * startIntensity;
        if (fireSound != null){
            fireSound.volume = currentIntensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntensity();
    }
}
