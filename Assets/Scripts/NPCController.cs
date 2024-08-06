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
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
        npc_set.Add(new NPCLine());
    }

    public void AddLine()
    {
        npc_set.Add(new NPCLine());
    }

    public void RemoveLine() 
    {
        npc_set.RemoveAt(0);
    }

    public List<NPCLine> GetNpcSet()
    {
        return npc_set;
    }
}
