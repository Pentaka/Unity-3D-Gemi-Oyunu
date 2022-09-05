using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uyarisimgesi : MonoBehaviour
{
    public GameObject uyarisimge;
    public float sec = 3f;
    bool uyari1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uyari1 == true)
        {
            uyarisimge.SetActive(true);
        }
        else
        {
            uyarisimge.SetActive(false);
        }
        if (dusman3.instance.mesafe < 400)
        {
            StartCoroutine(uyari(sec));
        }
        else
        {
            uyari1 = false;
        }
    }
    IEnumerator uyari(float seconds)
    {

        uyari1 = true;

        yield return new WaitForSeconds(seconds);

        uyari1 = false;
    }
}
