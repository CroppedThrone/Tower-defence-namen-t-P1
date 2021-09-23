using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdscript : MonoBehaviour
{
    public float birdSpeed;
    public Vector3 birdLevel;
    public Vector3 move;
    public bool dumbBird;

    public bool smartBird;
    public Vector3 positionBirdMin;
    public Vector3 positionBirdPlus;

    // Start is called before the first frame update
    void Start()
    {

        smartBird = true;

        positionBirdMin.y = transform.position.y;
        positionBirdMin.z = transform.position.z;
        positionBirdMin.x = transform.position.x;
        positionBirdPlus.y = transform.position.y;
        positionBirdPlus.z = transform.position.z;
        positionBirdPlus.x = transform.position.x;

        positionBirdPlus.y++;
        positionBirdPlus.z++;
        positionBirdPlus.x++;
        positionBirdMin.y--;
        positionBirdMin.z--;
        positionBirdMin.x--;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(move * birdSpeed * Time.deltaTime);
        move.y = birdLevel.y;

        if (dumbBird == true)
        {
            if (transform.position.y >= 9)
            {
                birdLevel.y = -0.625f;
            }
            if (transform.position.y <= 7.5f)
            {
                birdLevel.y = 0.5f;
            }
        }

        if (smartBird == true)
        {
            if (transform.position.y >= positionBirdPlus.y)
            {
                birdLevel.y = -0.625f;
            }
            if (transform.position.y <= positionBirdMin.y)
            {
                birdLevel.y = 0.5f;
            }
            if (transform.position.x >= positionBirdPlus.y)
            {
                birdLevel.x = 0.25f;
            }
        }
    }
}
