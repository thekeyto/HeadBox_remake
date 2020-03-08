using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] weapons = new GameObject[11];//武器预制
    public GameObject[] bullets = new GameObject[11];//子弹预制
    public Text text;
    public float debug;
    public int number;

    public int nowWeapon = 1, totalweapon = 1,level=1;//当前武器、总武器数量
    private float[] cooltime =new float[11];//各武器的冷却时间
    private float[] weapontime =new float[11];//各当前时间
    private float[] speed = new float[11];
    private Transform gunPosition,firePosition;
    private GameObject nowgun;
    public int[] bulletnumbers=new int[11];
    public int[] fullbulletnumbers = new int[11];
    void Start()
    {
        bulletnumbers[1] = 99999;fullbulletnumbers[1] = 99999;
        bulletnumbers[2] = 100;fullbulletnumbers[2] = 100;
        bulletnumbers[3] = 60;fullbulletnumbers[3] = 60;
        bulletnumbers[4] = 60; fullbulletnumbers[4] = 60;
        bulletnumbers[5] = 30; fullbulletnumbers[5] = 30;
        bulletnumbers[6] = 30; fullbulletnumbers[6] = 30;
        bulletnumbers[7] = 20; fullbulletnumbers[7] = 20;
        bulletnumbers[8] = 10; fullbulletnumbers[8] = 10;
        bulletnumbers[9] = 10; fullbulletnumbers[9] = 10;
        bulletnumbers[10] = 5; fullbulletnumbers[10] = 5;
        cooltime[1] =weapontime[1]= 0.5f; cooltime[6] = weapontime[6] = 1.0f;
        cooltime[2] = weapontime[2] = 0.5f; cooltime[7] = weapontime[7] = 1.5f;
        cooltime[3] = weapontime[3] = 0.1f; cooltime[8] = weapontime[8] = 2.0f;
        cooltime[4] = weapontime[4] = 0.3f; cooltime[9] = weapontime[9] = 2.0f;
        cooltime[5] = weapontime[5] = 1.0f; cooltime[10] = weapontime[10] = 3.0f;
        speed[1] = 40.0f; speed[6] = 60.0f;
        speed[2] = 40.0f; speed[7] = 0;
        speed[3] = 60.0f; speed[8] = 0;
        speed[4] = 70.0f; speed[9] = 0;
        speed[5] = 40.0f; speed[10] = 0;
        gunPosition = transform.Find("gunplace");
        bullets[nowWeapon].GetComponent<bullet>().nowWeapon = nowWeapon;
        nowgun = GameObject.Instantiate(weapons[nowWeapon], gunPosition.position, gunPosition.rotation) as GameObject;
    }

    void changeweapon()
    {
        nowWeapon=nowWeapon+1>totalweapon ? 1 : nowWeapon+1;
        GameObject.Destroy(nowgun);
        bullets[nowWeapon].GetComponent<bullet>().nowWeapon = nowWeapon;
        gunPosition = transform.Find("gunplace");
        nowgun =GameObject.Instantiate(weapons[nowWeapon], gunPosition.position, gunPosition.rotation) as GameObject;
    }

    void attack()
    {
        if (bulletnumbers[nowWeapon] > 0)
        {
            debug = 1;
            bulletnumbers[nowWeapon]--;
            firePosition = nowgun.gameObject.transform.Find("firePosition");
            if (nowWeapon <= 4)
            {
                debug = speed[nowWeapon];
                GameObject go = GameObject.Instantiate(bullets[nowWeapon], firePosition.position, firePosition.rotation) as GameObject;
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed[nowWeapon];
            }
            else if (nowWeapon >= 7)
                    GameObject.Instantiate(bullets[nowWeapon], firePosition.position, firePosition.rotation);
            else
                for(int i=1;i<=10;i++)
                {
                    GameObject go = GameObject.Instantiate(bullets[nowWeapon], firePosition.position, Quaternion.Euler(firePosition.rotation.eulerAngles.x + Random.Range(-10,10), firePosition.rotation.eulerAngles.y+ Random.Range(-10, 10), firePosition.rotation.eulerAngles.z+Random.Range(-10, 10))) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed[nowWeapon];
                }
        }
    }
    void updateText()
    {
        text.text ="level:" + level +" nowWeapon:"+nowWeapon+" bullet:"+bulletnumbers[nowWeapon];
    }
    // Update is called once per frame
    void Update()
    {
        updateText();
        weapontime[nowWeapon] += Time.deltaTime;
        nowgun.transform.position = transform.Find("gunplace").position;
        nowgun.transform.rotation = transform.Find("gunplace").rotation;
        if (weapontime[nowWeapon] > 20) weapontime[nowWeapon] = 10;
        if ((Input.GetKeyUp(KeyCode.L) && number == 1) || (Input.GetKeyUp(KeyCode.Keypad3) && number == 2))
        {
            changeweapon();
        }
        if ((Input.GetKey(KeyCode.J) && number == 1) || (Input.GetKey(KeyCode.Keypad1) && number == 2))
        if(weapontime[nowWeapon]>=cooltime[nowWeapon])
        {
            weapontime[nowWeapon] = 0;
            attack();
        }
    }
}
