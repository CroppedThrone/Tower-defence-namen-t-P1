using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public float birdSpeed;
    public float birdLevel;
    public Vector3 move;
    public bool dumbBird;

    public Vector3 positionBird;

    // Start is called before the first frame update
    void Start()
    {
        positionBird.y = transform.position.y;
        positionBird.z = transform.position.z;
        positionBird.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(move * birdSpeed * Time.deltaTime);
        move.y = birdLevel;

        if (dumbBird == true)
        {
            if (transform.position.y >= 9)
            {
                birdLevel = -0.625f;
            }
            if (transform.position.y <= 7.5f)
            {
                birdLevel = 0.5f;
            }
        }


        if(transform.position.y >= )
        {

        }
    }
}
