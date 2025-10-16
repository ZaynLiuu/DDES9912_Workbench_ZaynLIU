using UnityEngine;

public class Steam : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject.name);
                if (hit.transform == transform)
                {
                    if (!ps.isPlaying)
                    {
                        ps.Play();
                    }
                    else
                    {
                        ps.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
                    }
                }

            }
        }
    }
}
