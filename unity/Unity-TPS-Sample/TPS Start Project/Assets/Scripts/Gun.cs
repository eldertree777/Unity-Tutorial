using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }
    public State state { get; private set; }
    
    private PlayerShooter gunHolder;
    private LineRenderer bulletLineRenderer;
    
    private AudioSource gunAudioPlayer;
    public AudioClip shotClip;
    public AudioClip reloadClip;
    
    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectEffect;
    
    //위치
    public Transform fireTransform;
    public Transform leftHandMount;

    public float damage = 25;
    public float fireDistance = 100f;

    public int ammoRemain = 100;
    public int magAmmo;
    public int magCapacity = 30;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
    
    [Range(0f, 10f)] public float maxSpread = 3f; // 탄퍼짐
    [Range(1f, 10f)] public float stability = 1f; //반동
    [Range(0.01f, 3f)] public float restoreFromRecoilSpeed = 2f;
    private float currentSpread;
    private float currentSpreadVelocity;

    private float lastFireTime; // 가장최근 사격이 이루어진 시점

    private LayerMask excludeTarget;

    private void Awake()
    {
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    public void Setup(PlayerShooter gunHolder)
    {
        this.gunHolder = gunHolder;
        excludeTarget = gunHolder.excludeTarget;
    }

    private void OnEnable()
    {
        magAmmo = magCapacity;
        currentSpread = 0f;
        lastFireTime = 0f;
        state = State.Ready;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public bool Fire(Vector3 aimTarget)
    {
        //현재시간 >= 발사지연지간 + 발사시간
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            var fireDirection = aimTarget - fireTransform.position;
            lastFireTime = Time.time;
            Shot(fireTransform.position, fireDirection);
        }
        return false;
    }
    
    private void Shot(Vector3 startPoint, Vector3 direction)
    {
        
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        shellEjectEffect.Play();
        //효과 재생
        gunAudioPlayer.PlayOneShot(shotClip);
        //소리 재생
        bulletLineRenderer.enabled = true;
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        yield return new WaitForSeconds(0.03f) ;
        // 괘적 그리고 일정시간 스탑
        bulletLineRenderer.enabled = false;
    }
    
    public bool Reload()
    {
        return false;
    }

    private IEnumerator ReloadRoutine()
    {
        yield return null;
    }

    private void Update()
    {

    }
}