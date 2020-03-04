using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag=="player")
        {
            GameObject.Destroy(this.gameObject);
            collider.SendMessage("GetIt");
        }
    }
}
