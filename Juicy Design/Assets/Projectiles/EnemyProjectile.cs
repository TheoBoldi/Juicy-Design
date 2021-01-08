using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.right * speed;
        GetComponentInChildren<Animator>().enabled = GameManager.instance.layerManager.isAnimActive;
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameManager.instance.layerManager.isCameraActive)
                EZCameraShake.CameraShaker.Instance.ShakeOnce(10, 2, 0.05f, 0.2f);
            GameManager.instance.DecreaseLife();
            Destroy(this.gameObject);
        }
    }
}
