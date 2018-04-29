using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{

    public float duration = 1;
    protected float wearOff;
    public float factor = 1;
    protected GameObject origin;

    protected void Awake()
    {
        enabled = false;
        Debug.Log("check1");
    }
    protected void OnEnable()
    {
        ApplyStatusEffect(origin);
        wearOff = Time.time + duration;

        Debug.Log("check2");
    }
    protected virtual void Update()
    {

      Debug.Log("check3");
        if (Time.time > wearOff && duration > 0)
        {
            Destroy(this);
        }
    }
    protected abstract void ApplyStatusEffect(GameObject origin);
    protected abstract void OnDestroy();
    public void SetOrigin(GameObject origin){
      this.origin = origin;
    }
    public void SetFactor(float factor){
      this.factor = factor;
    }
    public virtual void SetDuration(float duration){
      this.duration = duration;
    }
}
