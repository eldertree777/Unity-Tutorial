using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{   
    //public Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
       // myTransform.Rotate(60,60,60);
    //    transform.Rotate(60,60,60);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(60 * Time.deltaTime,60 * Time.deltaTime,60 * Time.deltaTime);

         //Time.deltaTime 은  1/화면깜빡이는 시간
         //ex) 60fps = 1/60
    }

    //콘솔 PC 프레임 락
    //사양별 성능차 발생
}
