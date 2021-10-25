using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HackTurretColour : MonoBehaviour
{
    [SerializeField]
    public Material greenColour;
    public Material blueColour;
    public Material magentaColour;

    public Material myMaterial;
    public Color colorIDgreen;
    public Color colorIDblue;
    public Color colorIDmagenta;



    void Start()
    {
       greenColour.EnableKeyword("_EMISSION");
        blueColour.EnableKeyword("_EMISSION");
        magentaColour.EnableKeyword("_EMISSION");

        colorIDgreen = Color.green;
        colorIDblue = Color.blue;
        colorIDmagenta = Color.magenta;


    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("BeginSignal");
    }
    IEnumerator BeginSignal()
    {
        while (true)
        {

            yield return new WaitForSeconds(2);
            greenColour.SetColor("_EmissionColor", colorIDblue);
            new WaitForSecondsRealtime(2);
            greenColour.SetColor("_EmissionColor", colorIDmagenta);
            new WaitForSecondsRealtime(2);
            greenColour.SetColor("_EmissionColor", colorIDgreen);
            new WaitForSecondsRealtime(2);
        }
    }

}
