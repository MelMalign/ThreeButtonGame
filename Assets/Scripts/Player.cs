using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    public float jumpHeight = 1.0f;

    public bool hasKey = false;

    private Rigidbody rb;
    SphereCollider collider;
    float distToGround;

    [SerializeField]
    private Text winText;


    // Start is called before the first frame update
    void Start()
    {
        //Get Rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<SphereCollider>();
        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        //Move
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        rb.position += (move * Time.deltaTime * playerSpeed);

        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

    }


   private bool IsGrounded()
   {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
   }


private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Key key = collision.gameObject.GetComponent<Key>();
            hasKey = true;
            Debug.Log("Picked up Key");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Door" && hasKey)
        {
            //WinCondition
            Debug.Log("You Win!");
            winText.text = "You Win!";

        }
    }
}
