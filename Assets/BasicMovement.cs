using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        const float SPEED = 0.5f;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * SPEED;
        transform.position += movement.x * transform.right + movement.y * transform.forward;
	}
}
