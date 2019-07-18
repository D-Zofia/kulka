using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
