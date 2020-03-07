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
    public int debug;
    public int number;

    public int nowWeapon = 1, totalweapon = 1;//当前武器、总武器数量
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
        bulletnumbers[2] = 60;fullbulletnumbers[2] = 60;
        cooltime[1] = 0.5f;
        cooltime[2] = 0.5f;
        speed[1] = 40.0f;
        speed[2] = 40.0f;
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
            GameObject go = GameObject.Instantiate(bullets[nowWeapon], firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed[nowWeapon];
        }
    }
    void updateText()
    {
        text.text = "nowWeapon:"+nowWeapon+" bullet:"+bulletnumbers[nowWeapon];
    }
    // Update is called once per frame
    void Update()
    {
        updateText();
        weapontime[nowWeapon] += Time.deltaTime;
        nowgun.transform.position = transform.Find("gunplace").position;
        nowgun.transform.rotation = transform.Find("gunplace").rotation;
        if (weapontime[nowWeapon] > 20) weapontime[nowWeapon] = 10;
        if ((Input.GetKey(KeyCode.L) && number == 1) || (Input.GetKey(KeyCode.Keypad3) && number == 2))
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
