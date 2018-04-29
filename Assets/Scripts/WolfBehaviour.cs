using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfBehaviour : MonoBehaviour {

    public float speed;
    public Transform target;
    public Collider detectionZone;
    public Transform targetHand;

    private Animator anim;
    private Rigidbody rigidbody;

    private List<Collider> detectedColliders;
    private Collider cache;
    private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {

        navMeshAgent = GetComponent<NavMeshAgent>();
        detectedColliders = new List<Collider>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        targetHand = GameObject.FindGameObjectWithTag("SuitedForWolfTeeth").transform;

        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        transform.LookAt(target);
        navMeshAgent.SetDestination(target.position);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void TakeDamage(int amount)
    {
        if(GetComponent<HitPoints>() != null)
        {
            GetComponent<HitPoints>().ReduceHitPoints(amount);
        }
    }

    private Collider CheckForPossibleCollissions()
    {
        foreach (Collider collider in detectedColliders)
        {
            //Debug.Log((collider.transform.position - transform.position).magnitude);
            //Debug.Log(transform.forward);
            Debug.DrawLine(transform.position, collider.transform.position, Color.black);
            if ((collider.transform.position - transform.position).magnitude < 5f)
            {
                //Debug.Log((collider.transform.position - transform.position).magnitude);
                return collider;
            }
        }
        return null;
    }

    private void ChangeDirection(Collider col)
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, (Quaternion.AngleAxis(-90, Vector3.up)), 1/(col.transform.position - transform.position).magnitude * Time.deltaTime);
        //rigidbody.MovePosition(transform.position + Vector3.Lerp(transform.forward, transform.right, 1/(col.transform.position-transform.position).magnitude) * Time.deltaTime * speed);
        //transform.LookAt(target);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Layer of Collider: " + col.gameObject.layer);
        if(col.gameObject.layer == 8)
            detectedColliders.Add(col);
    }

    void OnTriggerExit(Collider col)
    {
        detectedColliders.Remove(col);
    }
}

class WolfState : StateMachineBehaviour
{
    [SerializeField] private float speed = 0.4f;
}