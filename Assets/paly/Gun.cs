using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rocket;
    public float speed = 20f;
    palycontral  playerCtrl;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = transform.root.GetComponent<palycontral>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerCtrl.bFaceRight)
            {
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 0));
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(speed, 0);
            }
            else
            {
                GameObject bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 180));
                Rigidbody2D bi = bulletInstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-speed, 0);
                //Rigidbody2D bi = bulletInstance as Rigidbody2D;
            }
        }

    }
}
