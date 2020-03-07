using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whitewall : MonoBehaviour
{
    public Slider slider;
    private float hp=300.0f;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = hp / 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp < 0) hp = 0;
        slider.value = hp / 100.0f;
        if (hp <= 0) GameObject.Destroy(this.gameObject);
    }
}
