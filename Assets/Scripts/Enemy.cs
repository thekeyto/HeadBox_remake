using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int hp;
    public GameObject player1;
    public GameObject player2;
    private bool gameover;
    private int[] Damage;
    private Animator ani;
    private Vector3 player1Location;
    private Vector3 player2Location;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
        Damage = new int[50];
    }
    // Update is called once per frame
    void Update()
    {
        gameover = Director.getInstance().currentSceneController.getGameover();
        if (!gameover)
        {
            if (hp <= 0)
            {
                DestroyObject(this.gameObject);
            }
            else
            {
                NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
                if (Vector3.Distance(this.transform.position, player1Location) < Vector3.Distance(this.transform.position, player2Location))
                    if (Vector3.Distance(this.transform.position, player1Location) < 10) //控制动画
                    {
                        agent.SetDestination(player1Location);
                        ani.SetBool("run", true);
                    }
                    else
                    if (Vector3.Distance(this.transform.position, player2Location) < 10) //控制动画
                    {
                        agent.SetDestination(player2Location);
                        ani.SetBool("run", true);
                    }
                    else ani.SetBool("run", false);
                if (Vector3.Distance(this.transform.position, player1Location) <= 0.3)
                {
                    ani.SetBool("attack", true);
                }
                else
                if (Vector3.Distance(this.transform.position, player2Location) <= 0.3)
                {
                    ani.SetBool("attack", true);
                }
                else ani.SetBool("attack", false);
            }
        }
        else
        {
            NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
            agent.velocity = Vector3.zero;
            agent.ResetPath();
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "player") collider.SendMessageUpwards("TakeDamage");
    }
    void takeDamage(int weapon)
    {
        hp -= Damage[weapon];
        if (hp<=0)
        {
            ani.SetBool("death", true);
            GameObject.Destroy(this.gameObject,1.18f);//播放死亡动画后消失
        }
    }
}
