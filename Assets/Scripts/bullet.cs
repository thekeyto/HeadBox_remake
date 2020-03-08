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
        damage[3] = 25.0f;time[3] = 0.7f;
        damage[4] = 40.0f;time[4] = 0.7f;
        damage[5] = 25.0f; time[5] = 0.7f;
        damage[6] = 40.0f; time[6] = 0.7f;
        damage[7] = 60.0f; time[7] = 0.2f;
        damage[8] = 75.0f; time[8] = 0.2f;
        damage[9] = 90.0f; time[9] = 0.2f;
        damage[10] = 75.0f; time[10] = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Destroy(this.gameObject, time[nowWeapon]);   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (nowWeapon <= 4) GameObject.Destroy(this.gameObject);
        else if (nowWeapon <= 6 && other.tag != "bullet") GameObject.Destroy(this.gameObject);
        if (other.tag == "enemy")
            other.SendMessage("TakeDamage",damage[nowWeapon]);
        if (other.tag == "wall")
            other.SendMessage("TakeDamage",damage[nowWeapon]);
    }
}