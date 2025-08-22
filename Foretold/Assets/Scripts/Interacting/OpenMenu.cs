using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    private bool isPlayerInside = false;
    private bool menuOpen = false;
    public GameObject npcMenu;

    void Start()
    {
        npcMenu = transform.Find("npcMenu").gameObject;
        npcMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside && !menuOpen)
        {
            npcMenu.SetActive(true);
            menuOpen = true;
        }
         else if ((Input.GetKeyDown(KeyCode.E) || (Input.GetKeyDown(KeyCode.Escape)))&& isPlayerInside && menuOpen)
         {
             npcMenu.SetActive(false);
             menuOpen = false;
         }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            isPlayerInside = false;
            npcMenu.SetActive(false);
        }
    }
}
