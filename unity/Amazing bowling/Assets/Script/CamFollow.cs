using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public enum State
    {
        Idle,Ready,Tracking
    }

    private State state
    {
        set
        {
            switch (value)
            {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize;
                    break;

                case State.Ready:
                    targetZoomSize = readyReadyZoomSize;
                    break;

                case State.Tracking:
                    targetZoomSize = trackingReadyZoomSize;
                    break;
            }
        }
    }

    private Transform target;

    public float smoothTime = 0.2f;

    private Vector3 lastMovingVelocity;
    private Vector3 targetPosition;

    private Camera cam;
    private float targetZoomSize = 5f;

    private const float roundReadyZoomSize = 14.5f;
    private const float readyReadyZoomSize = 5f;
    private const float trackingReadyZoomSize = 10f;

    private float lastZoomSpeed;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>(); //자식 컴포넌트까지 찾음
        state = State.Idle;
    }

    private void Move()
    {
        targetPosition = target.transform.position;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref lastMovingVelocity , smoothTime); //시작 위치, 목표 위치, 중간참고위치 , 속도시간 천천히 이동

        transform.position = smoothPosition;
    }

    private void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize, ref lastZoomSpeed, smoothTime);
        cam.orthographicSize = smoothZoomSize;
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Move();
            Zoom();
        }
    }

    public void Reset()
    {
        state = State.Idle;
    }

    public void SetTarget(Transform newTarget, State newState)
    {
        target = newTarget;
        state = newState;
    }

}
