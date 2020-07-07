using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager;
    public float speed = 10f;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    // 게임이 실행시 한번 실행
    //Debug.log()
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // 하나의 프레임마다 실행
    // movie 24fps mobile 30fps pc 60fps
    // console 30fps
    void Update()
    {
        if(gameManager.isGameOver == true){
            return;
        }

        // 유저 입력
        // if(Input.GetKey(KeyCode.W)){
        //     playerRigidbody.AddForce(0,0,speed);           
        // }
        // if(Input.GetKey(KeyCode.A)){
        //     playerRigidbody.AddForce(-speed,0,0);
        // }
        // if(Input.GetKey(KeyCode.S)){
        //     playerRigidbody.AddForce(0,0,-speed);
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     playerRigidbody.AddForce(speed,0,0);
        // }


        //  vs


        //-1 ~ +1
        // A <-         -> D
        // -1      0      +1
        // 조이스틱 대응
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");


        // playerRigidbody.AddForce(inputX*speed, 0 , inputZ*speed);

        //  Axis 유니티가 가진 키보드 매핑 오브젝트
        //  Horizontal -> 키보드 수평방향에 대응되는 키가 대응

        //  vs


        float fallSpeed =playerRigidbody.velocity.y;

        Vector3 Velocity = new Vector3(inputX,0,inputZ);
        Velocity *= speed;
        Velocity.y = fallSpeed;
        playerRigidbody.velocity = Velocity;
        
        //발사 기능 - fire - 마우스 왼쪽버튼
        //if(입력("fire"))
        // // 총알을 발사
    }
}
