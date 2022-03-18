using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager gm;
    private GameObject[] obj;

    public int myGold = 0;
    public GameObject TowerPrefab;

    // UI Text Variable
    Text UItext;
    private void Awake()
    {
        if (gm == null)
            gm = this;
    }
    // 게임상태 상수
    public enum GameState
    {
        Ready, // 게임 준비 상태
        Play, // 게임 실행
        GameOver // 게임종료
    }
    // 게임상태 변수
    public GameState gState;

    // Start is called before the first frame update
    void Start()
    {
        // 게임 초기상태 준비 상태 설정

        // 게임 실행상태 설정
        gState = GameState.Play;
        Debug.Log("Starting");
        this.veiling();

        // 게임종료상태 설정

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void veiling()
    {
        obj = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject i in obj)
        {
            i.SetActive(false);
            string message = i.ToString();
        }
    }
    // 골드 획득량 증가 함수
    public void GetGold(GameObject obj) {
        myGold++;
        Debug.Log("Gold : " + myGold.ToString());
        obj.GetComponent<Coin>().Collect();
    }
    // 웨이브 시작함수
    public void WaveStart(GameObject obj) {
        Debug.Log("TEST : ");
        // Data Chaning by wave
        float[] data = new float[3]{1, 2, 5};
        GameObject.Find("Gate").SendMessage("WaveStart", data);
        Destroy(obj);
    }
    // 타워 생성
    public void CreateTower(GameObject obj) {
        if (myGold >= 5) {
            myGold -= 5;
            Instantiate(TowerPrefab, obj.transform.position, obj.transform.rotation);
            Destroy(obj);
        }
        else {
            Debug.Log("Message : not enough Gold");
        }
    }
}
