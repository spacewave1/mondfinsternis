using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PullEffect : StatusEffect
{

	protected override void Update()
	{
        ApplyStatusEffect(origin);
	}

		protected override void ApplyStatusEffect(GameObject origin)
    {
				duration = 0;
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position,
				origin.transform.position, factor * Time.deltaTime);
    }
		protected override void OnDestroy() { }
}
