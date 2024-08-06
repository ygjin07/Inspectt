using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCType
{one, two, three, four, five, six};

public class NPCLine
{
    NPCType[] npcs = new NPCType[4];

    public NPCLine() 
    {
        npcs[0] = GetRandomNPCType();
        npcs[1] = GetRandomNPCType();
        npcs[2] = GetRandomNPCType();
        npcs[3] = GetRandomNPCType();

        Debug.Log(npcs[0] + ", " + npcs[1] + ", " + npcs[2] + ", " + npcs[3]);
    }

    public NPCType[] GetNPCs()
    {
        return npcs;
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

    int last_npc_idx = 0;

    Color[] npc_color = { Color.red, Color.blue, Color.yellow, Color.green, Color.white, Color.black };

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
        npc_set.Add(new NPCLine());

        for(int i = 0; i<NPCObjs.Length; i++)
        {
            NPCType[] type = npc_set[i / 4].GetNPCs();
            NPCObjs[i].GetComponent<SpriteRenderer>().color = npc_color[(int)type[i % 4]];
        }
    }

    public void AddLine()
    {
        npc_set.Add(new NPCLine());

        NPCType[] type = npc_set[npc_set.Count - 1].GetNPCs();

        for(int i = 0;i < 4;i++)
        {
            NPCObjs[last_npc_idx + i].GetComponent<SpriteRenderer>().color = npc_color[(int)type[i % 4]];
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
            StartCoroutine(npc.Move());
        }
    }
}
