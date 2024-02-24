using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10;
    public float jampPower = 5;

    public LayerMask groundLayer;

    public Vector2 boxSize;
    public float distance;
    private int jampkount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y) ;

        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded() || jampkount <2))
           
        {
            rb.velocity = Vector2.zero;
            jampkount = jampkount + 1; 
            rb.AddForce(Vector2.up * jampPower, ForceMode2D.Impulse);
        }
    }

    // ???????? ?? ??????
    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, distance, groundLayer))
        {
            jampkount = 0;
            // ??
            return true;
        }
        else
        {
            // ???
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * distance, boxSize);

    }
}
