using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shoot")]
    public GameObject projectile;
    public Transform shootPoint;
    public float shootCooldown = .5f;  
    [Header("Movement")]
    public GameObject listParent;
    public List<Transform> playerPosList;
    private int actualPos;
    public float speed;
    private Rigidbody rb;

    private Animator anim;
    private bool switchShootAnim;
    private bool canShoot = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        actualPos = 2;
        switchShootAnim = false;

        for(int i = 0; i < listParent.transform.childCount; i++)
        {
            playerPosList.Add(listParent.transform.GetChild(i));
        }
    }

    void Update()
    {
        if(actualPos > 0 && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q)))
        {
            actualPos--;
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            anim.SetTrigger("MoveLeft");
            //rb.position = Vector3.Lerp(this.transform.position, playerPosList[actualPos].position, speed * Time.deltaTime); 
            //rb.MovePosition(playerPosList[actualPos].position);
        }

        if (actualPos < playerPosList.Count - 1 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            actualPos++;
            rb.AddForce(-transform.forward * speed, ForceMode.Impulse);
            anim.SetTrigger("MoveRight");
            //rb.position = Vector3.Lerp(this.transform.position, playerPosList[actualPos].position, speed * Time.deltaTime);
            //rb.MovePosition(playerPosList[actualPos].position);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            if (!switchShootAnim)
            {
                anim.SetTrigger("Shoot");
                switchShootAnim = true;
            }
            else
            {
                anim.SetTrigger("Shoot2");
                switchShootAnim = false;
            }
            canShoot = false;
            StartCoroutine(ResetShoot());
        }
    }

    public void Shoot()
    {
        SoundManager.instance.Play("PlayerShoot");
        var tmp = Instantiate(projectile);
        tmp.transform.position = shootPoint.position;
        tmp = null;
    }

    public IEnumerator ResetShoot()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
