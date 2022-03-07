using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class PlaceBananaDucks : MonoBehaviour {

    public BoxCollider2D waterArea;

    private void Start()
    {
        placeDuck();
    }

    private void placeDuck() 
    {
        Bounds bounds = this.waterArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            placeDuck();    
        }
        
    }

}
