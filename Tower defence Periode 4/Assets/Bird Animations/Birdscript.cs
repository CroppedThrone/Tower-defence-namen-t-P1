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
        positionBirdPlus.z += 10;
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
        move.z = birdLevel.z;
        move.x = birdLevel.x;

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
        // dit zorgt er voor dat als een object een 1f te ver gaan dat ze dan de omgekeerde richting om gaan.
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
            if (transform.position.x >= positionBirdPlus.x)
            {
                birdLevel.x = -0.25f;
            }
            if (transform.position.x <= positionBirdMin.x)
            {
                birdLevel.x = 0.50f;
            }
            if (transform.position.z >= positionBirdPlus.z)
            {
                birdLevel.z = -1f;
            }
            if(transform.position.z <= positionBirdMin.z)
            {
                birdLevel.z = 1f;
            }
        }
    }
}
