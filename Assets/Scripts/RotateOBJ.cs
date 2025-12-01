using System.Collections;
using UnityEngine;

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
    IEnumerator RotateTo(Quaternion targetRotation)
    {
        isRotating = true;
        Quaternion startRot = transform.rotation;
        float time = 0f;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRot, targetRotation, time / duration);
            time += Time.deltaTime;
            if (time>1&&selfAud.isPlaying==false)
            {
                selfAud.Play();
            }
            yield return null;
        }
        transform.rotation = targetRotation;
        yield return new WaitForSeconds(2);

        time = 0f;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(targetRotation, startRot, time / returnDelay);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = startRot;
        isRotating = false;

        coffee1.gameObject.SetActive(true);
        coffee2.gameObject.SetActive(true);
        GameManager.instance.isCoffeeDrop = true;
        if (GameManager.instance.isCoffeeDrop && GameManager.instance.isCup1Right)
        {
            aud.Play();
            yield return new WaitForSeconds(2);
            cup1.gameObject.SetActive(true);
        }
        if (GameManager.instance.isCoffeeDrop && GameManager.instance.isCup2Right)
        {
            aud.Play();
            yield return new WaitForSeconds(2);
            cup2.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(11);
        coffee1.gameObject.SetActive(false);
        coffee2.gameObject.SetActive(false);
        GameManager.instance.isCoffeeDrop = false;
    }
    public GameObject coffee1, coffee2;
    public AudioSource aud;
    public Transform cup1, cup2;

    public AudioSource selfAud;
}
