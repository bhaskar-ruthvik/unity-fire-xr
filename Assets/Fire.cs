using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity = 1.0f;
    private float[] startIntensities = new float[0];
    [SerializeField] private ParticleSystem[] fireParticleSystems = new ParticleSystem[0];
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private float regenDelay= 2.5f;   
    [SerializeField] private float regenRate= 0.1f;    
    private bool isLit = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startIntensities = new float[fireParticleSystems.Length];
        for(int i=0; i< fireParticleSystems.Length; i++){
            startIntensities[i]= fireParticleSystems[i].emission.rateOverTime.constant;
        }
        if (fireSound != null){
            fireSound.Play();
        }
    }
    float timeLastWatered = 0;
    public bool TryExtinguish(float amount){
        timeLastWatered = Time.time;
        currentIntensity -= amount;
        ChangeIntensity();
        isLit = currentIntensity > 0;
        return !isLit;
    }
    private void ChangeIntensity(){
        for(int i=0; i< fireParticleSystems.Length; i++){
            var emission = fireParticleSystems[i].emission;    
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
  
        if (fireSound != null){
            fireSound.volume = currentIntensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLit && currentIntensity <= 1 && (Time.time - timeLastWatered >= regenDelay)){
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }
}
