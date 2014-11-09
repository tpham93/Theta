using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {
    Vector2 lastMousePosition;
	// Use this for initialization
    void Start()
    {
        lastMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}
	
	// Update is called once per frame
	void Update () {
        const float SPEED = 0.5f;
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * SPEED;
        if(Input.GetKey(KeyCode.R))
        {
            movement.y += SPEED;
        }
        if(Input.GetKey(KeyCode.F))
        {
            movement.y -= SPEED;
        }
        transform.position += movement.x * transform.right + movement.z * transform.forward + movement.y * transform.up;

        Vector2 deltaMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - lastMousePosition;
        this.transform.Rotate(new Vector3(1, 0, 0), -deltaMouse.y * 0.1f);
        this.transform.Rotate(new Vector3(0, 1, 0), deltaMouse.x * 0.1f);
        lastMousePosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
	}
}
