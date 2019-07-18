using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public float szybkosc=5;
    private float opoznienie = 2.1f;

    bool odliczanie=false;
    Vector3 pozycja;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0&&odliczanie)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position+new Vector3(0, -10, 0),szybkosc*Time.deltaTime);
        }
        if (transform.position.y> -0.1f) odliczanie = true;
        if (transform.position.y < -7)
        {
            transform.position +=new Vector3(0,-10,0);
            timer = platform_control.czas_pomocniczy *opoznienie; 
            odliczanie = false;
        }
    }
}
