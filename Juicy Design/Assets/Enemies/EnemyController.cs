using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Shoot")]
    public GameObject projectile;
    public Transform shootPoint;
    public float shootCooldown;
    private bool canShoot = false;
    [Header("Movement")]
    public float speed;
    private Rigidbody rb;

    private Animator _anim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(CheckFront());
        StartCoroutine(TryShoot());
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    public IEnumerator CheckFront()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            if (hit.collider.tag == "Enemy")
                canShoot = false;
            else
                canShoot = true;
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(CheckFront());
    }

    public IEnumerator TryShoot()
    {
        if(canShoot)
        _anim.SetTrigger("Shoot");
        yield return new WaitForSeconds(shootCooldown);
        StartCoroutine(TryShoot());
    }

    public void Shoot()
    {
        var tmp = Instantiate(projectile);
        tmp.transform.position = shootPoint.position;
        tmp.GetComponent<Rigidbody>().velocity = -tmp.GetComponent<Rigidbody>().velocity;
        tmp = null;
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
