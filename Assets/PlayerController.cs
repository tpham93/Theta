using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    private Vector3 position { get { return this.transform.position; } }
    private bool isJumping = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float stepSize = speed * Time.deltaTime;
        
        // move
        this.gameObject.transform.position += Input.GetAxis("Horizontal") * Vector3.right * stepSize;
        this.gameObject.transform.position += Input.GetAxis("Vertical") * Vector3.forward * stepSize;
        
        // don't fall over
        this.gameObject.rigidbody.MoveRotation(Quaternion.identity);
        
        // jump
        if(!isJumping && Input.GetAxis("Jump") == 1)
        {
            this.gameObject.rigidbody.AddExplosionForce(800.0f, position + Vector3.down, 10.0f);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(isJumping && collision.collider.name == "Block" && collision.collider.transform.position.y < position.y)
            isJumping = false;
    }

}
