# 유니티 기초
    1.
        - assest 모든 파일이 들어간폴더 root
        - 기즈모
        - pivot 실제오브젝트에 방향도구 표시
        - center 오브젝트 센터에 표시
    2.
        - global 전체의 좌표
        - local 오브젝트의 좌표
    3.
        - 클래스상속방식 vs 컴포넌트방식
        - 컴포넌트 구조
        - MonoBehaviour  : Super Component
            - 유니티의 통제를 받는다
            - 유니티의 이벤트 메세지 감지
    4.
        - 브로드 캐스팅 : 메세지를 무차별적으로 많이 보내는 것
        - 유니티 이벤트 메서드 : 이름만 맞추면 해당타이밍에 자동구현
        - 메세지/브래드 캐스팅 시스템 :
        - 복잡한 참조관계를 끊고 라이프 싸이클을 스스로 관리할수있게함

# 유니티 프로그래밍

## 유니티 프로그래밍 1
    - var : 할당값을 기준으로 타입을 결정

## 유니티 프로그래밍 2
    1.
        - Rigidbody : 물리적인 컴포넌트
        - .AddForce(x,y,z)
        - Debug.log()
        - Input.GetKey(KeyCode.D)
        - playerRigidbody = GetComponent<Rigidbody>() :컴포넌트를 <>안의 값과 같은 컴포넌트 찾는다
    2.
       - Update() : fps마다 실행

    3. 유저입력 방법 3가지
        - if(Input.GetKey(KeyCode.S)){ playerRigidbody.AddForce(0,0,-speed);}
        ***
        - float inputX = Input.GetAxis("Horizontal");
            - Axis 유니티가 가진 키보드 매핑 오브젝트
            - Horizontal -> 키보드 수평방향에 대응되는 키가 대응
        - playerRigidbody.AddForce(inputX*speed, 0 , inputZ*speed);
        ***
        - Vector3 Velocity = new Vector3(inputX,0,inputZ);
        - Velocity *= speed;
        - playerRigidbody.velocity = Velocity;

    >//발사 기능 - fire - 마우스 왼쪽버튼
    >//if(입력("fire"))
    >// // 총알을 발사