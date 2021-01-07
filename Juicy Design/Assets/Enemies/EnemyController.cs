using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Shoot")]
    public GameObject projectile;
    public Transform shootPoint;
    public float shootCooldown;

    [Header("Movement")]
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Shoot());
    }

    void Update()
    {
        rb.velocity = -transform.right * speed;
    }

    public IEnumerator Shoot()
    {
       yield return new WaitForSeconds(shootCooldown);

        var tmp = Instantiate(projectile);
        tmp.transform.position = shootPoint.position;
        tmp.GetComponent<Rigidbody>().velocity = -tmp.GetComponent<Rigidbody>().velocity;
        tmp = null;

        StartCoroutine(Shoot());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.DecreaseLife();
            Destroy(this.gameObject);
        }
    }
}
