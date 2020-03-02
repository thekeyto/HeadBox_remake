using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : System.Object 
{//使用单例类
    private static Director _instance;
    public sceneCotroller currentSceneController { get; set; }
    // Start is called before the first frame update
    private Director() { }
    public static Director getInstance()
    {
        if (_instance==null)
        {
            _instance = new Director();
        }
        return _instance;
    }
}
