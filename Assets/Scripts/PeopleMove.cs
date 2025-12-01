using System.Collections;
using UnityEngine;

public class PeopleMove : MonoBehaviour
{
    public float speed = 5;
    public GameObject cup1, cup2;
    bool ismove;
    Collider ccc;
    void Start()
    {
        ccc = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!cup1.activeInHierarchy && !cup2.activeInHierarchy && !ismove)
        {
            ismove = true;
            transform.Rotate(new Vector3(0, 180, 0));
            Invoke("Dis", 5);
        }

        if (ismove)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

    void Dis()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "c111")
        {
            cup1.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        else if (other.name == "c222")
        {
            cup2.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }

}
