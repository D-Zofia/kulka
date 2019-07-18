using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene("lvl");
    }
    public void quit()
    {
        Application.Quit();
    }

}
