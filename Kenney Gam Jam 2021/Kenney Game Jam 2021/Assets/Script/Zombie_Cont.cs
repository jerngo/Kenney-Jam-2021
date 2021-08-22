using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Cont : MonoBehaviour
{
    public Transform Player;
    int moveSpeedTemp;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    Animator anim;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveSpeedTemp = MoveSpeed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.LookAt(Player);

        //Debug.Log(Vector3.Distance(transform.position, Player.position));

        if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            anim.SetBool("Chasing", true);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MinDist)
            {
                MoveSpeed = 0;
                anim.SetBool("Attack", true);
            }
            else
            {
                MoveSpeed = moveSpeedTemp;
                anim.SetBool("Attack", false);
            }

        }
        else {
            anim.SetBool("Chasing", false);
        }
    }
}
