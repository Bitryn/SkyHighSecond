using UnityEngine;
using System.Collections;
public class Pointer : MonoBehaviour
{
    private Rigidbody2D rb;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log(GlobVar.instance.score);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -1.0f* GlobVar.instance.MouseAngle);
        transform.position = GlobVar.instance.PlayerPos;
        //rotation.z = GlobVar.instance.MouseAngle;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            GlobVar.instance.PointerFree = false;
            Debug.Log("JUMP not");
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            GlobVar.instance.PointerFree = true;
            Debug.Log("JUMP yessss");
        }
    }




}
