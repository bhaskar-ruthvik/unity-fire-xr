using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f,1f)] private float currentIntensity= 1.0f;
    private float[] startIntensities = new float[0];
    [SerializeField] private ParticleSystem[] fireParticleSystems= new ParticleSystem[0];
    [SerializeField] private AudioSource fireSound;
    [SerializeField] private float regenDelay= 2.5f;   
    [SerializeField] private float regenRate= 0.1f;    
    [SerializeField] private float spreadRadius= 3f; // Fire spread radius
    [SerializeField] private float spreadTime= 5f;   // Time before fire spreads

    private bool isLit = true; 
    private float spreadTimer;
    private FlammableObject flammableObject;

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
        flammableObject = GetComponent<FlammableObject>();
        spreadTimer = spreadTime;
    }
    float timeLastWatered = 0;
    public bool TryExtinguish(float amount){
        timeLastWatered = Time.time;
        currentIntensity -= amount;
        ChangeIntensity();
        isLit = currentIntensity > 0;
        if (!isLit && flammableObject != null){
            flammableObject.Extinguish();
        }
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
    void Update(){
        if (isLit){
            // Fire regeneration
            if(currentIntensity<1 && (Time.time-timeLastWatered>=regenDelay)){
                currentIntensity+=regenRate*Time.deltaTime;
                ChangeIntensity();
            }

            // Fire spreading
            spreadTimer-=Time.deltaTime;
            if(spreadTimer<=0){
                SpreadFire();
                spreadTimer=spreadTime;
            }
        }
    }

    private void SpreadFire(){
        Collider[] colliders=Physics.OverlapSphere(transform.position,spreadRadius);
        foreach(var col in colliders){
            FlammableObject flammable=col.GetComponent<FlammableObject>();
            if(flammable!=null && flammable!=flammableObject){
                flammable.Ignite();
            }
        }
    }

    //this is to test that fire is propagating


/*
    private void SpreadFire(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, spreadRadius);
        
        foreach (var col in colliders){
            // Remove FlammableObject check to allow fire to spread everywhere
            Fire existingFire = col.GetComponent<Fire>();
            if (existingFire == null){ // Only spread if no fire is already there
                GameObject newFire = Instantiate(gameObject, col.transform.position, Quaternion.identity);
                newFire.GetComponent<Fire>().spreadTimer = spreadTime; // Reset spread timer
            }
        }
    }*/

}
