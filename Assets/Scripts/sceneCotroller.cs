using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneCotroller : MonoBehaviour
{
    // Start is called before the first frame update
    private Player player1;
    private Player player2;

    public int enemyCount;
    public float nowtime;
    public int debug;
    public int turn=0;

    private enemySpawner enemyspawner;
    private boxSpawner boxspawner;
    private bossspawner bossspawner;
    private bool gameOver;
    private bool flag1;
    private bool flag2;
    public int enemynumbers=1;
    public int boxnumber=2;
    private float turntime = 10;
    public int fullenemynumbers=1;
    void Start()
    {
        gameOver = false;
        nowtime = 11;//进入第一轮
        enemyspawner = Singleton<enemySpawner>.Instance;
        boxspawner = Singleton<boxSpawner>.Instance;
        bossspawner = Singleton<bossspawner>.Instance;
    }
    public bool getGameover()
    {
        return gameOver;
    }
    public void setGameover()
    {
        gameOver = true;
    }
    void spawn(int number)
    {
        for (int i = 1; i <= number; i++)
            enemyspawner.getEnemy();
    }

    void spawnbox(int number)
    {
        for (int i = 1; i <= number; i++)
            boxspawner.getBox();
    }
    void bossspawn(int number)
    {
        for (int i = 1; i <= number; i++)
            bossspawner.getBoss();
        debug = 5;
    }
    void Update()
    {
        player1 = GameObject.Find("player1").gameObject.GetComponent<Player>();
        player2 = GameObject.Find("player2").gameObject.GetComponent<Player>();
        nowtime += Time.deltaTime;
        if (player1.gethp() < 0 && player2.gethp() < 0) return; 
        if (nowtime >= turntime)//设置每turntime一轮
        {
            nowtime = 0;
            flag1 = false;
            flag2 = false;
            turn++;
            turntime += turn;
            fullenemynumbers +=turn;//使生成的敌人数量在后期不会过多
            enemynumbers = fullenemynumbers/2;
            if (turn <= 4) boxnumber++;
            else boxnumber = Random.Range(3, 6);//第五轮以后每轮生成3到5个红盒子

            spawn(enemynumbers>=3 ? enemynumbers/3 : 0);
            enemynumbers -= enemynumbers >= 3 ? enemynumbers / 3 : 0;
            if (enemynumbers < 0) enemynumbers = 0;

            spawnbox(boxnumber);
        }
        //游戏机制设置每5s出来一波
        if (nowtime>=5&&flag1==false)
        {
            spawn(enemynumbers >= 2 ? enemynumbers / 2 : 0);
            enemynumbers -= enemynumbers >= 2 ? enemynumbers / 2 : 0;
            if (enemynumbers < 0) enemynumbers = 0;
            flag1 = true;
        }
        if (nowtime>=10&&flag2==false)
        {
            spawn(enemynumbers);
            flag2 = true;
            bossspawn(fullenemynumbers / 5);//设置一比五的比例出现boss
        }
        if (player1.gethp() <= 0 && player2.gethp() <= 0) setGameover();
    }
}