using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HackTurretColour : MonoBehaviour
{
    [SerializeField]
    public Material greenColour;
    public Material blueColour;
    public Material magentaColour;

    public Color colorIDgreen;
    public Color colorIDblue;
    public Color colorIDmagenta;

    public float colorTimegreen;
    public float colorTimeblue;
    public float colorTimemagenta;



    void Start()
    {
       greenColour.EnableKeyword("_EMISSION");
        blueColour.EnableKeyword("_EMISSION");
        magentaColour.EnableKeyword("_EMISSION");

        colorIDgreen = new Color32(120, 214, 150,255);
        colorIDblue = Color.blue;
        colorIDmagenta = Color.magenta;


        StartCoroutine(BeginSignal(greenColour, colorTimegreen));
        StartCoroutine(BeginSignal(blueColour, colorTimeblue));
        StartCoroutine(BeginSignal(magentaColour, colorTimemagenta));
    }
        

    IEnumerator BeginSignal(Material m, float colorTime) {
        while (true)
        {

            m.SetColor("_EmissionColor", colorIDblue);
            yield return new WaitForSeconds(colorTime);
            m.SetColor("_EmissionColor", colorIDmagenta);
            yield return new WaitForSeconds(colorTime);
            m.SetColor("_EmissionColor", colorIDgreen);
            yield return new WaitForSeconds(colorTime);
        }
    }
}
