using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HighlightTrigger : MonoBehaviour
{
    private Light2D light;
    public GameObject customerObject;

    // Start is called before the first frame update
    private void Start()
    {
        //Get the light component attached to this game object
        light = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            light.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            light.enabled = false;
        }
    }
}