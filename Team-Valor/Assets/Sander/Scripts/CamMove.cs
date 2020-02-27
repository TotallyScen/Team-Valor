using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Vector3 offset; //x 0 y 11? z-7?
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // raycast vanaf de cam naar de player en als het iets hit dat niet de player hit zet de renderer uit tot de ray weer de player raakt

        transform.position = player.transform.position + offset;
    }
}
