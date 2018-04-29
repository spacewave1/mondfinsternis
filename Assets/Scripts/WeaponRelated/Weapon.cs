using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Weapon : MonoBehaviour {

	public GameObject muzzle;
    public float nextFire;
    public float cooldown = 0f;

    public virtual void Start()
    {
        /**muzzles = new GameObject[barrelsUsed.Length];
          for (int i = 0; i< barrelsUsed.Length;i++){
              switch (barrelsUsed[i]) {
                case Muzzle.Right:
                    muzzles[i] = PlayerWeapons.Instance.GetMuzzle(0);
                    break;
				/*case Muzzle.BottomRight:
					muzzles[i] = PlayerWeapons.Instance.GetMuzzle(1);
					break;*/
				/**case Muzzle.Left:
					muzzles[i] = PlayerWeapons.Instance.GetMuzzle(1);
					break;
				/*case Muzzle.BottomLeft:
					muzzles[i] = PlayerWeapons.Instance.GetMuzzle(3);
					break;
                }
        }*/
        //muzzleIndex = 0;
        nextFire = 0;
    }




    public void Update(){

    }
    // Use this for initialization
    public void Fire()
    {
	  //SingleShot();
      //if (muzzles.Length > 0){
          //TODO Add Fire behaviour
        if (nextFire < Time.time)
        {
          nextFire = Time.time + cooldown;
          /*if (multishot){
            MultiShot();
          } else {*/
            SingleShot();
          //}
        } //else { Debug.Log("cooldown " + nextFire + "//" + Time.time);}
      //}
      /*else {
          Debug.Log("no muzzle applied to weapon...");
      }*/
    }
    //protected abstract void FireWeapon();
    /**private void MultiShot(){
      foreach (GameObject muzzle in muzzles){
        SingleShot();
      }
    }*/
    protected abstract void SingleShot();

    /**protected void NextMuzzle(){
      if (muzzleIndex >= (muzzles.Length-1)){
        muzzleIndex = 0;
      } else {
        muzzleIndex++;
      }
    }*/
		public void SetMuzzle(GameObject muzzle){
			this.muzzle = muzzle;
		}
	public void SetToPrimary(){
			muzzle = PlayerWeapons.Instance.GetRightMuzzle ();
	}
}
