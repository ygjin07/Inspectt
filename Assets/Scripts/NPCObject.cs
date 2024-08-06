using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : MonoBehaviour
{
    float Speed = 20f;
    float destroy_ypos = -4.9f;
    float init_ypos = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Move()
    {
        float move_target = transform.position.y - 2;
        while(transform.position.y > move_target)
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;
            if (transform.position.y < destroy_ypos)
            {
                transform.position = new Vector3(transform.position.x, init_ypos, transform.position.z);
                yield break;
            }

            yield return null;
        }

        transform.position = new Vector3(transform.position.x, move_target, transform.position.z);
    }
}
