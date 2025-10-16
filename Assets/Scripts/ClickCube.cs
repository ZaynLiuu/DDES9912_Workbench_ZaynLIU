using UnityEngine;

public class ClickCube : MonoBehaviour
{
    public GameObject coffee;
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
                if (hit.transform == transform)
                {
                    coffee.gameObject.SetActive(true);
                }
            }
        }
    }
}
