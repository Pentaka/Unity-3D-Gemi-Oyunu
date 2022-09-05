using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class dusman : MonoBehaviour
{
    public static dusman instance;
    NavMeshAgent agent;
    private Transform Target, Target1,Targetgemi,Targetsol,Targetsag;
    public float mesafe,mesafe1,mesafe2,mesafe3,gemimesafe;
    public float can=250f;
    public float maxcan;
    public Slider canbari;
    public GameObject dusman1;
    public GameObject ates1, ates2, ates3, ates4, ates5;

    public GameObject[] points;
    int current;
    bool patrol;

    float guntimer;
    public float guncooldown;
    public Transform gulle, cikis;
    public Transform[] top;
    Transform klon,klon1,klonmadal;
    public Transform duman;

    Animator anim;

   public bool solates,sagates;
    public bool bar = false;
    bool canartis;

    AudioSource audioSource;
    public AudioClip ses;
    public AudioClip ses1;

    public Transform madalya;
    bool madalyaspawn;
    public float y;
    public float x;

    public bool dead;

    Transform pos;

    public GameObject uyarisimge;

    float madalyatimer;
    float madalyacooldown = 100f;

    GameObject sagkup;
    GameObject solkup;

    public void Start()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.Find("sag").transform;
        Target1 = GameObject.Find("sol").transform;
        Targetgemi = GameObject.Find("Player").transform;
        sagkup = dusman1.transform.GetChild(1).gameObject;
        solkup = dusman1.transform.GetChild(0).gameObject;
        dusman1 = this.gameObject;

    
        current = 0;
        agent.autoBraking = false;
        solates = false;
        sagates = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        y = 0;
        maxcan = can;
        return;

    }
    

   public void Update()
    {
        Targetsol = solkup.transform;
        Targetsag = sagkup.transform;

        if (gemi.instance.toplam == 5)
        {
            if (!bar)
            {

                canbari.maxValue = 500;
                can = 500;
                bar = true;
                bar = false;
            }
        }
         if (gemi.instance.toplam == 10)
        {
            if (!bar)
            {

                canbari.maxValue = 600;
                can = 600;
                bar = true;
                bar = false;
            }
        }
        else if (gemi.instance.toplam == 15)
        {
            if (!bar)
            {

                canbari.maxValue = 700;
                can = 700;
                bar = true;
                bar = false;
            }
        }
        else if (gemi.instance.toplam == 20)
        {
            if (!bar)
            {

                canbari.maxValue = 800;
                can = 800;
                bar = true;
                bar = false;
            }
        }
        else if (gemi.instance.toplam == 25)
        {
            if (!bar)
            {

                canbari.maxValue = 1000;
                can = 1000;
                bar = true;
                bar = false;
            }
        }
        

        y = gemi.instance.b;
        mesafe = Vector3.Distance(transform.position, Target.position);
        mesafe1 = Vector3.Distance(transform.position, Target1.position);
        mesafe2 = Vector3.Distance(Targetsol.transform.position, Targetgemi.position);
        mesafe3 = Vector3.Distance(Targetsag.transform.position, Targetgemi.position);
        gemimesafe = Vector3.Distance(transform.position, Targetgemi.position);

        canbari.value = can;
        if (canartis == true)
        {

            canartis = false;
        }

        if (dead == true)
        {
            canbari.gameObject.SetActive(false);
            anim.SetBool("batma", true);
            madalyaspawn = true;
            Destroy(this.gameObject, 8f);
            agent.enabled = false;
            sagates = false;
            solates = false;
            

        }
        if (can <= 0)
        {
            dead = true;
            sagates = false;
            solates = false;
        }

        else
        {

            if (mesafe < 500 && mesafe < mesafe1)
            {

                agent.destination = Target.transform.position;
                patrol = false;
                if (gemimesafe <= 50 && mesafe3 > mesafe2)
                {
                    solates = false;
                    sagates = true;
                    ates();
                }
                else if (gemimesafe <= 50 && mesafe3 < mesafe2)
                {
                    sagates = false;
                    solates = true;
                    ates();
                }

            }
            else if (mesafe < 500 && mesafe > mesafe1)
            {

                agent.destination = Target1.transform.position;
                patrol = false;
                if (gemimesafe <= 65 && mesafe3 < mesafe2)
                {
                    sagates = false;
                    solates = true;
                    ates();
                }
                else if (gemimesafe <= 65 && mesafe3 > mesafe2)
                {
                    sagates = true;
                    solates = false;
                    ates();
                }


            }
            else if (mesafe == 500 && mesafe > mesafe1)
            {

                agent.destination = Target1.transform.position;
                patrol = false;
                if (gemimesafe <= 65 && mesafe3 < mesafe2)
                {
                    sagates = true;
                    solates = false;
                    ates();
                }
                else if (gemimesafe <= 65 && mesafe3 > mesafe2)
                {
                    sagates = false;
                    solates = true;
                    ates();
                }

            }
            else
            {
                patrol = true;
                sagates = false;
                solates = false;

            }
            if (patrol == true)
            {
                if (!agent.pathPending && agent.remainingDistance < 20f)
                {

                    GotoNextPoint();
                }
            }
        }
        
        if (can <= 200)
        {
            ates1.SetActive(true);
        }
        if (can <= 150)
        {
            ates2.SetActive(true);
        }
        if (can <= 120)
        {
            ates3.SetActive(true);
        }
        if (can <= 80)
        {
            ates4.SetActive(true);
        }
        if (can <= 40)
        {
            ates5.SetActive(true);
        }
        if (madalyaspawn == true)
        {
            if (Time.time > madalyatimer)
            {
                madalyatimer = Time.time + madalyacooldown;
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z);
                klonmadal = Instantiate(madalya, pos, Quaternion.identity);
                madalyaspawn = false;
            }
        }
        if (sagates == false && solates == false)
        {
            if (mesafe < 500 && mesafe > 90)
            {
                uyarisimge.SetActive(true);

            }
        }
        else 
        {
            uyarisimge.SetActive(false);
        }
       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mayin")
        {
            audioSource.PlayOneShot(ses);
            GetDamage(10);
        }
        if (other.gameObject.tag == "gullee")
        {
            GetDamage(10 + y + dusman3.instance.y +dusman2.instance.y);
            Debug.Log(can);
        }


    }
    public void GetDamage(float amount)
    {
        can -= amount;
    }
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[current].transform.position;


        current = (current + 1) % points.Length;
    }
    void ates()
    {
        if (solates == true)
        {
            sagates = false;
            if (Time.time > guntimer)
            {
                audioSource.PlayOneShot(ses1);
                for (int i = 0; i <= 7; i++)
                {

                    guntimer = Time.time + guncooldown;
                    StartCoroutine(firlat(i));
                }
            }
        }
        else if (sagates == true)
        {
            solates = false;
            if (Time.time > guntimer)
            {
                audioSource.PlayOneShot(ses1);
                for (int i = 8; i <= 15; i++)
                {

                    guntimer = Time.time + guncooldown;
                    StartCoroutine(firlat1(i));
                }
            }
        }
    }
    IEnumerator firlat(int deger)
    {
        float zaman = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(zaman);
        
        klon = Instantiate(gulle, top[deger].position, Quaternion.identity);
        klon1 = Instantiate(duman, top[deger].position, Quaternion.identity);
        klon1.transform.parent = dusman1.transform;
        klon.GetComponent<Rigidbody>().velocity = top[deger].right * 100;

    }
    IEnumerator firlat1(int deger)
    {
        float zaman = Random.Range(0.1f, 0.2f);

        yield return new WaitForSeconds(zaman);
        
        klon = Instantiate(gulle, top[deger].position, Quaternion.identity);
        klon1 = Instantiate(duman, top[deger].position, Quaternion.identity);
        klon1.transform.parent = dusman1.transform;
        klon.GetComponent<Rigidbody>().velocity = top[deger].right * -100;

    }
}

