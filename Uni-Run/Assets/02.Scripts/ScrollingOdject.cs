using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//게임오브젝트를 계속 왼쪽으로 움직이는 스크립트
public class ScrollingOdject : MonoBehaviour
{
    public float speed = 10f;//이동속도
    void Update()
    {
        //초당 speed의속도로 평행이동
       transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
