using UnityEngine;

public class FlammableObject : MonoBehaviour
{
    [SerializeField] private bool isFlammable = true; 
    [SerializeField] private float burnTime = 10f; // Time before burning out
    [SerializeField] private Material burntMaterial; // Burnt texture
    [SerializeField] private GameObject firePrefab; // Fire effect
    private float currentBurnTime;
    private bool isOnFire = false;
    private Renderer objectRenderer;
    private Fire fireInstance;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        currentBurnTime = burnTime;
    }

    public void Ignite()
    {
        if (!isFlammable || isOnFire) return;

        isOnFire = true;
        fireInstance = Instantiate(firePrefab, transform.position, Quaternion.identity).GetComponent<Fire>();
        fireInstance.transform.parent = this.transform;
    }

    public void Extinguish()
    {
        if (!isOnFire) return;

        isOnFire = false;
        if (fireInstance != null) Destroy(fireInstance.gameObject);

        // Change to burnt texture if available
        if (burntMaterial != null && objectRenderer != null)
        {
            objectRenderer.material = burntMaterial;
        }
    }

    private void Update()
    {
        if (isOnFire)
        {
            currentBurnTime -= Time.deltaTime;
            if (currentBurnTime <= 0)
            {
                Destroy(gameObject); // Burned completely
            }
        }
    }
}
