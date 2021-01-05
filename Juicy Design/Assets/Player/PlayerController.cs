using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootPoint;
    public GameObject listParent;
    public List<Transform> playerPosList;
    private int actualPos;

    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        actualPos = 1;

        for(int i = 0; i < listParent.transform.childCount; i++)
        {
            playerPosList.Add(listParent.transform.GetChild(i));
        }
    }

    void Update()
    {
        //float playerPos = Input.GetAxisRaw("Horizontal");

        if(actualPos > 0 && Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q))
        {
            //this.transform.position = playerPosList[actualPos - 1].position;
            actualPos--;
            rb.AddForce(-transform.right * speed, ForceMode2D.Force);

        }

        if (actualPos < playerPosList.Count - 1 && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //this.transform.position = playerPosList[actualPos + 1].position;
            actualPos++;
            rb.AddForce(transform.right * speed, ForceMode2D.Force);
        }

        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed, ForceMode2D.Force);*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var tmp = Instantiate(projectile);
            tmp.transform.position = shootPoint.position;
            tmp = null;
        }
    }
}
