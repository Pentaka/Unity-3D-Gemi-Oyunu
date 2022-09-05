using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2, buton, text1,text2;
    bool pause;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf == true || panel2.activeSelf == true)
        {
            pause = true;
        }
        else if (panel.activeSelf == false && panel2.activeSelf == false)
        {
            pause = false;
        }
        StartCoroutine(yukleme());


        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel2.activeSelf == false)
            {
                text1.SetActive(true);
                text2.SetActive(false);
                panel2.SetActive(true);
                buton.SetActive(true);
                AudioListener.volume = 0;
            }
            else
            {
                panel2.SetActive(false);
                AudioListener.volume = 1;
            }
        }

       
        if (pause == true)
        {
            Time.timeScale = 0f;
        }
        else if (pause == false)
        {
            Time.timeScale = 1f;
        }
    }

      
        

   
    IEnumerator yukleme()
    {
        if (panel2.activeSelf == true)
        {
            

            yield return new WaitForSeconds(4f);
            panel2.SetActive(false);
        }
    }
    
}
