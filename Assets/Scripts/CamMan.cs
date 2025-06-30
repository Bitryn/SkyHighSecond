using UnityEngine;

public class CamMan : MonoBehaviour
{
    Vector3 Pos = new Vector3(0,0,-10);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pos = new Vector3(GlobVar.instance.PlayerPos.x, GlobVar.instance.PlayerPos.y, -10);
        //transform.position = GlobVar.instance.PlayerPos;
        //transform.position.z = -10;
        transform.position = Pos;
    }
}
