using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode crouch;

    float jumpPower = 20f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var velocity = GetComponent<Rigidbody2D>().velocity;
        var rbComponent = GetComponent<Rigidbody2D>();


        if (Input.GetKey(left))
        {
            velocity = new Vector2(-10, velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            print("moving left");
        }

        else if (Input.GetKey(right))
        {
            velocity = new Vector3(10, velocity.y);
            transform.rotation = Quaternion.identity;
            print("moving right");
        }

        else
        {
            velocity = new Vector3(0, velocity.y);
        }


        if (Input.GetKeyDown(jump))
        {
            if (IsGrounded())
            {
                velocity = new Vector3(velocity.x, jumpPower);
            }

            print("jumping");
        }

        rbComponent.velocity = velocity;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}
