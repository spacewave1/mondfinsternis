using UnityEngine;

public class HitPoints : MonoBehaviour
{

    public int maximumHitPoints = 100;       // Maximal health of the gameobject with the attached script
    public int hp;          // The health attribute that will be shared in the network
	public bool hpHasChanged;
	private int damage;
	public GameObject explosionEffect;
	private Score score = Score.Instance;

    void Start()
    {
        hp = maximumHitPoints;
    }
    // The Gameobject with this script attached will take damage of the integer number amount
    public void ReduceHitPoints(int amount)
    {
        damage += amount;
        Debug.Log("damage received");

    }
    // on Collision, hit-point-objects deal damage to each other equal to their remaining hit points
    void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject);
		if (col.gameObject.GetComponent<HitPoints> () != null) { //Catches objects with no health-script at all
			col.gameObject.GetComponent<HitPoints> ().ReduceHitPoints (hp);
			hpHasChanged = true;
		}
    }
    void FixedUpdate()
    {
        hp -= damage;
        damage = 0;
        if (hp <= 0)
        {
            Debug.Log("object dead");
			if (gameObject.tag.Equals ("hostile")){
				GameObject explosionObject = Instantiate (explosionEffect, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation) as GameObject;
				Destroy (gameObject);
				score.addToScore (transform.position, maximumHitPoints); 
			}
			if (!gameObject.tag.Equals ("scene_object")) {
				Destroy (gameObject);
			}
			else {
				GameControllerScript.isGameRunning = false;
			}
        }
    }
}
