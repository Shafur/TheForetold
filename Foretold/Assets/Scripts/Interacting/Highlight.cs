using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Highlight : MonoBehaviour
{
    private Light2D light;
    public GameObject customerObject;



    void Start()
    {
        light = GetComponent<Light2D>();
    }


    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.gameObject.tag == "Player")
        {
            light.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.gameObject.tag == "Player")
        {
            light.enabled = false;
        }
    }
}

