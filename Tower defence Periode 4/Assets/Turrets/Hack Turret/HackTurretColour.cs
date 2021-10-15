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
    public Color greenToWhiteColour;
    public GameObject cubes;

    // Start is called before the first frame update
    void Start()
    {
        itemRenderer = cubes.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        greenToWhiteColour = new Color();

    }
}
