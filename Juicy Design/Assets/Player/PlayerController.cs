using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Shoot")]
    public GameObject projectile;
    public Transform shootPoint;

    [Header("Movement")]
    public GameObject listParent;
    public List<Transform> playerPosList;
    private int actualPos;
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        actualPos = 2;

        for(int i = 0; i < listParent.transform.childCount; i++)
        {
            playerPosList.Add(listParent.transform.GetChild(i));
        }
    }

    void Update()
    {
        if(actualPos > 0 && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            actualPos--;
            rb.AddForce(-transform.right * speed, ForceMode2D.Force);

        }

        if (actualPos < playerPosList.Count - 1 && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            actualPos++;
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.Shoot();
            var tmp = Instantiate(projectile);
            tmp.transform.position = shootPoint.position;
            tmp = null;
        }
    }
}
