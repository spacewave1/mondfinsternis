using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : StatusEffect {

		protected override void ApplyStatusEffect(GameObject origin) {
				if (gameObject.GetComponent<WolfBehaviour>() != null){
					gameObject.GetComponent<WolfBehaviour>().speed *= (1/factor);
        			gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}	else {
					duration = 0;
			}
 		}

    protected override void OnDestroy(){
				gameObject.GetComponent<WolfBehaviour>().speed *= factor;
    }
}
