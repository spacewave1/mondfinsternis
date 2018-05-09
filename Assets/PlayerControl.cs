using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public bool gameOver;
    public GameObject GameOverCanvas;
    public GameObject counterHealth;

    //public Game

    void OnCollisionEnter(Collision col)
    {
        //Life decrease function
        Debug.Log(col.collider.name);
        if (col.collider.tag.Equals("hostile"))
        {
            Debug.Log("Collission with hostile");
            GetComponent<HitPoints>().ReduceHitPoints(col.collider.GetComponentInParent<WolfBehaviour>().damage);
        }
    }
        

    void Update()
    {
        if(GetComponent<HitPoints>().hp < 0)
        {
            gameOver = true;
            Time.timeScale = 0;
            GameOverCanvas.SetActive(true);
        }

        //counterHealth.GetComponent<RectTransform>().transform.localScale.x;
        
    }
}
