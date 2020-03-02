using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneCotroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public int enemyCount;

    private bool gameOver;
    void Start()
    {
        gameOver = false;
    }
    public bool getGameover()
    {
        return gameOver;
    }
    public void setGameover()
    {
        gameOver = true;
    }
}
