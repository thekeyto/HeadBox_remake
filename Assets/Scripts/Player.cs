using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{//角色的控制器
    // Start is called before the first frame update
    public float speed;
    public float angularSpeed;
    public int number;
    public Slider hpslider;
    public float totalhp;
    public int level;
    public float hp = 100.0f;

    private GameObject player;
    private float v;
    private bool isdie = false;
    private float h;
    private Rigidbody rigidbody;
    private Animator ani;
    void Start()
    {
        player = this.GetComponent<GameObject>();
        ani = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
        hpslider.value = 1;
        hp = totalhp;
        level = 1;
        isdie = false;
    }
    public float gethp()
    {
        return hp;
    }
    public GameObject getplayer()
    {
        return player;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0&&isdie==false) 
        { isdie = true; ani.SetBool("die", true); return;}
        if (hp <= 0) return;
        v = Input.GetAxis("Vertical" + number);
        rigidbody.velocity = transform.forward * v * speed;
        h = Input.GetAxis("Horizontal" + number);
        rigidbody.angularVelocity = transform.up * angularSpeed * h;
        if (v > 0)
        {
            ani.SetBool("run", true);
            ani.SetFloat("runValue", h);
        }
        else ani.SetBool("run", false);
        if (v < 0)
        {
            ani.SetBool("movebackward", true);
        }
        else ani.SetBool("movebackward", false);
        if (Input.GetKey(KeyCode.K)||Input.GetKey(KeyCode.Minus))//既然有跳跃动作，那就干脆用了吧
        {
            ani.SetBool("jump", true);
        }
        else ani.SetBool("jump", false);
        hpslider.value = hp / totalhp;//血量的显示
    }
    void GetIt()
    {
        hp = hp + 50 > 100 ? 100 : hp + 50;//为了更有策略性拾取红盒，每次+50hp
        level++;
    }
    public void TakeDamage()
    {
        hp -= 10.0f;
    }
}