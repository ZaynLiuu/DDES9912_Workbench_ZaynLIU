using System.Collections;
using UnityEngine;

public class CoffeeL : MonoBehaviour
{
    Vector3 startPos, targetPos;
    public float moveDuration = 1f;
    public float waitTime = 1f;

    private void Awake()
    {
        startPos = transform.position;
        targetPos = new Vector3(startPos.x, -0.737f, startPos.z);
    }

    private void OnEnable()
    {
        StartCoroutine(Drop());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Drop()
    {
        while (true)
        {
            float timer = 0f;

            while (timer < moveDuration)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, targetPos, timer / moveDuration);
                yield return null;
            }

            transform.position = targetPos;

            yield return new WaitForSeconds(waitTime);

            transform.position = startPos;
        }
    }
}