using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���ӿ�����Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingOdject : MonoBehaviour
{
    public float speed = 10f;//�̵��ӵ�
    void Update()
    {
        //�ʴ� speed�Ǽӵ��� �����̵�
       transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
