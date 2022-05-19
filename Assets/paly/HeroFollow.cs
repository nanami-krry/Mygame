using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform playerTran;
    [SerializeField]
    Vector3 offset = new Vector3(0, 1, 0);
    void Start()
    {
        playerTran = GameObject.Find("hero").transform;


    }
    void Update()
    {
        transform.position = playerTran.position + offset;
    }
}
