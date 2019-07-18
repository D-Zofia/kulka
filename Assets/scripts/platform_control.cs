using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platform_control : MonoBehaviour
{
    public float czas = 1;
    public float trudnosc=2; //przyspiesza gre
    [Tooltip("W zasadzie liczba platform na scenie")]
    public float opoznienie = 1.8f;
    [Space(5)]
    public Text scoret;

    //bo nie wiem jak inaczej przesłać zmienną do innego skryptu
    public static float czas_pomocniczy;
    public static float pozniej;
    
    private Vector3[] kierunki;
    private Vector3 pozycja;
    private Vector3 ostatnia_pozycja;
    int numer = 1;
    bool proste = false;
    private float czekaj = 2; //do timera
    private int score=0;

    void Start()
    {
        czas_pomocniczy = czas;
        pozniej = opoznienie;

        pozycja = new Vector3(0, 0, 0);
        kierunki = new Vector3[4];
        //poniżej tylko przypisanie przesunięć wzgl. pozycji obecnej
        kierunki[0] = Vector3.forward*4;
        kierunki[1] = Vector3.back*4;
        kierunki[2] = Vector3.left*4;
        kierunki[3] = Vector3.right*4;
        
        losowanie_platformy();
        Nowa_Pozycja();
        transform.GetChild(numer).transform.position = pozycja;
    }


    void Update()
    {
        czekaj -= Time.deltaTime;
        if (czekaj <= 0)
        {
            losowanie_platformy();
            Nowa_Pozycja();

            czekaj = czas_pomocniczy;
            score++;
            if(czas_pomocniczy>=0.2f)czas_pomocniczy -= Time.deltaTime*trudnosc;
            
        }

        transform.GetChild(numer).transform.position = Vector3.Lerp(transform.GetChild(numer).transform.position,
                                                                        pozycja, Time.deltaTime * 10);
        scoret.text = score.ToString();
    }


    //------------------------------------------------------------------------------------------------

    private void losowanie_platformy()
    {
        do
        {
            numer = Mathf.CeilToInt(Random.Range(0.01f, transform.childCount) - 1);
        } while (transform.GetChild(numer).transform.position.y >= -7);
    }
    private void Nowa_Pozycja()
    {
        Vector3 nowa_pozycja;
        if (proste)
        {
            nowa_pozycja = pozycja + new Vector3(pozycja.x-ostatnia_pozycja.x,0,pozycja.z-ostatnia_pozycja.z);
        }
        else
        {
            do
            {
                nowa_pozycja = pozycja;
                nowa_pozycja += kierunki[Mathf.CeilToInt(Random.Range(-0.99f, 3))];
            } while (nowa_pozycja == ostatnia_pozycja);
        }

    
        ostatnia_pozycja = pozycja;
        pozycja = nowa_pozycja;
        transform.GetChild(numer).transform.position = pozycja + new Vector3(0, -7, 0);

        if (transform.GetChild(numer).tag == "proste")
        {
            proste = true;
        if (ostatnia_pozycja.x != pozycja.x)
            {
                transform.GetChild(numer).transform.eulerAngles = new Vector3(-90, 90, 0);
            }
            else
            {
                transform.GetChild(numer).transform.eulerAngles = new Vector3(-90, 0, 0);
            }
        }
        else { proste = false; }
    }
}
