using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
   
    public Transform[] spawnnoktasi;  
    public Transform dusmangemi, dusmangemi1,dusmangemi2, dusmangemi3, dusmangemi5, dusmangemi6,dusmangemi4;
    float timer;
    float cooldawn=2f;


    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        int dusmanSayisi = FindObjectsOfType<dusman>().Length;
       
       
            if (dusmanSayisi < 7)
            {

            if (Time.time > timer)
            {
                for (int i = 0; i <= 5; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman(i));
                }
            }
            
            }

        int dusmanSayisi1 = FindObjectsOfType<dusmangemi21>().Length;
        if (dusmanSayisi1 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 3; i < 4; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman1(i));
                }
            }

        }

        int dusmanSayisi2 = FindObjectsOfType<dusmangemi22>().Length;
        if (dusmanSayisi2 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 2; i < 3; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman2(i));
                }
            }

        }
        int dusmanSayisi3 = FindObjectsOfType<dusmangemi23>().Length;
        if (dusmanSayisi3 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 0; i < 1; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman3(i));
                }
            }

        }
        int dusmanSayisi4 = FindObjectsOfType<dusmangemi31>().Length;
        if (dusmanSayisi4 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 2; i < 3; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman4(i));
                }
            }

        }
        int dusmanSayisi5 = FindObjectsOfType<dusmangemi32>().Length;
        if (dusmanSayisi5 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 4; i < 5; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman5(i));
                }
            }

        }
        int dusmanSayisi6 = FindObjectsOfType<dusmangemi33>().Length;
        if (dusmanSayisi6 < 1)
        {

            if (Time.time > timer)
            {
                for (int i = 0; i < 1; i++)
                {
                    timer = Time.time + cooldawn;
                    StartCoroutine(spawndusman6(i));
                }
            }

        }
    }
  
    IEnumerator spawndusman(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi, spawnnoktasi[deger].position, Quaternion.identity);
        
    }
    IEnumerator spawndusman1(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi1, spawnnoktasi[deger].position, Quaternion.identity);

    }
    IEnumerator spawndusman2(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi2, spawnnoktasi[deger].position, Quaternion.identity);

    }
    IEnumerator spawndusman3(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi3, spawnnoktasi[deger].position, Quaternion.identity);

    }
    IEnumerator spawndusman5(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi5, spawnnoktasi[deger].position, Quaternion.identity);

    }
    IEnumerator spawndusman6(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi6, spawnnoktasi[deger].position, Quaternion.identity);

    }
    IEnumerator spawndusman4(int deger)
    {
        float zaman = Random.Range(0.001f, 0.002f);

        yield return new WaitForSeconds(zaman);

        Instantiate(dusmangemi4, spawnnoktasi[deger].position, Quaternion.identity);

    }
}
