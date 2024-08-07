using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplainManager : MonoBehaviour
{
    List<TalkData> talkDataList = new List<TalkData>();
    [SerializeField]
    RectTransform ExplainPanel;
    [SerializeField]
    TMP_Text explainText;
    [SerializeField]
    GameObject InitPanel;
    [SerializeField]
    GameObject coin;

    int explain_idx = 0;

    private void Awake()
    {
        SetInitExplain();
    }

    // Start is called before the first frame update
    void Start()
    {
        NextExplain();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextExplain();
        }
    }

    void NextExplain()
    {
        if (talkDataList.Count <= explain_idx)
        {
            SceneManager.LoadScene("UItest");
        }
        else
        {
            TalkData current = talkDataList[explain_idx++];
            explainText.text = current.dialogue;
            foreach (TalkEventDefault e in current.events)
            {
                e.DoEvent();
            }
        }
    }

    void SetInitExplain()
    {
        talkDataList.Add(new TalkData("외계인 검문소에 온 것을 환영하네"));
        talkDataList.Add(new TalkData("자네가 외계인 검문소에 할 일은\n외계인들을 검문하여 분류하는 것이네"));
        talkDataList.Add(new TalkData("일을 시작하기 전에 특별 검문 대상에 대해 알려준다네", 
            new TalkEventDefault[] { new TalkEventMoveChat(700, 400, 0, -330, ExplainPanel), new TalkEventSetActiveObject(InitPanel, true) }));
        talkDataList.Add(new TalkData("이들은 위에 적힌 키들을 눌러 분류하면 되고 나머지 종류들은 <color=yellow>Space</color>키를 눌러 통과시키면 되네"));
        talkDataList.Add(new TalkData("일을 시작하고나서도 밑에서 특별 검문 대상을 알려주니 걱정말게",
            new TalkEventDefault[] { new TalkEventMoveChat(800, 200, 0, -200, ExplainPanel), new TalkEventSetActiveObject(InitPanel, false) }));
        talkDataList.Add(new TalkData("검문은 맨 앞줄 4명을 왼쪽부터 순서대로 검문하면되네",
            new TalkEventDefault[] { new TalkEventMoveChat(700, 300, 0, 180, ExplainPanel) }));
        talkDataList.Add(new TalkData("이 경우에는 <color=yellow>Space S Space J</color> 를 눌러 처리하면 되지"));
        talkDataList.Add(new TalkData("가끔가다가 3번째 놈처럼 코인을 들고\n오는 놈이 있는데 먼저 처리해주면 코인을 준다네",
            new TalkEventDefault[] { new TalkEventSetActiveObject(coin, true) }));
        talkDataList.Add(new TalkData("즉 <color=yellow>Space Space S J</color> 를 눌러 처리하면 코인을 얻게되지"));
        talkDataList.Add(new TalkData("물론 정상적으로 왼쪽부터 처리해도 되네.\n코인을 얻지는 못하지만"));
        talkDataList.Add(new TalkData("또한 검문은 신속정확해야 하는 법.\n위에 있는 시간내로 한 줄을 처리하도록 하게",
            new TalkEventDefault[] { new TalkEventMoveChat(800, 200, 0, 300, ExplainPanel) }));
        talkDataList.Add(new TalkData("일은 할수록 숙련되는 법이니 검문을 한 줄 성공할때마다 제한시간을 0.1초씩 줄이겠네"));
        talkDataList.Add(new TalkData("만약 검문을 정확하게 하지 못하거나\n시간내에 검문하지 못한다면 옆에 있는 기회를 하나씩 까도록 하겠네",
            new TalkEventDefault[] { new TalkEventMoveChat(620, 400, -280, 160, ExplainPanel) }));
        talkDataList.Add(new TalkData("모든 기회가 사라진다면 자네는 해고일세"));
        talkDataList.Add(new TalkData("그럼 이상으로 설명을 끝내도록하지.\n일을 시작하게",
            new TalkEventDefault[] { new TalkEventMoveChat(640, 400, 0, 105, ExplainPanel) }));
    }
}
