using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    public float parallaxFactor = 0.1f;
    public float framesParllaxFactor = 0.3f;
    public float smoothX = 4;
    public Transform[] backgrounds;

    private Transform cam;
    private Vector3 camPrePos;



    private void Awake()
    {
        cam = Camera.main.transform;

    }

    void Start()
    {
        camPrePos = cam.position;
    }

    void bkParallax()
    {
        float fparallax = (camPrePos.x - cam.position.x) * parallaxFactor;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float bkNewX = backgrounds[i].position.x + fparallax * (1 +
                                                    i * framesParllaxFactor);
            Vector3 bkNewPos = new Vector3(bkNewX, backgrounds[i].position.y,
                                            backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bkNewPos,
                                                    Time.deltaTime * smoothX);
        }
        camPrePos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
