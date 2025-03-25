using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] private float amountExtinguishedPerSecond = 0.5f;
    [SerializeField] private AudioSource extinguisherSound; 

    private bool isPlayingSound = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.activeInHierarchy && Physics.Raycast(obj.transform.position, obj.transform.forward, out RaycastHit hit,100f) && hit.collider.TryGetComponent(out Fire fire)){
            fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
        

            if(!isPlayingSound && extinguisherSound!=null){ // Play sound if not already playing
                extinguisherSound.Play();
                isPlayingSound=true;
            }
        }
        else{
            if(isPlayingSound && extinguisherSound!=null){ //Stop sound when not in use
                extinguisherSound.Stop();
                isPlayingSound=false;
            }
        }
    }
}
