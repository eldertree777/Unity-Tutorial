using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask whatIsProb; // LayerMask 원하지 않은 친구 필터링
    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;
    public float maxDamage = 100f;
    public float explosionForce = 1000f;
    public float lifeTime = 10f;
    public float explosionRadius = 20f;
   
    private void OnDestroy()
    {
        GameManager.instance.OnBallDestory();
    }

    void Start()
    {
        Destroy(gameObject,lifeTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProb);
        // 정해진위치의 반지름만큼 겹치는 물체의 레이어마스크필터링하여 배열로 반환

        for(int i=0; i< colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();
            targetRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            // 폭팔물의 위치,힘,반경을 입력받아 게산되어 스스로 튕기게하는 함수

            Prop targetProp = colliders[i].GetComponent<Prop>();
            float damage = CalculateDamage(colliders[i].transform.position);
            targetProp.TakeDamage(damage);
        }

        explosionParticle.transform.parent = null; //부모 없앰
        explosionParticle.Play();
        explosionAudio.Play();

        //GameManager.instance.OnBallDestory();//싱글톤

        Destroy(explosionParticle.gameObject, explosionParticle.duration); //러닝타임
        Destroy(gameObject);
    }

    // 거리계산
    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float distance = explosionToTarget.magnitude; // 길이 반환

        float edgeToCenterDistance = explosionRadius - distance;

        float percentage = edgeToCenterDistance / explosionRadius;

        float damage = percentage * maxDamage;

        damage = Mathf.Max(0, damage); // 0~damage만 반환

        return damage;
    }
}
