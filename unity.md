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

# 유니티 프로그래밍 기초

## 유니티 프로그래밍 1
    - var : 할당값을 기준으로 타입을 결정

## 유니티 프로그래밍 2 + Sokovan
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
        - GetKey 누르는동안,  GetKeyDown 누르는순간

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

    4.
        - Time.deltaTime 은  1/화면깜빡이는 시간
        - transform 변수는 유니티에서 지원
        - tag
    5. 
        - OnTriggerEnter(Collider other) : 트리거 콜리더 충돌시
        - OnCollisionEnter(Collision other) : 일반콜리더와 충돌 발생시
        - OnTriggerExit(Collider other) : 떨어질때
        - OnTriggerStay(Collider other) : 머무르는 동안
    6. 
        -GameManager

    7. UI
        - Canvas : UI Main Object
        - EventSystem : 입력을 받아 UI에 전달
        - winUI.SetActive(true); : 활성화

# 유니티 프로그래밍 중급

## 유니티 프로그래밍 중급 1
    1. 벡터
        - Vector3 or Vector2
        - 방향벡터 x 속도
        - transform.Translate(Vector3 , Space.World ) : 수평이동
        -                                  : 글로벌좌표계로 설정
        - 하위 오브젝트는 상위 오브젝트 좌표계의 기준으로 제어된다.
        - transform.localPosition = new Vector3();
        - transform.rotation = Quaternion.Euler(new Vector3());
        - 쿼터니언(x,y,z,w) 어려움 -> Vector3를 사용하여 사용  *짐벌락
        - Quaternion newRotation = Quaternion.Euler(new Vector3());
        - Quaternion.LookRotation(direction)
        - Quaternion.Lerp(aRotation,bRotation, 0.5f(퍼센티지));
        ***
        - transform.Rotate(new Vector());
        - Quaternion.eulerAngles => Vectoer3 반환 
        - 각도의 합 => Quaternion*Quaternion;

    2. 인스턴스
        - Instantiate(target, spawnPosition, spawnRotation) : target 생성
        - GameObject var = Instantiate(); 
            > var.GetComponent<Rigidbody>().AddForce();
            vs

        - Rigidbody var = Instantiate();
            > var.AddForce();
        - 인스턴스화를 함으로써 게임중 오브젝트를 계속 생성하거나 사용함

    3. 오버로드
        - 함수의 중복

    4. 정적 변수,함수
        - Static ex) 하나의 클래스의 Static int count 변수 
        - void Awake() : void Start()실행 이전 실행하는 함수
    
    5. 리스트
        - Random.Range(start,End) : Start~End중 랜덤값
        - Input.GetmouseButtondown(0) 좌클릭 1은 우클릭
        - List<int> scores = new List<int>();
        - scores.Add(); .RemoveAt(Index) .Remove(value)
    
    6. *싱글톤 : 디자인패턴
        - 자기자신클래스에 자신의 정적인스턴스를 가짐
        - 오브젝트 단 하나만 부여해야함
        - instance = this;
        - instance = FindObjectOfType<value>(); 씬상에 모든오브젝트를 뒤져서 value를 찾음
        - instance = GameObject.AddComponent<ScoreManager>(); 지연생성
        - Destroy()

    7. 코루틴 -> 병렬처리
        - 유니티 고유기능
        - 코드에 지정시간동안 대기시킴
        - IEnumerator ... {
            yield return new WaitForSeconds(0.01f);
            } // 대기시간을 갖는다.
        - StartCoroutine(FadeIn())
        - StartCoroutine("FadeIn") 인위적으로 멈추는게 가능
        -   StopCoroutine("FadeIn")
        - 코루틴은 비동기 방식이다
        - 동시 여러작업 할시에 사용함
    
    8. balling
        - enum :
        >private enum RorateState{ Idle,Vertical,Horizontal,Ready }
        >private RorateState state = RorateState.Idle;
        - Edit - Project Setting - Axes
        - Destroy(gameObject, lifetime) // lifetime후 gameObject파괴
        - explosionParticle.transform.parent = null; //부모 없앰
        - explosionParticle.Play();
        - Destroy(explosionParticle.gameObject, explosionParticle.duration); //duration 지연시간
        - ParticleSystem instance = Instantiate(explosionParticle,transform.position,transform.rotation); // 새로 찍어 생성
        - gameObject.SetActive(false); <-> gameObject.Play() ??
        - Tag or Layer 오브젝트 구별 방법
        - tag : 일대일 layer : 다수
        - LayerMask
        -  Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, whatIsProb);
         // 정해진위치의 반지름만큼 겹치는 물체의 레이어마스크필터링하여 배열로 반환
        
        - Vector3.magnitude : Vector3 -> 길이
        - damage = Mathf.Max(0, damage); // 0~damage만 반환
        - targetRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius); 
            // 폭팔물의 위치,힘,반경을 입력받아 게산되어 스스로 튕기게하는 함수
        -firePos.forward; //앞쪽을 Vector3로 변환
        - Quaternion.identity == Quaternion(new Vector(0,0,0))
        - ballshooter.enabled = true;
        - Random.Range(startVal, endVal)