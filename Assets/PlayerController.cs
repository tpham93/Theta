using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    private Vector3 position { get { return this.transform.position; } }
    private bool isJumping = false;
    private BlockScript currentBlock;

    // Use this for initialization
    void Start()
    {
    }

    void FixedUpdate()
    {
        float stepSize = speed * Time.deltaTime;

        // move
        this.gameObject.transform.position += Input.GetAxis("Horizontal") * Vector3.right * stepSize;
        this.gameObject.transform.position += Input.GetAxis("Vertical") * Vector3.forward * stepSize;

        // don't fall over
        this.gameObject.rigidbody.MoveRotation(Quaternion.identity);

        // jump
        if (!isJumping && Input.GetAxis("Jump") == 1)
        {
            this.gameObject.rigidbody.AddExplosionForce(800.0f, position + Vector3.down, 10.0f);
            isJumping = true;
            this.transform.parent = null;
            currentBlock = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnCollisionEnter(Collision collision)
    {
        BlockScript collidingBlock = collision.collider.GetComponent<BlockScript>();
        if(collidingBlock != null)
        {
            if(collidingBlock != currentBlock)
            {
                currentBlock = collidingBlock;
                this.transform.parent = currentBlock.transform;
            }
            if (isJumping && collision.collider.transform.position.y < position.y)
                isJumping = false;
        }
    }
}
