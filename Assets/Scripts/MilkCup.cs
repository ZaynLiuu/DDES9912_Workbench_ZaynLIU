using UnityEngine;

public class MilkCup : MonoBehaviour
{
    public Vector3 targetPos;
    Vector3 startPos;
    bool isMove=false;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
