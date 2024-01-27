using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallAlphaTop : MonoBehaviour
{
    private Tilemap tilemap;
    private Tilemap bottom_tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        GameObject parent = transform.parent.gameObject;
        bottom_tilemap = parent.transform.GetChild(1).GetComponent<Tilemap>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("is_below");
            tilemap.color += new Color (0, 0, 0, -0.5f);
            bottom_tilemap.color += new Color (0, 0, 0, -0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("is_away");
            tilemap.color += new Color (0, 0, 0, 0.5f);
            bottom_tilemap.color += new Color (0, 0, 0, 0.5f);
        }
    }
}
