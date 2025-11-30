using UnityEngine;

public class Steam : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform MilkCup;
    bool milkCupIsMove = false;
    public AudioSource aud;

    Vector3 targetPos;
    Vector3 startPos;
    void Start()
    {
        if (MilkCup) startPos = MilkCup.position;
        targetPos = new Vector3(0.814700007f, -0.526499987f, -0.44569999f);

        aud = GetComponent<AudioSource>();
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
                        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    }

                    if (MilkCup)
                    {
                        if (milkCupIsMove)
                        {
                            MilkCup.position = startPos;
                            milkCupIsMove = false;
                            aud.Stop();
                        }
                        else
                        {
                            MilkCup.position = targetPos;
                            milkCupIsMove = true;
                            aud.Play();
                        }
                    }
                }
            }
        }
    }
}
