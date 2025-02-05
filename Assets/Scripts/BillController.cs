using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BillController : MonoBehaviour
{
    public float launchForce = 10f;
    public float fallSpeed = 2f;
    public float upgradeIndicatorY = 5f;


    private Rigidbody2D rb;
    private bool isFalling = false;

    Renderer bill; 


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bill = GetComponent<Renderer>();
    }


    public void Launch()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-0.5f, 0.5f), 1).normalized;
        rb.AddForce(randomDirection * launchForce, ForceMode2D.Impulse);
        rb.angularVelocity = Random.Range(-00f, 200f);
    }


    private void Update()
    {
        if (!isFalling && transform.position.y >= upgradeIndicatorY)
        {
            isFalling = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
        }

        if (isFalling)
        {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime); 
        }

        if (!bill.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
