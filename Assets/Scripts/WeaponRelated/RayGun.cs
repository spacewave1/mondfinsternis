using UnityEngine;
using System.Collections;

// this class is used for any kind of weapon, that use Rays of any kind, like lasercannons,
//Railguns etc.. with no physical projectile
// it holds the barrels (as muzzles) used to fire
// if more than one muzzle is used, the class cycles through the muzzles
public class RayGun : Weapon
{

    public int damage = 25;
    public float range = 50f;
    public Material rayMaterial;
    private WaitForSeconds rayDuration = new WaitForSeconds(0.1f);		// How long the shot will be visible
    private AudioSource gunAudio;
    public LineRenderer line;
    public enum StatusEffects { none, Slow, Pull };
    public StatusEffects appliedEffect;
    public int statusDuration;
    public int statusIntensityFactor;
	public ParticleSystem particles;

    public override void Start()
    {
        base.Start();
			if (PlayerWeapons.Instance.gameObject.GetComponent<LineRenderer> () != null) {
				line = PlayerWeapons.Instance.gameObject.GetComponent<LineRenderer> ();
			} else {
				Debug.Log ("No line renderer found for this ray-gun type weapon!");
			}
    }
    // Update is called once per frame
    protected override void SingleShot()
    {
        Vector3 rayOrigin = muzzle.transform.position;
        RaycastHit hit;
        line.SetPosition(0, muzzle.transform.position);
        if (Physics.Raycast(rayOrigin, muzzle.transform.forward, out hit, range))
        {
            GameObject target = hit.collider.gameObject;
            line.SetPosition(1, hit.point);
            if (target.GetComponent<HitPoints>() != null && target.tag.Equals("hostile"))
            {
                target.GetComponent<HitPoints>().ReduceHitPoints(damage);
            }
            switch (appliedEffect)
            {
                case StatusEffects.none:
                    //do nothing!
                    break;
                case StatusEffects.Slow:

                    target.AddComponent<SlowEffect>();
                    target.GetComponent<SlowEffect>().SetDuration(statusDuration);
                    target.GetComponent<SlowEffect>().SetFactor(statusIntensityFactor);
                    target.GetComponent<SlowEffect>().enabled = true;
                    break;
                case StatusEffects.Pull:
                    target.AddComponent<PullEffect>();
                    target.GetComponent<PullEffect>().SetOrigin(PlayerWeapons.Instance.gameObject);
                    target.GetComponent<PullEffect>().SetFactor(statusIntensityFactor);
                    target.gameObject.GetComponent<PullEffect>().enabled = true;

                    break;
            }
        }
        else
        {
            line.SetPosition(1, rayOrigin + (muzzle.transform.forward * range));

        }
        //StartCoroutine(RenderLine());

			PlayerWeapons.Instance.ShootRay (rayMaterial, cooldown);
		
		//PlayerWeapons.Instance.EnableRay(rayMaterial);
		GetComponent<AudioSource>().Play();
        Debug.Log("1");

    }
    IEnumerator RenderLine()
    {
        Debug.Log("2");
        line.material = rayMaterial;
      	line.enabled = true;
		particles.Play ();
      	yield return rayDuration;
        line.enabled = false;
    }
}
