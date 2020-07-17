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
    public BallShooter ballshooter;

    void Update()
    {

        switch (state)
        {
            case RorateState.Idle:
                if (Input.GetButtonDown("Fire1"))
                {
                    state = RorateState.Horizontal;
                }
                break;

            case RorateState.Horizontal:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(0, horizontalRotateSpeed * Time.deltaTime, 0));
                }

                else if (Input.GetButtonUp("Fire1"))
                {
                    state = RorateState.Vertical;
                }
                break;

            case RorateState.Vertical:
                if (Input.GetButton("Fire1"))
                {
                    transform.Rotate(new Vector3(-verticalRotateSpeed * Time.deltaTime, 0, 0));
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    state = RorateState.Ready;
                    ballshooter.enabled = true;
                }
                break;

            case RorateState.Ready:
                break;

        }
        
        
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.identity; // 0,0,0
        state = RorateState.Idle;
        ballshooter.enabled = false;
    }
}
