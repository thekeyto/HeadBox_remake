using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{//角色的控制器
    // Start is called before the first frame update
    public float speed;
    public float angularSpeed;
    public int number;

    private GameObject player;
    private float hp=100.0f;
    private float v;
    private float h;
    private int level;
    private Rigidbody rigidbody;
    private Animator ani;
    public float gethp()
    {
        return hp;
    }
    void Start()
    {
        player = this.GetComponent<GameObject>();
        ani = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
        hp = 100.0f;
        level = 1;
    }
    public GameObject getplayer()
    {
        return player;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        v = Input.GetAxis("Vertical" + number);
        rigidbody.velocity = transform.forward * v * speed;
        h = Input.GetAxis("Horizontal" + number);
        rigidbody.angularVelocity = transform.up * angularSpeed * h;
        if (v!=0)
        {
            ani.SetBool("run", true);
            ani.SetFloat("runValue", h);
        }
        else ani.SetBool("run", false);
    }
    void GetIt()
    {
        hp = hp + 50 > 100 ? 100 : hp + 50;//为了更有策略性拾取红盒，每次+50hp
        level++;
    }
    void TakeDamage()
    {
        hp -= 10.0f;
        if (hp <= 0) ani.SetBool("die", true);
        GameObject.Destroy(this.gameObject,1.5f);
    }
}
