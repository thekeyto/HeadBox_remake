using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void returnmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Play1()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause()
    {
        if (Time.timeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
    public void Play2()
    {
        SceneManager.LoadScene(2);
    }
    public void Play3()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
