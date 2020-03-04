using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void getBox()
    {
        GameObject newBox = Instantiate<GameObject>(box) as GameObject;
        newBox.transform.position = new Vector3(Random.Range(-39,39),5,Random.Range(-39,39));
    }
    // Update is called once per frame
    void Update()
    {

    }
}
