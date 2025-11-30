using UnityEngine;

public class CupMove : MonoBehaviour
{
    public float dropYPosition = 0f;
    public float dropDuration = 0.5f;

    private bool isDragging = false;
    private Camera mainCamera;
    private Vector3 offset;
    private float dropStartTime;
    private Vector3 dropStartPosition;
    private bool isDropping = false;
    private bool canStartDrag = true;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
        if (isDragging)
        {
            DragObject();
        }
        if (isDropping)
        {
            HandleDropAnimation();
        }
        if (transform.position.x > -0.1 && transform.position.x < 0.2)
        {
            if (transform.name == "Cup1")
            {
                GameManager.instance.isCup1Right = true;
            }
            else
            {
                GameManager.instance.isCup2Right = true;
            }

        }
        else
        {
            if (transform.name == "Cup1")
            {
                GameManager.instance.isCup1Right = false;
            }
            else
            {
                GameManager.instance.isCup2Right = false;
            }
        }
    }

    void HandleMouseClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            print("click.....");
            if (hit.collider.gameObject == this.gameObject)
            {
                if (!isDragging && !isDropping && canStartDrag)
                {
                    StartDragging();
                }
                else if (isDragging)
                {
                    StopDragging();
                }
            }
        }
    }

    void StartDragging()
    {
        isDragging = true;
        isDropping = false;
        canStartDrag = false;
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPos;
    }

    void DragObject()
    {
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        transform.position = mouseWorldPos + offset;
    }

    void StopDragging()
    {
        isDragging = false;

        if (transform.position.y > dropYPosition)
        {
            StartDropAnimation();
        }
        canStartDrag = true;
    }

    void StartDropAnimation()
    {
        isDropping = true;
        dropStartTime = Time.time;
        dropStartPosition = transform.position;
    }

    void HandleDropAnimation()
    {
        float elapsedTime = Time.time - dropStartTime;
        float progress = Mathf.Clamp01(elapsedTime / dropDuration);

        float easedProgress = 1f - Mathf.Pow(1f - progress, 3);

        float newY = Mathf.Lerp(dropStartPosition.y, dropYPosition, easedProgress);

        Vector3 newPosition = transform.position;
        newPosition.y = newY;
        transform.position = newPosition;

        if (progress >= 1f)
        {
            isDropping = false;
            canStartDrag = true;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }
}
