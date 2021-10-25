using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HackTurretColour : MonoBehaviour
{
    [SerializeField]
    public Material greenColour;
    public Material blueColour;
    public Material purpleColour;
    public Renderer itemRenderer;
    public GameObject cubes;

    public Material myMaterial;




    void Start()
    {
        //itemRenderer = cubes.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

       //myMaterial.color = Random.ColorHSV(0f, 1f, 1f, 0f, 0f, 0f);
       //myMaterial.SetColor("_EmisionColor", Random.ColorHSV(0f, 1f, 1f, 0f, 0f, 0f));

         myMaterial = GetComponent<Renderer>().material; myMaterial.SetColor("_EmissionColor", Color.red);
    }

}
