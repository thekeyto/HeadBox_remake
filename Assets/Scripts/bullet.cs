using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float[] damage=new float[30];
    private float[] time = new float[30];//控制摧毁时间摧毁射程
    public int nowWeapon;
    void Start()
    {
        damage[1] = 25.0f;time[1] = 0.7f;
        damage[2] = 40.0f;time[2] = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Destroy(this.gameObject, time[nowWeapon]);   
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(this.gameObject);
        if (other.tag == "enemy")
            other.SendMessage("TakeDamage",damage[nowWeapon]);
        if (other.tag == "wall")
            other.SendMessage("TakeDamage",damage[nowWeapon]);
    }
}