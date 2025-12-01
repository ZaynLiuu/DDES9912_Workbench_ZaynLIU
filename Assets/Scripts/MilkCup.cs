using System.Collections;
using UnityEngine;

public class MilkCup : MonoBehaviour
{
    public Transform cup1, cup2;
    float timer;
    public AudioSource aud;
    public Material material;
    bool cup1OK, cup2OK;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == cup1.name || other.name == cup2.name)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                if (other.name == cup1.name && !cup1OK)
                {
                    aud.Play();
                    cup1OK = true;
                    StartCoroutine(Wait(cup1));
                }
                else if (other.name == cup2.name && !cup2OK)
                {
                    aud.Play();
                    cup2OK = true;
                    StartCoroutine(Wait(cup2));
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == cup1.name || other.name == cup2.name)
            timer = 0;
    }
    IEnumerator Wait(Transform t)
    {
        yield return new WaitForSeconds(aud.clip.length);
        t.GetComponent<MeshRenderer>().material = material;
        bc.enabled= true;
    }
    public BoxCollider bc;
}
