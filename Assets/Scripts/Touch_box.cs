using UnityEngine;
using System.Collections;

public class Touch_box : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name=="Player")
		{
			GameObject.Find("dark_sky").GetComponent<AreaEffector2D>().forceMagnitude = 50;

			Debug.Log("hit");
		}
	}
}