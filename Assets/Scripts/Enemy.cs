using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float totalhp = 100;
    public float Speed;
    public Slider hpslider;
    public int debug;
    public float hp1, hp2;
    public bool gameover;
    public float hp;

    private GameObject player1;
    private GameObject player2;
    private float nowtime = 1;
    private int[] Damage;
    private Animator ani;
    private NavMeshAgent agent;
    private Vector3 player1Location;
    private Vector3 player2Location;
    private bool isdamage;
    private float damagetime;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        Damage = new int[50];
        hpslider.value = 1;
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        hp = totalhp;
    }
    void attackplayer1()
    {
        //debug = 1;
        agent.SetDestination(player1Location);
        ani.SetBool("run", true);
    }
    void attackplayer2()
    {
        //debug = 2;
        agent.SetDestination(player2Location);
        ani.SetBool("run", true);
    }
    // Update is called once per frame
    void Update()
    {
        
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        hp1 = player1.GetComponent<Player>().gethp();
        hp2 = player2.GetComponent<Player>().gethp();
        player1Location = player1.gameObject.GetComponent<Transform>().position;
        player2Location = player2.gameObject.GetComponent<Transform>().position;
        hpslider.value = hp / totalhp;
        nowtime += Time.deltaTime;
        damagetime += Time.deltaTime;
        if (damagetime >= 0.5 && isdamage==true) isdamage = false;
        else
        if (nowtime >= 1.5f)
        {
            nowtime = 0;
            if (hp1 > 0 || hp2 > 0)
            {
                if (Vector3.Distance(this.transform.position, player1Location) <= 3.5f && hp1 > 0)
                {
                    transform.LookAt(player1Location);
                    ani.SetBool("attack", true);
                    player1.GetComponent<Player>().TakeDamage(15.0f);
                }
                else
                if (Vector3.Distance(this.transform.position, player2Location) <= 3.5f && hp2 > 0)
                {
                    transform.LookAt(player2Location);
                    ani.SetBool("attack", true);
                    player2.GetComponent<Player>().TakeDamage(15.0f);
                }
                else
                {
                    ani.SetBool("attack", false);
                    agent.ResetPath();
                    if (hp1 > 0 && hp2 > 0)
                    {
                        if (Vector3.Distance(this.transform.position, player1Location) < Vector3.Distance(this.transform.position, player2Location))
                            attackplayer1();
                        else attackplayer2();
                    }
                    else
                    if (hp1 <= 0) //控制动画
                    {
                        attackplayer2();
                    }
                    else
                    if (hp2 <= 0) //控制动画
                    {
                        attackplayer1();
                    }
                    else ani.SetBool("run", false);
                }
            }
            else agent.ResetPath();
        }
    }
    void TakeDamage(float damage)
    {
        hp -= damage;
        damagetime = 0;
        isdamage = true;
        if (hp < 0) hp = 0;
        debug = 1;
        if (hp <= 0)
        {
            ani.SetBool("death", true);
            agent.ResetPath();
            GameObject.Destroy(this.gameObject, 1.18f);//播放死亡动画后消失
        }
    }
}