using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
public class BackgroundLoop : MonoBehaviour
{
    private float width;//����� ���� ����

    private void Awake()
    {
        //���α��̸� �����ϴ� ó��
        //BoxCollider2D ������Ʈ�� �ʵ��� x ���� ���� ���̷� ���
        BoxCollider2D backgrounCollider = GetComponent<BoxCollider2D>();
        width = backgrounCollider.size.x;

            
    }

    private void Update()
    {
        //���� ��ġ�� �������� ���������� Width �̻� �̵� ���� �� ��ġ�� ���ġ
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    //��ġ�� ���ġ�ϴ� �޼���
    private void Reposition()
    {
        //���� ��ġ���� ���������� ���� ���� *2��ŭ �̵�
        Vector2 offse = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offse;
    }
}
