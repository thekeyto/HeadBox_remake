using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rigidbody;
    public int number;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("VerticalPlayer" + number) * 0.1f;//根据编号进行移动
        float z = Input.GetAxis("HorizontalPlayer" + number) * 0.1f;
        rigidbody.transform.Translate(x, 0, z);
    }
}
