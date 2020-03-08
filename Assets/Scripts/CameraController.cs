using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float debug;

    private Vector3 offset;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        player1 = GameObject.Find("player1").gameObject.GetComponent<Transform>();
        player2 = GameObject.Find("player2").gameObject.GetComponent<Transform>();
        offset = transform.position - (player1.position + player2.position) / 2;
    }

    float mypow(float x,float y)
    {
        return (x-y)*(x-y);
    }
    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.Find("player1").gameObject.GetComponent<Transform>();
        player2 = GameObject.Find("player2").gameObject.GetComponent<Transform>();
        transform.position = (player1.position + player2.position) / 2 + offset;
        float distance = Mathf.Sqrt(mypow(player1.position.x, player2.position.x)+ mypow(player1.position.y, player2.position.y)+ mypow(player1.position.z, player2.position.z)) ;
        debug = distance;
        float size = distance * 0.4f;
        camera.fieldOfView = size+10.0f;
    }
}
