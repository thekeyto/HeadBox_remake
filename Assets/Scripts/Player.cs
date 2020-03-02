using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{//角色的控制器
    // Start is called before the first frame update
    private GameObject player;
    public int number;
    private float hp;
    void Start()
    {
        player = this.gameObject;
        hp = 100.0f;
    }
    public GameObject getplayer()
    {
        return player;
    }
    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Vertical"+number) * 0.1f;
        var z = Input.GetAxis("Horizontal"+number) * 0.1f;
        transform.Translate(x, 0, z);
    }
}
