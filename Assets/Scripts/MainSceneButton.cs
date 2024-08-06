using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
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

    void Start()
    {
        scorePanel.SetActive(false);
        names = nameGroup.GetComponentsInChildren<TextMeshProUGUI>();
        scores = scoreGroup.GetComponentsInChildren<TextMeshProUGUI>();
        ranks = rankGroup.GetComponentsInChildren<TextMeshProUGUI>();

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
        //SceneManager.LoadScene("");
    }

    //스코어보드 버튼
    public void OnClickScoreBoard()
    {
        Debug.Log("스코어보드");
        SetScoreBoard();
        scorePanel.SetActive(true);
    }

    //스코어보드 종료 버튼
        public void OnClickCloseScoreBoard()
    {
        Debug.Log("스코어보드 종료");
        scorePanel.SetActive(false);
    }

    //게임 종료 버튼
    public void OnClickExit()
    {
        Debug.Log("종료");
        // UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }

    void SetScoreBoard()
    {
        dataList = scoreBoard.LoadScore();

        // for(int i =0; i<dataList.datas.Count; i++)
        // {
        //     Debug.Log(dataList.datas[i].name);
        // }
        // Debug.Log(names.Length);
        // Debug.Log(scores.Length);

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
