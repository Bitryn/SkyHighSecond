using UnityEngine;

public class GlobVar : MonoBehaviour
{
    public static GlobVar instance;

    public float score = 102.0f;
    public Vector2 PlayerPos = new Vector2(0,0);
    public bool PointerFree = true; // is pointer blocked by the wall
    public float MouseAngle = 0f;
    private void Awake()
    {
        if (instance == null){  instance = this;  }
        else Destroy(gameObject);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
