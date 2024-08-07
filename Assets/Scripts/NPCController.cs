using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCType
{one, two, three, four, five, six};

public class NPCLine
{
    NPCType[] npcs = new NPCType[4];
    NPCType[] coin_npcs = new NPCType[4];

    public bool is_coinline = false;

    public NPCLine() 
    {
        npcs[0] = GetRandomNPCType();
        npcs[1] = GetRandomNPCType();
        npcs[2] = GetRandomNPCType();
        npcs[3] = GetRandomNPCType();
    }

    public NPCType[] GetNPCs()
    {
        return npcs;
    }

    public NPCType[] GetCoinNPCs()
    {
        return coin_npcs;
    }

    public void CoinLine(int coin_idx)
    {
        is_coinline = true;

        coin_npcs[0] = npcs[coin_idx];

        int j = 1;
        for(int i = 0; i < 4 ; i++)
        {
            if(coin_idx == i)
            {
                continue;
            }
            coin_npcs[j++] = npcs[i];
        }
    }

    NPCType GetRandomNPCType()
    {
        NPCType[] type = (NPCType[])System.Enum.GetValues(typeof(NPCType));

        int randomIndex = Random.Range(0, type.Length);

        return type[randomIndex];
    }
}

public class NPCController : MonoBehaviour
{
    List<NPCLine> npc_set = new List<NPCLine>();

    [SerializeField]
    GameObject NPCsGameObject;
    NPCObject[] NPCObjs;

    int last_npc_idx = 20;
    
    public List<Sprite> NPCImages;
    public List<RuntimeAnimatorController> NPCAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        NPCObjs = NPCsGameObject.GetComponentsInChildren<NPCObject>();

        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());

        for(int j = 0; j<NPCObjs.Length / 4 - 1; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                NPCType[] type = npc_set[j].GetNPCs();
                NPCObjs[j * 4 + i].GetComponent<SpriteRenderer>().sprite = NPCImages[(int)type[i]];
                NPCObjs[j * 4 + i].GetComponent<Animator>().runtimeAnimatorController = NPCAnimatorController[(int)type[i]];
            }

            if (Random.Range(0, 2) == 1)
            {
                int Random_coin = Random.Range(0, 4);
                NPCObjs[j * 4 + Random_coin].SetCoin(true);
                npc_set[j].CoinLine(Random_coin);
            }
        }
    }

    public void AddLine()
    {
        npc_set.Add(new NPCLine());

        NPCType[] type = npc_set[npc_set.Count - 1].GetNPCs();


        for(int i = 0;i < 4;i++)
        {
            NPCObjs[last_npc_idx + i].SetCoin(false);
            NPCObjs[last_npc_idx + i].GetComponent<SpriteRenderer>().sprite = NPCImages[(int)type[i % 4]];
            NPCObjs[last_npc_idx + i].GetComponent<Animator>().runtimeAnimatorController = NPCAnimatorController[(int)type[i % 4]];
        }

        if (Random.Range(0, 2) == 1)
        {
            int Random_coin = Random.Range(0, 4);
            NPCObjs[last_npc_idx + Random_coin].SetCoin(true);
            npc_set[npc_set.Count - 1].CoinLine(Random_coin);
        }

        last_npc_idx += 4;
        last_npc_idx %= 24;
    }

    public void RemoveLine() 
    {
        npc_set.RemoveAt(0);
    }

    public List<NPCLine> GetNpcSet()
    {
        return npc_set;
    }

    public void NPCsMove()
    {
        foreach(NPCObject npc in NPCObjs)
        {
            npc.StartMove();
        }
    }
}
