using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    NPCController npc_controller;

    List<int> input_set = new List<int>();
    int score = 0;
    [SerializeField]
    int life = 4;
    [SerializeField]
    float limit_time = 3.5f;
    float time;

    //아ㅠ에서부터 순서대로 S, F, J, L, Space, Space
    NPCType[] key_set = (NPCType[])System.Enum.GetValues(typeof(NPCType));

    // Start is called before the first frame update
    void Start()
    {
        time = limit_time;
        ShuffleArray(key_set);
        Debug.Log("key_set : " + string.Join(", ", key_set));
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0) 
        {
            
        }

        if(Input.GetKeyDown(KeyCode.S)) 
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

            input_set.Clear();
        }
    }

    void NextLine()
    {
        time = limit_time;
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
        if(life < 0)
        {
            Debug.Log("GAMEOVER");
        }
    }

    void InputSuccess()
    {
        score++;
        limit_time -= 0.1f;
    }
}
