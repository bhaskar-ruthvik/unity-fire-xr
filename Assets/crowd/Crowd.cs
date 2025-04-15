using UnityEngine;
using UnityEngine.AI;

public class Crowd : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject Target;
    public GameObject[] AllTargets;
    private Vector3 diff;
    private Vector3 pos;
    private float distance;
    private float curDistance;
    private GameObject nearestTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
        nearestTarget=null;
        distance=Mathf.Infinity;
        GetComponent<Animation>().Play("Run_N");
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(Target!=null){
            if(Vector3.Distance(this.transform.position,Target.transform.position)<=0.5f){
                Target.transform.tag="Untagged";
                FindTarget();
            }
        }
    }

    public void FindTarget(){
        
        AllTargets = GameObject.FindGameObjectsWithTag("Target");

        foreach(GameObject t in AllTargets){
            diff = t.transform.position - pos;
            curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                nearestTarget = t;
                distance = curDistance;
            }

        }
        Target=nearestTarget;
        distance=Mathf.Infinity;
        if (Target!=null){
            navMeshAgent.destination=Target.transform.position;
        }
    }
}
