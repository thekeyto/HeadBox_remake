using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float hp = 100f;

    public Health()
    {
        hp = 100f;
    }
    public float getHp()
    {
        return hp;
    }
    public void setHP(float hp)
    {
        this.hp = hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
