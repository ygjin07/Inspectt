using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    //배경음악, 버튼 소리
    [SerializeField]
    SoundManager soundManager;

    [SerializeField]
    GameObject scorePanel;

    //스코어보드 Text들
    [SerializeField]
    GameObject nameGroup;
    TextMeshProUGUI[] names;

    [SerializeField]
    GameObject scoreGroup;
    TextMeshProUGUI[] scores;

    [SerializeField]
    GameObject rankGroup;
    TextMeshProUGUI[] ranks;

    [SerializeField]
    TextMeshProUGUI noRank;

    ScoreBoard scoreBoard = new ScoreBoard();
    DataList dataList = new DataList();

    //옵션 패널
    [SerializeField]
    GameObject optionPanel;


    void Start()
    {
        scorePanel.SetActive(false);
        optionPanel.SetActive(false);

        names = nameGroup.GetComponentsInChildren<TextMeshProUGUI>();
        scores = scoreGroup.GetComponentsInChildren<TextMeshProUGUI>();
        ranks = rankGroup.GetComponentsInChildren<TextMeshProUGUI>();

        //메인씬 배경음악 반복재생
        soundManager.PlayBGM(0,true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            scorePanel.SetActive(false);
        }
    }

    //시작버튼
    public void OnClickStart()
    {
        Debug.Log("시작");

        soundManager.PlayEffect(0);
        SceneManager.LoadScene("UITest");
    }

    //스코어보드 버튼
    public void OnClickScoreBoard()
    {
        Debug.Log("스코어보드");

        SetScoreBoard(); //스코어보드 만들기
        soundManager.PlayEffect(1); //소리
        scorePanel.SetActive(true); //활성화
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");

        soundManager.PlayEffect(1); //소리
        optionPanel.SetActive(true); //활성화
    }

    //닫기 버튼
        public void OnClickClose()
    {
        Debug.Log("패널 닫");

        soundManager.PlayEffect(0); //소리
        scorePanel.SetActive(false); //스코어 패널 비활성화
        optionPanel.SetActive(false); //옵션 패널 비활성화
    }



    //게임 종료 버튼
    public void OnClickExit()
    {
        Debug.Log("종료");

        soundManager.PlayEffect(0);//소리
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void SetScoreBoard()
    {
        dataList = scoreBoard.LoadScore();

        //저장된 기록이 10개가 넘으면 for문을 10번까지, 그렇지 않으면 기록 수만큼 for문 반복
        int maxIndex;

        if(dataList.datas.Count<10)
        {
            noRank.enabled=false;
            maxIndex = dataList.datas.Count;
            for(int i =9; i> dataList.datas.Count-1; i--)
            {
                names[i].enabled = false;
                scores[i].enabled = false;
                ranks[i].enabled = false;

                if(dataList.datas.Count<1)
                {
                    noRank.enabled=true;
                }
            }
        }
        else
        {
            noRank.enabled=false;
            maxIndex = 10;
        }


        for(int i=0; i<maxIndex; i++)
        {   
            names[i].text = dataList.datas[i].name;
            scores[i].text = dataList.datas[i].score.ToString();
        }

    }
}
