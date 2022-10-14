using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//게임오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
//씬에는 단 하나의 게임 매니저만 존재 할수 있음
public class GameManager : MonoBehaviour
{
    public static GameManager instance;//싱글턴을 할당할 전역 변수

    public bool isGameover = false; //게임오버 상태
    public Text scoreText;//점수를 출력할 UI텍스트
    public GameObject gameoverUI; //게임오버 시 활성화할 UI 게임 오브젝트

    private int score = 0;// 게임 점수

    void Awake()
    {
        //싱글턴 변수 instance가 비어 있는가?
        if (instance == null)
        {
            //instance가 비어 있다면(null)그곳에 자기 자신을 할당

            instance = this;
        }
        else
        {
            //instance에 이미 다른 GameManager 오브젝트가 할당 되어 있는 경우
            //씬에 두 개 이상의 GameManager 오브젝트가 존재한다는 의미
            //싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴

            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            //게임오버 상태에서 게임을 재시작 할수 있게 하는 처리
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
          
    }
    //점수를 증가 시키는 메스드
    public void AddScore(int newScore)
    {
        //게임오버가 아니라면
        if(!isGameover)
        {
            //점수 증가
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    //플레이어 캐릭터 사망시 게임오버를 실행하는 메서드
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
