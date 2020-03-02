using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Vector3 player1Location;
    public Vector3 player2Location;
    public int hp;
    public GameObject player1;
    public GameObject player2;
    private bool gameover;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        gameover = Director.getInstance().currentSceneController.getGameover();
        if (!gameover)
        {
            if (hp<=0)
            {
                DestroyObject(this.gameObject);
            }
            else
            {
                NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
                if (Vector3.Distance(this.transform.position, player1Location) < Vector3.Distance(this.transform.position, player2Location))
                    agent.SetDestination(player1Location);
                else
                    agent.SetDestination(player2Location);
            }
        }
        else
        {
            NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent>();
            agent.velocity = Vector3.zero;
            agent.ResetPath();
        }
    }
}
