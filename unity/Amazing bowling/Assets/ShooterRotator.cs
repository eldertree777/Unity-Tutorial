using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotator : MonoBehaviour
{

    private enum RorateState
    {
        Idle,Vertical,Horizontal,Ready
    }

    private RorateState state = RorateState.Idle;
    public float verticalRotateSpeed = 360f;
    public float horizontalRotateSpeed = 360f;

    void Update()
    {
        if (state == RorateState.Idle)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                state = RorateState.Horizontal;
            }
        }
        else if (state == RorateState.Horizontal)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0));
            }

            else if (Input.GetButtonUp("Fire1"))
            {
                state = RorateState.Vertical;
            }
        }
        else if (state == RorateState.Vertical)
        {
            if (Input.GetButton("Fire1"))
            {
                transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0));
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                state = RorateState.Ready;
            }
        }
        
    }
}
