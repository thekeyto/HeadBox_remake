using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        GameObject.Destroy(this.gameObject, 3.0f);
    }
    private void OnTriggerEnter(Collider bosscollider)
    {
        if (bosscollider.tag == "player"||bosscollider.tag=="wall"||bosscollider.tag=="enemy")
                bosscollider.SendMessage("TakeDamage",25);
        GameObject.Destroy(this.gameObject);
    }
}
