using UnityEngine;
using System.Collections;

public class gun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name=="Player")
        {
            GameObject.Find("bullet").GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
        }
    }
}
