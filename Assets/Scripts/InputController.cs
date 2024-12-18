using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField]
    NPCController npc_controller;
    [SerializeField]
    UIManager uIManager;
    [SerializeField]
    GameOverUI gameOverUI;
    [SerializeField]
    GameObject InitPanel;

    Image[] init_checks;

    [SerializeField]
    SoundManager soundManager;

    [SerializeField]
    GameObject checkpointGameObjects;

    Checkpoint[] checkpoints;

    List<int> input_set = new List<int>();
    public int score = 0;
    [SerializeField]
    public int life = 5;
    [SerializeField]
    public float limit_time = 8f;
    public float time;

    PlayerRecorder player_data = new PlayerRecorder();
    public int coin = 0;

    bool isgameover = true;

    //�Ƥп������� ������� S, F, J, L, Space, Space
    NPCType[] key_set = (NPCType[])System.Enum.GetValues(typeof(NPCType));

    [SerializeField]
    List<Image> keyObjs;

    Color[] npc_color = { Color.red, Color.blue, Color.yellow, Color.green, Color.white, Color.black };

    // Start is called before the first frame update
    void Start()
    {
        soundManager.PlayBGM(0,true);

        coin = player_data.LoadPlayerData().coin;
        life = player_data.LoadPlayerData().life;
        uIManager.InitLife();

        time = limit_time;
        init_checks = InitPanel.GetComponentsInChildren<Image>();
        checkpoints = checkpointGameObjects.GetComponentsInChildren<Checkpoint>();

        ShuffleArray(key_set);
        for (int i = 0; i < keyObjs.Count; i++)
        {
            keyObjs[i].sprite = npc_controller.NPCImages[(int)key_set[i]];
            init_checks[i + 1].GetComponent<Image>().sprite = npc_controller.NPCImages[(int)key_set[i]];
        }
        StartCoroutine(InitPanelCorutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isgameover)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                soundManager.PlayEffect(4);

                InputFail();
                NextLine();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                KeyInput(0);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                KeyInput(1);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                KeyInput(2);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                KeyInput(3);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyInput(4);
            }
        }
    }

    IEnumerator InitPanelCorutine()
    {
        Debug.Log("이닛패널코루틴 시작");
        // yield return new WaitForSeconds(2f);
        yield return new WaitForSecondsRealtime(2f);
        InitPanel.SetActive(false);
        isgameover = false;
        Debug.Log("이닛패널코루틴 끝");
    }

    void KeyInput(int input)
    {
        input_set.Add(input);

        soundManager.PlayEffect(input_set.Count-1);
        checkpoints[input_set.Count - 1].GetInput();

        if(input_set.Count >= 4)
        {
            if(CompareLine())
            {
                soundManager.PlayEffect(5);
                InputSuccess();
            }
            else
            {
                soundManager.PlayEffect(6);
                InputFail();
            }

            NextLine();
        }
    }

    void NextLine()
    {
        time = limit_time;
        input_set.Clear();
        npc_controller.NPCsMove();
        npc_controller.RemoveLine();
        npc_controller.AddLine();
    }

    bool CompareLine()
    {
        List<NPCLine> npc_set = npc_controller.GetNpcSet();
        NPCType[] first_line = npc_set[0].GetNPCs();

        if (npc_set[0].is_coinline)
        {
            NPCType[] first_coin_line = npc_set[0].GetCoinNPCs();
            bool getcoin = true;

            for (int i = 0; i < 4; i++)
            {
                if (input_set[i] == 4)
                {
                    //Space Ű ��
                    if (first_coin_line[i] != key_set[4] && first_coin_line[i] != key_set[5])
                    {
                        getcoin = false;
                        break;
                    }
                }
                else
                {
                    if (first_coin_line[i] != key_set[input_set[i]])
                    {
                        getcoin = false;
                        break;
                    }
                }
            }

            if (getcoin)
            {
                coin++;
                PlayerData data = player_data.LoadPlayerData();
                data.coin = coin;
                player_data.SavePlayerData(data);
                return true;
            } 
        }

        for (int i = 0; i< 4; i++)
        {
            if (input_set[i] == 4)
            {
                //Space Ű ��
                if (first_line[i] != key_set[4] && first_line[i] != key_set[5])
                {
                    return false;
                }
            }
            else
            {
                if(first_line[i] != key_set[input_set[i]])
                {
                    return false;
                }
            }
        }

        return true;
    }

    void ShuffleArray<T>(T[] array)
    {
        PlayerData data = player_data.LoadPlayerData();

        for (int i = array.Length - (data.decreasingCharactorType ? 2 : 1); i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    void InputFail()
    {
        life--;
        uIManager.UnActiveHeart(life);
        if(life <= 0)
        {
            GameOver();
        }
    }

    void InputSuccess()
    {
        score++;
        limit_time -= 0.1f;
    }

    void GameOver()
    {
        isgameover = true;
        gameOverUI.ActiveGameOverPanel();
        gameOverUI.SetFinalScore(score);
        PlayerData pdata = player_data.LoadPlayerData();
        pdata.decreasingCharactorType = false;
        player_data.SavePlayerData(pdata);
    }
}
