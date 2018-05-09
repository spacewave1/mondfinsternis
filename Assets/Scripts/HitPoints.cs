using UnityEngine;
using UnityEngine.AI;


public class HitPoints : MonoBehaviour
{

    public int maximumHitPoints = 100;       // Maximal health of the gameobject with the attached script
    public int hp;          // The health attribute that will be shared in the network
    public bool hpHasChanged;
    private int damage;
    public GameObject explosionEffect;

    void Start()
    {
        hp = maximumHitPoints;
    }
    // The Gameobject with this script attached will take damage of the integer number amount
    public void ReduceHitPoints(int amount)
    {
        Debug.Log(amount);
        Debug.Log("damage received");
        damage += amount;

    }
    // on Collision, hit-point-objects deal damage to each other equal to their remaining hit points
    
    void FixedUpdate()
    {
        hp -= damage;
        damage = 0;
        if (hp <= 0)
        {
            Debug.Log("object dead");
            if (gameObject.tag.Equals("hostile"))
            {
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<AudioSource>().Stop();
                Destroy(gameObject, 5);
            }
            if (!gameObject.tag.Equals("player"))
            {
                Debug.Log("game overs");
                //Destroy(gameObject);
            }
            else
            {
                GameControllerScript.isGameRunning = false;
            }
        }
    }
}