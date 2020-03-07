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
    public int debug;
    public float hp = 100.0f;
    public GameObject whitewall;
    public GameObject gren;

    private GameObject player;
    private playerAttack attack;
    private float v;
    private bool isdie = false;
    private float h;
    private Rigidbody rigidbody;
    private Animator ani;
    private float damagetime = 0;
    private bool damageflag = false;
    private bool ablegrenade;
    private bool ablewall;
    private int grenade = 5;
    private int wall = 10;
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
        damagetime += Time.deltaTime;
        if (damagetime > 0.5f && damageflag == true)
        {    
            ani.SetBool("damage", false);
            damageflag = false;
        }
        if (hp <= 0&&isdie==false) 
        { isdie = true; ani.SetBool("die", true); return;}
        if (hp <= 0) return;
        hpslider.value = hp / totalhp;//血量的显示
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
        if ((Input.GetKey(KeyCode.K)&&number==1)||(number==2&&Input.GetKey(KeyCode.Keypad2)))//既然有跳跃动作，那就干脆用了吧
        {
            rigidbody.AddForce(new Vector3(0,10,0));
            ani.SetBool("jump", true);
        }
        else ani.SetBool("jump", false);
        if ((Input.GetKeyUp(KeyCode.U) && number == 1) || (number == 2 && Input.GetKeyUp(KeyCode.Keypad4)))
        if (wall>0&&ablewall==true)
        {
            wall--;
            Transform wallplace = transform.Find("wallPlace");
            GameObject.Instantiate(whitewall, wallplace.position, wallplace.rotation);
        }
        if ((Input.GetKeyUp(KeyCode.I) && number == 1) || (number == 2 && Input.GetKeyUp(KeyCode.Keypad5)))
            if (grenade > 0&&ablegrenade==true)
            {
                debug = 3;
                grenade--;
                Transform wallplace = transform.Find("wallPlace");
                GameObject go= GameObject.Instantiate(gren, wallplace.position, wallplace.rotation) as GameObject;
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * 20;
            }
    }
    void GetIt()
    {
        attack = gameObject.GetComponent<playerAttack>();
        hp = hp + 50 > 100 ? 100 : hp + 50;//为了更有策略性拾取红盒，每次+50hp
        for (int i = 1; i <= level / 5 - 1; i++) 
            attack.bulletnumbers[i] = attack.bulletnumbers[i] + attack.fullbulletnumbers[i] > attack.fullbulletnumbers[i] ? attack.fullbulletnumbers[i] : attack.bulletnumbers[i] + attack.fullbulletnumbers[i];
        level++;
        if (level % 5 == 0)//每五级解锁一把枪械
        {
            attack.totalweapon++;
        }
        wall = 10;grenade = 5;
        if (level == 10) ablewall = true;
        if (level == 15) ablegrenade = true;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0; {rigidbody.velocity = transform.forward*0; rigidbody.angularVelocity = transform.up * 0; ; }
        hpslider.value = hp / totalhp;//血量的显示
        debug = 5;
        ani.SetBool("damage", true);
        damagetime = 0;
        damageflag = true;
    }
}