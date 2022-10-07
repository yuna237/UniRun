using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathCip; // ��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; // ���� ��

    private int jumpCount = 0; // ���� ���� ȸ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; // ��� ����

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ

    // Start is called before the first frame update
    private void Start()
    {
        //�ʱ�ȭ
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    { //����� �Է��� �����ϰ� �����ϴ� ó��

        if (isDead)
        {
            //���ó���� ���̻� �������� �ʰ� ����
            return;
        }
        //���콺 ���� ��ư�� �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            //���� ������ �ӵ��� ���������� ���� (0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            //������ �ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            //����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // ���콺 ���� ��ư���� ���� ���� ���� &&�ӵ��� y ���� ������(���� ��� ��)
            //���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;

        }

        //�ִϸ������� Grounded �Ƕ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);

    }

    private void Die()
    {
        //���ó��
        //�ִϸ������� Die Ʈ���� �Ƕ���͸� ��
        animator.SetTrigger("Die");
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathCip;
        //���ȿ���� ���
        playerAudio.Play();
       
        //�ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        //��� ���¸� true�� ����
        isDead = true;

        //���� �Ŵ����� ���ӿ��� ó��
        GameManager.instance.OnplayerDead();

    }

    private void OnTriggerEnter2D(Collider2D orher)
    {
        //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
        if (orher.tag == "Dead"&& !isDead)
        {
            //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die()����
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ٴ��� ������� �����ϴ� ó��
        
        //� �ݶ��̴��� �������,�浹 ǥ���� ������ ���� ������

        if (collision.contacts[0].normal.y > 0.7f)
        {
            //isGrounded�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
        //� �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded = false;
    }
}
