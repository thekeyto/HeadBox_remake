using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{//角色的控制器
    // Start is called before the first frame update
    public float speed;
    public float angularSpeed;
    private GameObject player;
    public int number;
    private float hp;
    private float v;
    private float h;
    private Rigidbody rigidbody;
    private Animator ani;
    void Start()
    {
        player = this.GetComponent<GameObject>();
        ani = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
        hp = 100.0f;
    }
    public GameObject getplayer()
    {
        return player;
    }
    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical" + number);
        rigidbody.velocity = transform.forward * v * speed;
        h = Input.GetAxis("Horizontal" + number);
        rigidbody.angularVelocity = transform.up * angularSpeed * h;
        ani.SetFloat("runValue",h);
    }
}
