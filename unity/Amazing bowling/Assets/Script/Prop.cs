using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int score = 5;
    public ParticleSystem explosionParticle;
    public float hp = 10f;

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {

            ParticleSystem instance = Instantiate(explosionParticle,transform.position,transform.rotation); // 새로 찍어 생성

            AudioSource explosionAudio = instance.GetComponent<AudioSource>(); //새로찍은 인스턴스의 오디오소스를 가져옴
            explosionAudio.Play();


            Destroy(instance.gameObject, instance.duration);
            gameObject.SetActive(false);
        }
    }
}
