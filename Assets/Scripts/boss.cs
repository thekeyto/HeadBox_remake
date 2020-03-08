using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class boss : MonoBehaviour
{
    public float totalhp;
    public float Speed;
    public Slider hpslider;
    public int debug;
    public GameObject redbox;
    public float hp1, hp2;
    public bool gameover;
    public GameObject bullet;

    private GameObject player1;
    private GameObject player2;
    public float hp;
    private float nowtime = 1;
    private int[] Damage;
    private Animation ani;
    private NavMeshAgent agent;
    private Vector3 player1Location;
    private Vector3 player2Location;
    private bool isdamage;
    private bool isdie;
    private float damagetime;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animation>();
        Damage = new int[50];
        hpslider.value = 1;
        agent = gameObject.GetComponent<NavMeshAgent>();
        hp = totalhp;
        agent.speed = Speed;
    }
    void attackplayer1()
    {
        //debug = 1;
        agent.SetDestination(player1Location);
        ani.Play("move");
    }
    void attackplayer2()
    {
        //debug = 2;
        agent.SetDestination(player2Location);
        ani.Play("move");
    }
    void attack()
    {
        Transform firePosition = transform.Find("firePosition");
        GameObject go = GameObject.Instantiate(bullet, firePosition.position, firePosition.rotation) as GameObject;
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (isdie == true) GameObject.Destroy(this.gameObject, 1.18f);
        if (hp == 0) return;
        player1 = GameObject.Find("player1");
        player2 = GameObject.Find("player2");
        hp1 = player1.GetComponent<Player>().gethp();
        hp2 = player2.GetComponent<Player>().gethp();
        player1Location = player1.gameObject.GetComponent<Transform>().position;
        player2Location = player2.gameObject.GetComponent<Transform>().position;
        hpslider.value = hp / totalhp;
        nowtime += Time.deltaTime;
        damagetime += Time.deltaTime;
        if (damagetime >= 0.5 && isdamage == true) isdamage = false;
        else
        if (nowtime >= 1.5f)
        {
            nowtime = 0;
            if (hp1 > 0 || hp2 > 0)
            {
                if (Vector3.Distance(this.transform.position, player1Location) <= 30.5f && hp1 > 0)
                {
                    transform.LookAt(player1Location);
                    ani.Play("attack1");
                    attack();
                }
                else
                if (Vector3.Distance(this.transform.position, player2Location) <= 30.5f && hp2 > 0)
                {
                    transform.LookAt(player2Location);
                    ani.Play("attack1");
                    attack();
                }
                else
                {
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
                    else ani.Play("idle");
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
        debug = 1;
        if (hp <= 0 && isdie == false)
        {
            isdie = true;
            hp = 0; GameObject.Find("gameController").gameObject.GetComponent<sceneCotroller>().nowenemnumber--;
            Transform boxplace = transform.Find("boxplace");
            GameObject.Instantiate(redbox,boxplace.position,boxplace.rotation);
            ani.Play("die");
            agent.ResetPath();
            GameObject.Destroy(this.gameObject, 1.18f);//播放死亡动画后消失
        }
    }
}
