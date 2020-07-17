using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour
{
    public Rigidbody ball;
    public Transform firePos;
    public Slider powerSlider;
    public AudioSource shootingAudio;
    public AudioClip fireClip;
    public AudioClip chargingClip;
    public float minForce = 15f;
    public float maxForce = 30f;
    public float chargingTime = 0.75f;

    private float currentForce;
    private float chargeSpeed;
    private bool fired;

    public ShooterRotator shooterRotator;
    private void OnEnable() //오브젝트가 활성될때 발동
    {
        currentForce = minForce;
        powerSlider.value = minForce;
        fired = false;
        shooterRotator.enabled = false;
    }

    private void Start()
    {
        chargeSpeed = (maxForce - minForce) / chargingTime; 
    }

    private void Update()
    {

        if(fired == true)
        {
            return;
        }

        powerSlider.value = minForce;

        if(currentForce >= maxForce && !fired)
        {
            currentForce = maxForce;
            Fire();
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            currentForce = minForce;

            shootingAudio.clip = chargingClip;
            shootingAudio.Play();
        }
        else if(Input.GetButton("Fire1") && !fired)
        {
            currentForce = currentForce + chargeSpeed * Time.deltaTime;
            powerSlider.value = currentForce;
        }
        else if(Input.GetButtonUp("Fire1") && !fired)
        {
            Fire();
            shooterRotator.enabled = true;
        }
    }

    private void Fire()
    {
        fired = true;

        Rigidbody ballInstance = Instantiate(ball,firePos.position,firePos.rotation); //생성
        ballInstance.velocity = currentForce * firePos.forward; //앞쪽을 Vector3로 변환

        shootingAudio.clip = fireClip;
        shootingAudio.Play();

        currentForce = minForce;
    }
}
