using UnityEngine;
using UnityEngine.Networking;


//This behaviour class is not used anymore (replaced by HitPoints-System)
public class ProjectileBehaviour : NetworkBehaviour
{
    public enum Acceleration { INSTANT, LINEAR, EXPONENTIAL };
    public Acceleration accelerationType;
    [Range(0.0f, 1.0f)]
    public float accelerationValue;
    public float velocity = 100;
    private float currentVelocity;
    public float timeToLive = 5;

    void Start()
    {
      Destroy(gameObject, timeToLive);
    }

    void Update()
    {
        currentVelocity = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
        if (currentVelocity < velocity)
        {
            switch (accelerationType)
            {
                case Acceleration.INSTANT:
                    currentVelocity = velocity;
                    break;
                case Acceleration.LINEAR:
                    currentVelocity += accelerationValue;
                    break;
                case Acceleration.EXPONENTIAL:
                    currentVelocity = Mathf.Pow(1.445f + accelerationValue, currentVelocity);
                    break;
                default:
                    break;

            }
            if (currentVelocity > velocity){
              currentVelocity = velocity;
            }
        }
        Debug.Log("velocity2" + currentVelocity);
        gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward * currentVelocity;

    }
}
