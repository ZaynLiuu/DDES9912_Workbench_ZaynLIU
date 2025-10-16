using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RotateOBJ : MonoBehaviour
{
    public Vector3 rotationAngle = new Vector3(-75, 0, 0);
    public Vector3 startAngle;
    public float duration = 1f;
    public float returnDelay = 4f;
    bool isRotating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("click!!!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject.name);
                if (hit.transform == transform && !isRotating)
                {
                    Quaternion targetRotation = Quaternion.Euler(rotationAngle);
                    StartCoroutine(RotateTo(targetRotation));
                }

            }
            else
            {
                print("null!!!");
            }
        }
    }
    public ParticleSystem ps1, ps2;
    IEnumerator RotateTo(Quaternion targetRotation)
    {
        isRotating = true;
        Quaternion startRot = transform.rotation;
        float time = 0f;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        yield return new WaitForSeconds(2);
        ps1.Play();
        ps2.Play();
        time = 0f;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(targetRotation, startRot, time / returnDelay);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = startRot;
        isRotating=false;
        ps1.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        ps2.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
