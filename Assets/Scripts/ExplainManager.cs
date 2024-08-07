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
        talkDataList.Add(new TalkData("�ܰ��� �˹��ҿ� �� ���� ȯ���ϳ�"));
        talkDataList.Add(new TalkData("�ڳװ� �ܰ��� �˹��ҿ� �� ����\n�ܰ��ε��� �˹��Ͽ� �з��ϴ� ���̳�"));
        talkDataList.Add(new TalkData("���� �����ϱ� ���� Ư�� �˹� ��� ���� �˷��شٳ�", 
            new TalkEventDefault[] { new TalkEventMoveChat(700, 400, 0, -330, ExplainPanel), new TalkEventSetActiveObject(InitPanel, true) }));
        talkDataList.Add(new TalkData("�̵��� ���� ���� Ű���� ���� �з��ϸ� �ǰ� ������ �������� <color=yellow>Space</color>Ű�� ���� �����Ű�� �ǳ�"));
        talkDataList.Add(new TalkData("���� �����ϰ����� �ؿ��� Ư�� �˹� ����� �˷��ִ� ��������",
            new TalkEventDefault[] { new TalkEventMoveChat(800, 200, 0, -200, ExplainPanel), new TalkEventSetActiveObject(InitPanel, false) }));
        talkDataList.Add(new TalkData("�˹��� �� ���� 4���� ���ʺ��� ������� �˹��ϸ�ǳ�",
            new TalkEventDefault[] { new TalkEventMoveChat(700, 300, 0, 180, ExplainPanel) }));
        talkDataList.Add(new TalkData("�� ��쿡�� <color=yellow>Space S Space J</color> �� ���� ó���ϸ� ����"));
        talkDataList.Add(new TalkData("�������ٰ� 3��° ��ó�� ������ ���\n���� ���� �ִµ� ���� ó�����ָ� ������ �شٳ�",
            new TalkEventDefault[] { new TalkEventSetActiveObject(coin, true) }));
        talkDataList.Add(new TalkData("�� <color=yellow>Space Space S J</color> �� ���� ó���ϸ� ������ ��Ե���"));
        talkDataList.Add(new TalkData("���� ���������� ���ʺ��� ó���ص� �ǳ�.\n������ ������ ��������"));
        talkDataList.Add(new TalkData("���� �˹��� �ż���Ȯ�ؾ� �ϴ� ��.\n���� �ִ� �ð����� �� ���� ó���ϵ��� �ϰ�",
            new TalkEventDefault[] { new TalkEventMoveChat(800, 200, 0, 300, ExplainPanel) }));
        talkDataList.Add(new TalkData("���� �Ҽ��� ���õǴ� ���̴� �˹��� �� �� �����Ҷ����� ���ѽð��� 0.1�ʾ� ���̰ڳ�"));
        talkDataList.Add(new TalkData("���� �˹��� ��Ȯ�ϰ� ���� ���ϰų�\n�ð����� �˹����� ���Ѵٸ� ���� �ִ� ��ȸ�� �ϳ��� ��� �ϰڳ�",
            new TalkEventDefault[] { new TalkEventMoveChat(620, 400, -280, 160, ExplainPanel) }));
        talkDataList.Add(new TalkData("��� ��ȸ�� ������ٸ� �ڳ״� �ذ��ϼ�"));
        talkDataList.Add(new TalkData("�׷� �̻����� ������ ������������.\n���� �����ϰ�",
            new TalkEventDefault[] { new TalkEventMoveChat(640, 400, 0, 105, ExplainPanel) }));
    }
}
