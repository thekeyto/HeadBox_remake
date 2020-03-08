using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genade : MonoBehaviour
{
    public GameObject explosion;
    public AudioClip grenade;
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(grenade, transform.position);

        Collider[] grenadecolliders = Physics.OverlapSphere(transform.position, 15.0f);
        foreach(var greanadecollider in grenadecolliders)
        {
            if (greanadecollider.tag=="enemy"||greanadecollider.tag=="wall")
            {
                float distance = Vector3.Distance(transform.position, greanadecollider.transform.position);
                greanadecollider.SendMessage("TakeDamage", 300.0f/distance);
            }
        }
        GameObject.Instantiate(explosion, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }
}
