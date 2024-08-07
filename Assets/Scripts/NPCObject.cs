using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : MonoBehaviour
{
    float Speed = 20f;
    float destroy_ypos = -3f;
    float init_ypos = 9f;
    float move_target;
    Animator animator;
    Coroutine move_courutine;
    int move_stack = 0;



    [SerializeField]
    GameObject Coin;
    bool is_coin = false;

    // Start is called before the first frame update
    void Start()
    {
        move_target = transform.position.y;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCoin(bool coin)
    {
        is_coin = coin;
        Coin.SetActive(coin);
    }

    public void StartMove()
    {
        if (move_courutine != null)
        {
            move_stack++;
        }
        else
        {
            move_courutine = StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        move_target -= 2;

        animator.SetBool("walk", true);
        while(transform.position.y > move_target)
        {
            transform.position += Vector3.down * Speed * Time.deltaTime;

            yield return null;
        }

        if (move_target <= destroy_ypos)
        {
            transform.position = new Vector3(transform.position.x, init_ypos, transform.position.z);
            move_target = init_ypos;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, move_target, transform.position.z);
        }
        animator.SetBool("walk", false);
        if(move_stack > 0)
        {
            move_stack--;
            move_courutine = StartCoroutine(Move());
        }
        move_courutine = null;
    }
}
