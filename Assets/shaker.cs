using UnityEngine;
using System.Collections;

public class shaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position += new Vector3(Mathf.Sin(Time.time * 20) / 5, 0, 0);
	}
}
