using UnityEngine;
using System.Collections;

public class rope : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "bullet")
        {
            Destroy(gameObject.GetComponent<HingeJoint2D>());
            Destroy(this.gameObject);
            Destroy(GameObject.Find("box_10"));
        }
    }
}
