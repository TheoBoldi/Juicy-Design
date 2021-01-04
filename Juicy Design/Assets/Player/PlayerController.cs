using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPoint;

    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed, ForceMode2D.Force);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var tmp = Instantiate(projectile);
            tmp.transform.position = shootPoint.position;
            tmp = null;
        }
    }
}
