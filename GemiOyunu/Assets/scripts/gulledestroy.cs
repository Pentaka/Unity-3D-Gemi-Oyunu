using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gulledestroy : MonoBehaviour
{
    public AudioClip ses;
    AudioSource audioSource;
    Transform carpma;
    public Transform carpmaefekt;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameObject.transform.position.y <= -17f)
        {
            Destroy(this.gameObject,3f);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dusman")
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+2f, transform.position.z);
            carpma = Instantiate(carpmaefekt, pos, Quaternion.identity);
            Destroy(this.gameObject,3f);
        }
    }
    IEnumerator carpisma()
    {
        yield return new WaitForSeconds(0f);

       



    }
}
