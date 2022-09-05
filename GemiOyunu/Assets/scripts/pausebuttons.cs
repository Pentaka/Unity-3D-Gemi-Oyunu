using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausebuttons : MonoBehaviour
{
    public GameObject panel;
    public GameObject btn;
    public GameObject eminpanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void devam()
    {
        panel.SetActive(false);
        AudioListener.volume = 1;

    }
    public void anamenu()
    {
        eminpanel.SetActive(true);
        
    }
    public void cikis()
    {
        Application.Quit();
    }
    public void hayir()
    {
        eminpanel.SetActive(false);
    }
    public void girismenu()
    {
        SceneManager.LoadScene("Giris");
    }
}
