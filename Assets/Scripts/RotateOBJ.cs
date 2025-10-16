using UnityEngine;

public class RotateOBJ : MonoBehaviour
{
    public Vector3 rotationAngle = new Vector3(0,90,0);
    public Vector3 startAngle ;
    public float time=1f;
    bool isOriginalRotation =true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startAngle=transform.rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                Vector3 angel =isOriginalRotation?rotationAngle:
            }
        }
    }
}
