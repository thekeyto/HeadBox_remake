using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Transform[] BornArea;
    // Start is called before the first frame update
    void Start()
    {
        BornArea = new Transform[3];
        BornArea[0] = transform.Find("bornArea0");
        BornArea[1] = transform.Find("bornArea1");
        BornArea[2] = transform.Find("bornArea2");
    }
    public void getEnemy()
    {
        int i = Random.Range(0, 3);
        while (i < 0 || i > 3) i = Random.Range(0, 3);
        GameObject.Instantiate(enemy, BornArea[i].position, BornArea[i].rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}