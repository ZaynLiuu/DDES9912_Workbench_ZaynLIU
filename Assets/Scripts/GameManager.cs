using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isCup1Right = false;
    public bool isCup2Right = false;
    public bool isCoffeeDrop = false;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
