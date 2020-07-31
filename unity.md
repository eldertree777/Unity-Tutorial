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
    
## 볼링
    1.
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
    2.
        - 프로퍼티 get , set
        - cam = GetComponentInChildren<Camera>(); //자식 컴포넌트까지 찾음
        - Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref lastMovingVelocity , smoothTime); //시작 위치, 목표 위치, 중간참고위치 , 속도시간 천천히 이동
        - *SmoothDamp : 시작 목표 까지 천천히 이동
        - void FixedUpdate() : 프레임드랍 방지 Update()
    
    3.
        - PlayerPrefs.SetInt("BestScore", score) 파일에 키값을통해 데이터 저장
        - UnityEvent onReset; 선언 -> onReset.Invoke(); 발동!

    4. 
        -Audio Mixer
    
    5. 
        - OnDestroy(){} : 자신오브젝트가 파괴될때 발동 

# 유니티프로그래밍 고급

## 유니티 프로그래밍 중급2
    1.  레이캐스트
        -Camera.ViewportToWorldPoint(new Vector3()) :
        카메라에서 Vector3 까지를 Vector3로 반환
        - Physics.Raycast(rayOrigin, rayDir,out Raycasthit, distance , LayerMask) :
        위치에서 방향으로 거리만큼 해당 레이어 오브젝트와 만나면 true반환 발생된 오브젝트를 out Raycasthit로 정보를 보냄
        - Debug.DrawRay(rayOrigin, rayDir * 100f, Color.green)
        위치에서 방향만큼 색을 표시해줌
        -Raycasthit : Raycast로 발생하는 다른 오브젝트 정보 저장하는 리스트
        - hit.collider.gameObject.name  충돌오브젝트 이름
        - hit.nomal hit.distance
        - Ray ray = new Ray(rayOrigin, rayDir);
        - moveTarget.GetComponent<Renderer>().material.color = Color.white;
    
    2. 상속
        - public class Subclass : SuperClass{}
        - 접근 지정자 public private protected: 자식만허용
    
    3. 다형성

    4. 오버라이드 
        - virtual void Rotate()
        - override void Rotate() {base.Rotate();}

    5. 인터페이스
        - FindObjectOfType<Player>(); 씬상에서 플레이어를 찾아서 
        - interface IItem
        - IItem item = other,GetComponent<IItem>();

    6. 추상클래스
        - abstract

    7. 프로퍼티
        - int point{
            get{
                return m_point;
            }
            set{
                if(value <0) { m_point=0;}
            }
        }
## 유니티 프로그래밍 고급
    1. 유니티 이벤트
        - SceneManager.LoadScene(0) 씬 재실행
        - Invoke("함수이름", 지연시간); 
        - using UnmityEngine.Events;
        - UnityEvent onPlayerDead;
        - inPlayerDead.Invoke();
    2. 델리게이트
        - delegate float Calculate(float a, float b);
        - Calculate onCalculate;
        - event Calculate onCalculate;
        - onCalculate = Sum; 등록
        - onCalculate += Subtract;
        - onCalculate = Sum(); 실행
        - onCalculate(); 실행
    3. 
        - 커플링 : 두 오프젝트가 얼마나 연결된정도
        - publisher : 이벤트를 작동하는 친구
        - subscriber : 이벤트 받기 대기중인 친구
    
    4. 액션 + 람다
        - delegate -> Action: 반환값이없는 입력없는 델리게이트타입
        - 람다 : onSend += man => Debug.Log(" Assaingate " + man)
        - = (string man) => {};
        - get => health;
        - set => health = value;
    
    5. 제네릭
        - public void function<T>(T var){Debug.Log(T);}

# 애니메이션
    1.  애니메이션 클립
        - Animation 
    2. 애니메이터 컨트롤러 + FSM
        - Controller
        - Animator.SetTrigger("Jump");
        - float vertocalInput = Input.GetAxis("Vertical");
        - anim.SetFloat("Speed", vertocalInput);
        // 파라미터값  애니메이션이름 , 정도 퍼센티지
    3. 애니메이터 파라미터
        - Entry state ,  anystate
    4. 트랜지션
        -Has Exit Time : 애니메이션 변화사이 텀의 여부
        - Transition Duration : 
    5. 블랜드 트리
        -Blend Tree : 애니메이션의 조합
    6. 루트모션+ 아바타
        -Apply Root Motion
    7. 애니메이터 레이어
        - 다양한레이어를 사용하여 애니메이션을 덮을수있다
        - Layer Mask
    8. IK Inverse Kinematic
        - 애니메이션을 플레이할때 관절의 위치를 역계산
        - ex)
        > anim.SetIKPositionWeight(AvatarIKGoal.LeftHand,1.0f);
        > anim.SetIKRotationWeight(AvatarIKGoal.LeftHand,1.0f);

        > anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
        > anim.SetIKRotation(AvatarIKGoal.LeftHand, target.rotation);

        > anim.SetLookAtWeight(1.0f);
        > anim.SetLookAtPosition(target.position);
## UGUI
    1. Canvas
        - 캔버스는 게임화면에 비례합니다
        - UI오브젝트의 프레임
        - Screen Space
    2. anchor pivot position
        - Anchor : UI요소의 원점(0,0) 위치를 정한다
        - Pivot : UI요소 내부의 기준점을 정한다
        - Position : 앵커와 피벗을 기준으로 결정한 좌표
        
    3. UI 비주얼 컴포넌트

    4. 이미지 컴포넌트
        - Sprite
        - Image Type

    5. Raw 이미지
        - Texture

    6. 마스크

    7. 그림자 + 외곽선
        - Shadow Outline 컴포넌트

    --- 비주얼 컴포넌트

    8. 인터렉션 컴포넌트 + selectable
        - 터지 상호 작용
        - selectable 베이스로 구성
        - EventSystem이 관리

    9. 버튼
        - Random.ColorHSV() : 랜덤 컬러

    10. 토글
    11. 토글그룹
    12. 슬라이더
    13. 드롭다운
    14. 스크롤뷰
    15. 입력 필드
    16. 레이아웃 컴포넌트 + 수직 정렬
        - Vertical Layout Group 컴포넌트

    17. 수평정렬   
        - Horizontal Layout Group 컴포넌트

    18. 그리드 정렬 : 바둑판
        - Grid Layout Group 컴포넌트

    19. 레이아웃 앨리먼트
        - Layout Element 컴포넌트

    20. 이벤트시스템 + UI인터렉션 원리
        - 이벤트시스템 원리 : 클릭시 RayCast 빔발사됨
        - Event Trigger
        - Using Unity.EventSystem;
         IPointerEnterHandler -> void OnPointEnter(PointerEventData data)
        
# Unity Document
[Link](https://docs.unity3d.com/Manual/index.html)

# FPS Game
[참조 Github](https://github.com/IJEMIN/Unity-TPS-Sample)

    1. 라이트닝
        - Global Illumination : 직접조명 + 간접조명
        - Realtime Global Illumination
        - Baked Global Illumination

    2. Cinemachine
        - 카메라 연출 구현
        - Brain + Virtual 
        - FreeLook : Virtual 확장한 카메라
        - Cinemachine collider 
    
    3. 
        - Character Controller : Rigidbody가 요구하지않는 컨트롤러
        - Vector2.sqrMagnitude : 백터길이
        - Vector2.normalized : 백터길이 1로 만듬
        -  [Range(0.01f, 1f)] public float airControlPercent; //공중에 떠있는동안 이동조작
        - characterController.isGrounded : 바닥에 닿아있는지 여부 
        - [Range(0f, 10f)] public float maxSpread = 3f; 슬라이더
    
    4.
        - PlayOneSho : Play() 와 다르게 연속해서 클립 재생
        - bulletLineRenderer.SetPosition(0, fireTransform.position);
            bulletLineRenderer.SetPosition(1, hitPosition);