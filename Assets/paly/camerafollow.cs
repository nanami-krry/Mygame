using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float XSmooth = 8;
    public float YSmooth = 8;
    public float XDistance = 2;
    public float YDistance = 2;
    public Vector2 MaxXandY;
    public Vector2 MinXandY;

    public Transform Hero;
    void Start()
    {
        Hero = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool MoveX()
    {
        if (Mathf.Abs(Hero.position.x - transform.position.x) > XDistance)
            return true;
        else
            return false;
    }

    bool MoveY()
    {
        if (Mathf.Abs(Hero.position.y - transform.position.y) > YDistance)
            return true;
        else
            return false;
    }

    void FollowHero()
    {
        float newX = transform.position.x;
        float newY = transform.position.y;
        if (MoveX())
            newX = Mathf.Lerp(transform.position.x, Hero.position.x,
                                XSmooth * Time.deltaTime);
        newX = Mathf.Clamp(newX, MinXandY.x, MaxXandY.x);

        if (MoveY())
            newY = Mathf.Lerp(transform.position.y, Hero.position.y,
                                YSmooth * Time.deltaTime);
        newY = Mathf.Clamp(newY, MinXandY.y, MaxXandY.y);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        FollowHero();
    }
}
