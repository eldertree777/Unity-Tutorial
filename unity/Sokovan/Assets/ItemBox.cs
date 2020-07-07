using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    private Renderer myRenderer;
    public Color touchColor;
    private Color originalColor;
    // Start is called before the first frame update
    public bool isOveraped = false;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //트리거인 콜리더와 충돌시 자동으로 실행  
    //Enter 출돌을 한 그순간  
    void OnTriggerEnter(Collider other){
        if(other.tag == "EndPoint"){
            isOveraped =true;
            myRenderer.material.color = touchColor;
        }
    }

    //떨어질때
    void OnTriggerExit(Collider other){
        isOveraped =false;
        myRenderer.material.color = originalColor;
    }


    //머무는동안
    void OnTriggerStay(Collider other){
        if(other.tag == "EndPoint"){
            isOveraped = true;
            myRenderer.material.color = touchColor;
        }
    }
    // 일반 콜라이더와 출동시 발생
    // void OnCollisionEnter(Collision other){
    // }
}
