using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour
{
    // Start is called before the first frame update
    public int debug = 0;
    private void OnCollisionEnter(Collision collision)
    {
         Collider[] boxcolliders = Physics.OverlapSphere(gameObject.transform.position, 1f);
         foreach (var boxcollider in boxcolliders)
         {
            debug = 1;
            if (boxcollider.tag == "player")
            { 
                boxcollider.SendMessage("GetIt"); 
                GameObject.Destroy(this.gameObject); 
            }
         }
    }
}
