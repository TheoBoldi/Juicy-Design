using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject endCanvas;

    public GameObject projectile;
    public Transform shootPoint;
    public float shootCooldown;

    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shoot());
        StartCoroutine(Destroy());
    }

    void Update()
    {
        rb.velocity = -transform.up * speed;
    }

    public IEnumerator Shoot()
    {
       yield return new WaitForSeconds(shootCooldown);

        var tmp = Instantiate(projectile);
        tmp.transform.position = shootPoint.position;
        tmp.GetComponent<Rigidbody2D>().velocity = -tmp.GetComponent<Rigidbody2D>().velocity;
        tmp = null;

        StartCoroutine(Shoot());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(6f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Instantiate(endCanvas);
        }
    }
}
