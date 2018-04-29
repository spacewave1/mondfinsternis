using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class VRSwipe : MonoBehaviour
{

    // Use this for initialization
    public Hand hand;
    private bool tracking;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float minDistance;
    public enum Position { left, right }
    public Position position;
    public WeaponHUDBehaviour hud;


    // Update is called once per frame
    void Update()
    {
        var device = hand.controller;

        if (device.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            startPosition = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x, device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
            Debug.Log("Touch Start: " + startPosition.x + "/" + startPosition.y);
            tracking = true;
        }
        if (device.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            Debug.Log("Touch End: " + endPosition.x + "/" + endPosition.y);
            tracking = false;
            SwipeControl();
        }
        else if (tracking)
        {
            endPosition = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x, device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
        }

    }
    void SwipeControl()
    {
        Vector2 swipeVector = new Vector2((endPosition.x - startPosition.x), (endPosition.y - startPosition.y));
        Debug.Log("Swipe Vector: " + swipeVector.x + "/" + swipeVector.y);
        if (Mathf.Abs(swipeVector.y) > Mathf.Abs(swipeVector.x))
        {

            //SWIPE UP-DOWN
            if (Mathf.Abs(swipeVector.y) > minDistance)
            {
                if (swipeVector.y > 0)
                {
                    //UPWARDS
                }
                else
                {
                    //DOWNWARDS
                }
            }
        }
        else
        {
            //SWIPE LEFT-RIGHT
            if (Mathf.Abs(swipeVector.x) > minDistance)
            {
                if (swipeVector.x > 0)
                {
                    //TO RIGHT
                    switch (position)
                    {
                        case Position.left:
                            PlayerWeapons.Instance.NextSecondary();
                            break;
                        case Position.right:
                            PlayerWeapons.Instance.NextPrimary();
                            break;
                        default:
                            PlayerWeapons.Instance.NextPrimary();
                            break;
                    }
                    if(hud!= null) hud.nextWeapon();
                }
                else
                {
                    //TO LEFT
                    switch (position)
                    {
                        case Position.left:
                            PlayerWeapons.Instance.PreviousSecondary();
                            break;
                        case Position.right:
                            PlayerWeapons.Instance.PreviousPrimary();
                            break;
                        default:
                            PlayerWeapons.Instance.PreviousPrimary();
                            break;
                    }
                    if (hud != null) hud.previousWeapon();
                }
            }

        }
    }
}