using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GlobVar.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -1.0f* GlobVar.instance.MouseAngle);
        transform.position = GlobVar.instance.PlayerPos;
        //rotation.z = GlobVar.instance.MouseAngle;
    }
}
