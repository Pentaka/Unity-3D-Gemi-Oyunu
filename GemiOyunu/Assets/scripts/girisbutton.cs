using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class girisbutton : MonoBehaviour
{
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cikis()
    {
        Application.Quit();
    }
    public void play()
    {
        SceneManager.LoadScene("bitirme_2");
    }
}
