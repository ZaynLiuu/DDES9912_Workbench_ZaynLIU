using System.Collections;
using UnityEngine;

public class MoveOBJ : MonoBehaviour
{
    public GameObject button;
    Vector3 startPos;
    Vector3 targetPos;
    bool isMove = false;
    public float duration = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.localPosition;
        targetPos = new Vector3(1, startPos.y, startPos.z);
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
                if (hit.transform == transform)
                {
                    StartCoroutine(MoveTo());
                }
            }
        }
    }
    IEnumerator MoveTo()
    {
        if (isMove)
        {
            button.gameObject.SetActive(false);
            float time = 0f;
            while (time < duration)
            {
                transform.localPosition = Vector3.Lerp(targetPos, startPos, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            float time = 0f;
            while (time < duration)
            {
                transform.localPosition = Vector3.Lerp(startPos, targetPos, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            button.gameObject.SetActive(true);
        }
        isMove = !isMove;
    }
}
