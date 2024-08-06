using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    NPCController npc_controller;
    [SerializeField]
    GameOverUI gameOverUI;

    List<int> input_set = new List<int>();
    public int score = 0;
    [SerializeField]
    public int life = 5;
    [SerializeField]
    public float limit_time = 8f;
    public float time;

    bool isgameover = false;

    //아ㅠ에서부터 순서대로 S, F, J, L, Space, Space
    NPCType[] key_set = (NPCType[])System.Enum.GetValues(typeof(NPCType));

    [SerializeField]
    List<GameObject> keyObjs;

    Color[] npc_color = { Color.red, Color.blue, Color.yellow, Color.green, Color.white, Color.black };

    // Start is called before the first frame update
    void Start()
    {
        time = limit_time;
        ShuffleArray(key_set);
        Debug.Log("key_set : " + string.Join(", ", key_set));
        for (int i = 0; i < keyObjs.Count; i++)
        {
            keyObjs[i].GetComponent<SpriteRenderer>().color = npc_color[(int)key_set[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isgameover)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
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

    void KeyInput(int input)
    {
        input_set.Add(input);

        if(input_set.Count >= 4)
        {
            if(CompareLine())
            {
                InputSuccess();
            }
            else
            {
                InputFail();
            }

            Debug.Log("Score : " + score + ", Life : " + life);

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

        for (int i = 0; i< 4; i++)
        {
            if (input_set[i] == 4)
            {
                //Space 키 비교
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
        for (int i = array.Length - 1; i > 0; i--)
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
        limit_time -= 0.1f;
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
    }
}
