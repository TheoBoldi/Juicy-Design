using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject deathParticles;
    void Start()
    {
        GetComponentInChildren<Animator>().enabled = GameManager.instance.layerManager.isAnimActive;

        if (!GameManager.instance.layerManager.isParticleActive)
            GetComponentInChildren<ParticleSystem>().Stop();
        if (!GameManager.instance.layerManager.isTrailActive)
            GetComponentInChildren<TrailRenderer>().enabled = false;

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(GameManager.instance.layerManager.isParticleActive)
                Instantiate(deathParticles, collision.transform.position, Quaternion.identity, null);
            SoundManager.instance.Play("EnemyDeath");
            GameManager.instance.UpdateScore();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
