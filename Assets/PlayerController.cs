using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int ID1 = 1;
    private int ID2 = 1;
    public float speed = 1;
    private Vector3 position { get { return this.transform.position; } }
    private bool isJumping = false;
    private BlockScript currentBlock;

    // Use this for initialization
    void Start()
    {
        switch (ID1)
        {
            case 1:
                ID2 = MainMenu.KeysP1;
                break;
            case 2: 
                ID2 = MainMenu.KeysP2;
                break;
            case 3:
                ID2 = MainMenu.KeysP3;
                break;
            case 4:
                ID2 = MainMenu.KeysP4;
                break;
        }
    }

    void FixedUpdate()
    {
        float stepSize = speed * Time.deltaTime;


        if (0 < ID2 && ID2 < 7)
        {
            // move
            //if (Mathf.Abs(Input.GetAxis("Horizontal" + ID2))> 0.9f)
                this.gameObject.transform.position += Input.GetAxis("Horizontal" + ID2) * Vector3.right * stepSize;

            //if (Mathf.Abs(Input.GetAxis("Vertical" + ID2)) > 0.9f)
                this.gameObject.transform.position += Input.GetAxis("Vertical" + ID2) * Vector3.forward * stepSize;

            // don't fall over
            this.gameObject.rigidbody.MoveRotation(Quaternion.identity);

            // jump
            if (!isJumping && Input.GetAxis("Jump" + ID2) == 1)
            {
                this.gameObject.rigidbody.AddExplosionForce(800.0f, position + Vector3.down, 10.0f);
                isJumping = true;
                this.transform.parent = null;
                currentBlock = null;
            }
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
