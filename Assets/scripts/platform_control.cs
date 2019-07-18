using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class platform_control : MonoBehaviour
{
    public float czas = 1;
    public float trudnosc=2; //przyspiesza gre
    public Text scoret;

    public static float czas_pomocniczy; //bo nie wiem jak inaczej przesłać zmienną "czas" do innego skryptu
    
    private Vector3[] kierunki;
    private Vector3 pozycja;
    private Vector3 ostatnia_pozycja;
    int numer = 1;
    private float czekaj = 2; //do timera
    private int score=1;

    void Start()
    {
        czas_pomocniczy = czas;
        pozycja = new Vector3(0, 0, 0);

        kierunki = new Vector3[4];
        //poniżej tylko przypisanie przesunięć wzgl. pozycji obecnej
        kierunki[0] = Vector3.forward*4;
        kierunki[1] = Vector3.back*4;
        kierunki[2] = Vector3.left*4;
        kierunki[3] = Vector3.right*4;

        pozycja += kierunki[Mathf.CeilToInt(Random.Range(-0.99f, 3))];
        losowanie_platformy();
        transform.GetChild(numer).transform.position = pozycja;
        transform.GetChild(numer).transform.position = Vector3.Lerp(pozycja + new Vector3(0, -7, 0),
                                                                        pozycja, Time.deltaTime * 10);
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
        do
        {
            nowa_pozycja = pozycja;
            nowa_pozycja += kierunki[Mathf.CeilToInt(Random.Range(-0.99f, 3))];
        } while (nowa_pozycja == ostatnia_pozycja);

        ostatnia_pozycja = pozycja;
        pozycja = nowa_pozycja;
        transform.GetChild(numer).transform.position = pozycja + new Vector3(0, -7, 0);
    }
}
