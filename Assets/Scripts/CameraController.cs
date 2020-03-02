using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    private Vector3 offset;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = this.GetComponent<Camera>();
        offset = transform.position - (player1.position + player2.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1 == null)
        {
            camera.transform.position = new Vector3(player2.position.x, camera.transform.position.y, player2.position.z);
        }
        else
        if (player2 == null)
        {
            camera.transform.position = new Vector3(player1.position.x, camera.transform.position.y, player1.position.z);
        }
        else
        if (player1 == null && player2 == null) return;
        else
        {
            transform.position = (player1.position + player2.position) / 2 + offset;
            float distance = Vector3.Distance(player1.position, player2.position);
            float size = distance * 0.58f;
            camera.orthographicSize = size;
        }
    }
}
