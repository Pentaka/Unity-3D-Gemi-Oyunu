using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varil : MonoBehaviour
{
    public Rigidbody rb;
    public Transform patlama,cikis;
    Transform klon;
    Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        transform.Rotate(0, 0, 90);
        anim.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -17f)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            anim.SetBool("inme", true);
        }
        StartCoroutine(yoket());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dusman")
        {
           
            klon = Instantiate(patlama, cikis.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    IEnumerator yoket()
    {
        yield return new WaitForSeconds(15.0f);
        Destroy(this.gameObject);
    }
}
