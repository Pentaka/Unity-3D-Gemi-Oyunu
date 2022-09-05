using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gemi : MonoBehaviour
{
    public static gemi instance;
    dusman3  dusman3;
    int hiz = 4;
    public GameObject Arkacamera;
    public GameObject Maincamera;
    public GameObject solcamera;
    public GameObject sagcamera;

    public GameObject panel3,buton,text1,text2;

    public Transform gulle, cikis;
    public Transform[] top;
    Transform klon,klon1;
    float guntimer,guntimer1;
    public float guncooldown;

    public float can=300f;
    public float maxcan;
    public Slider canbari;

    GameObject anagemi;
    public Transform duman;

   public int altin, gumus, bronz;
    public int toplam = 0;
    public float a = 0, g = 0, b = 0;
    float x = 0, y = 0, z = 0;
  
    public TextMeshProUGUI altinpuan, gumuspuan, bronzpuan;
    bool altinbool, gumusbool, bronzbool;

    public Image image;
    public GameObject panel2;
    GameObject gemi1;

    Animator anim;
    Animator anim1;


    public AudioClip ses;
    AudioSource audioSource;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        anagemi = GameObject.Find("gemi prefab");
        instance = this;
        dusman3 = GameObject.Find("dusmangemi3").GetComponent<dusman3>();
        maxcan = can;
        gemi1= this.gameObject.transform.GetChild(0).gameObject;
        image = image.GetComponent<Image>();
        anim = image.GetComponent<Animator>();
        anim1 = gemi1.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

       


    }
    
    public void Update()
    {
        if (can<=0)
        {
            anim1.SetBool("dead",true);
            StartCoroutine(dead());
        }
        

        
        if (altin == 5 || gumus == 5 || bronz == 5)
        {
            x = 1f;
            y = 1.5f;
            z = 0.75f;
        }
        else if (altin == 10 || gumus == 10 || bronz == 10)
        {
            x = 2f;
            y = 3f;
            z = 1.5f;
        }
        else if (altin == 15 || gumus == 15 || bronz == 15)
        {
            x = 3f;
            y = 4.5f;
            z = 2f;
        }
        else if (altin == 20 || gumus == 20 || bronz == 20)
        {
            x = 4f;
            y = 6f;
            z = 2.5f;
        }

        toplam = altin + gumus/2 + bronz/4;
        Debug.Log(toplam);
       
        canbari.value = can;
        
        hareket();
        kamera();
        ates();

        altinpuan.text = "X" + altin;
        gumuspuan.text = "X" + gumus;
        bronzpuan.text = "X" + bronz;

        if (altinbool == true)
        {
            altin++;
            a += 0.25f;
            can += 200;
            canbari.maxValue += 20;
            maxcan += 20;
           
            
            altinbool = false;
        }

        if (gumusbool == true)
        {
            gumus++;
            g += 1f;
            can += 250;
            canbari.maxValue += 30;
            maxcan += 30;
            gumusbool = false;
        }

        if (bronzbool == true)
        {
            bronz++;
            b += 0.4f;
            can += 150;
            canbari.maxValue += 10;
            maxcan += 10;
            bronzbool = false;
        }
        if (can > maxcan)
        {
            can = maxcan;
        }
    }
    void hareket()
    {
        float ileri = Input.GetAxis("Vertical") * hiz * Time.deltaTime;
        float don = Input.GetAxis("Horizontal") * hiz * Time.deltaTime;

        transform.Translate(0, 0, ileri);
        transform.Rotate(0, don, 0);

        
    }

    

        void kamera()
    {

        if (Input.GetKey(KeyCode.R))
        {
            Arkacamera.SetActive(true);
            Maincamera.SetActive(false);
            sagcamera.SetActive(false);
            solcamera.SetActive(false);

           
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            Arkacamera.SetActive(false);
            Maincamera.SetActive(false);
            sagcamera.SetActive(false);
            solcamera.SetActive(true);
            
            
        
        }
       
        if (Input.GetKey(KeyCode.E))
        {
            Arkacamera.SetActive(false);
            Maincamera.SetActive(false);
            sagcamera.SetActive(true);
            solcamera.SetActive(false);

           
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Arkacamera.SetActive(false);
            Maincamera.SetActive(true);
            sagcamera.SetActive(false);
            solcamera.SetActive(false);


        }

       

    }
    IEnumerator firlat(int deger)
    {
        float zaman = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(zaman);

        klon = Instantiate(gulle, top[deger].position, Quaternion.identity);
        klon1 = Instantiate(duman, top[deger].position, Quaternion.identity);
        klon1.transform.parent = anagemi.transform;
        klon.GetComponent<Rigidbody>().velocity = top[deger].right * -50;
        

    }
    IEnumerator firlat1(int deger)
    {
        float zaman = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(zaman);

        klon = Instantiate(gulle, top[deger].position, Quaternion.identity);
        klon1 = Instantiate(duman, top[deger].position, Quaternion.identity);
        klon1.transform.parent = anagemi.transform;
        klon.GetComponent<Rigidbody>().velocity = top[deger].right * 50;
        

    }
    void ates()
    {
        if (solcamera.activeInHierarchy == true)
        {

            if (Input.GetKey(KeyCode.F))
            {

                if (Time.time > guntimer)
                {
                    audioSource.PlayOneShot(ses);

                    for (int i = 0; i <= 7; i++)
                    {

                        guntimer = Time.time + guncooldown;
                        StartCoroutine(firlat(i));
                        dusman3.instance.dead2 = true;
                    }


                }
            }
        }
        else if (sagcamera.activeInHierarchy == true)
        {

            if (Input.GetKey(KeyCode.F))
            {

                if (Time.time > guntimer)
                {

                    audioSource.PlayOneShot(ses);
                    for (int i = 8; i <= 15; i++)
                    {

                        guntimer = Time.time + guncooldown;
                        StartCoroutine(firlat1(i));
                        dusman3.instance.dead2 = true;
                    }
                }

            }


        }  
        
    }
    public void GetDamage(float amount)
    {
        can -= amount;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "dusmangulle1")
        {
       
            GetDamage(7+y);


            anim.SetBool("basla", true);
            StartCoroutine(hasar());
                


        }
        if (other.gameObject.tag == "dusmangulle2")
        {

            GetDamage(5+z);


            anim.SetBool("basla", true);
            StartCoroutine(hasar());
            


        }
        if (other.gameObject.tag == "dusmangulle3")
        {

            GetDamage(6+x);


            anim.SetBool("basla", true);
            StartCoroutine(hasar());
            


        }
        if (other.gameObject.tag == "altin")
        {
            altinbool = true;
        }
        if (other.gameObject.tag == "gumus")
        {
            gumusbool = true;
        }
        if (other.gameObject.tag == "bronz")
        {
            bronzbool = true;
        }
        if (other.gameObject.tag == "kaya")
        {
            GetDamage(30);
        }
    }
    IEnumerator slow()
    {

        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 1f;
        

    }
    IEnumerator hasar()
    {

        anim.SetBool("kapali", false);
        anim.SetBool("acik",true);
        
        yield return new WaitForSeconds(2f);
        anim.SetBool("kapali", true);
        anim.SetBool("acik", false);






    }
    IEnumerator dead()
    {

       
        yield return new WaitForSeconds(15f);
        panel3.SetActive(true);
        buton.SetActive(false);
        text1.SetActive(false);
        text2.SetActive(true);





        
    }
}
