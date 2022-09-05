using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayin : MonoBehaviour
{
    public Transform fici, cikis;
    public Transform[] nokta;
    Transform klon;
    float timer;
    public float cooldown;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        varil();

    }
    IEnumerator firlat(int deger)
    {
        float zaman = Random.Range(0.1f, 0.2f);
        
        yield return new WaitForSeconds(zaman);
        
        klon = Instantiate(fici, nokta[deger].position, Quaternion.identity);
        klon.GetComponent<Rigidbody>().velocity = nokta[deger].forward * -30;
        Debug.Log(deger);


    }
    void varil()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

                if (Time.time > timer)
                {
           
                    for (int i = 0; i <=1; i++)
                    {
               
                    timer = Time.time + cooldown;
                    StartCoroutine(firlat(i));
                    }
                }

        }
    }
}
