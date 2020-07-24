using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }

        float vertocalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", vertocalInput);
        anim.SetFloat("Horizontal", horizontalInput);
    }

    void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand,1.0f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand,1.0f);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);

        anim.SetLookAtWeight(1.0f);
        anim.SetLookAtPosition(target.position);
    }
}
