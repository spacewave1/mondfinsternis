using UnityEngine;
using UnityEngine.Networking;

public class VolumeEffect : NetworkBehaviour {

	public enum StatusEffects {none, Slow, Pull};
	public StatusEffects appliedEffect;
	public float statusIntensityFactor;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider c) {
		Debug.Log ("Volume Trigger detected");
		if (c.gameObject.GetComponent<WolfBehaviour> () != null) {
			switch (appliedEffect) {
			case StatusEffects.none:
			//do nothing!
				break;
			case StatusEffects.Slow:
			
				c.gameObject.AddComponent<SlowEffect> ();
				c.GetComponent<SlowEffect> ().SetDuration (600);
				c.GetComponent<SlowEffect> ().SetFactor (statusIntensityFactor);
				c.GetComponent<SlowEffect> ().enabled = true;
				break;
			case StatusEffects.Pull:
				c.gameObject.AddComponent<PullEffect> ();
				c.GetComponent<PullEffect> ().SetOrigin (gameObject);
				c.GetComponent<PullEffect> ().SetFactor (statusIntensityFactor);
				c.gameObject.GetComponent<PullEffect> ().enabled = true;

				break;
			}
		}

	}
	void OnTriggerExit(Collider c) {
		if (c.gameObject.GetComponent<SlowEffect> () != null) {
			Destroy (c.gameObject.GetComponent<SlowEffect> ());
		
		}
	}
}
