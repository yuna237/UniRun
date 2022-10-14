using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
//������ �� �ϳ��� ���� �Ŵ����� ���� �Ҽ� ����
public class GameManager : MonoBehaviour
{
    public static GameManager instance;//�̱����� �Ҵ��� ���� ����

    public bool isGameover = false; //���ӿ��� ����
    public Text scoreText;//������ ����� UI�ؽ�Ʈ
    public GameObject gameoverUI; //���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ

    private int score = 0;// ���� ����

    void Awake()
    {
        //�̱��� ���� instance�� ��� �ִ°�?
        if (instance == null)
        {
            //instance�� ��� �ִٸ�(null)�װ��� �ڱ� �ڽ��� �Ҵ�

            instance = this;
        }
        else
        {
            //instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ� �Ǿ� �ִ� ���
            //���� �� �� �̻��� GameManager ������Ʈ�� �����Ѵٴ� �ǹ�
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�

            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            //���ӿ��� ���¿��� ������ ����� �Ҽ� �ְ� �ϴ� ó��
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
          
    }
    //������ ���� ��Ű�� �޽���
    public void AddScore(int newScore)
    {
        //���ӿ����� �ƴ϶��
        if(!isGameover)
        {
            //���� ����
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    //�÷��̾� ĳ���� ����� ���ӿ����� �����ϴ� �޼���
    public void OnplayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void Pause(int num)
    {
        Time.timeScale = num;
    }
}
