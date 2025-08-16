using UnityEngine;

public class Backroom : MonoBehaviour
{
    private bool isPlayerInside = false;
    public GameObject BackRoomMenu;
    void Start()
    {
        BackRoomMenu = transform.Find("BackRoomMenu").gameObject;
        BackRoomMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInside)
        {
            BackRoomMenu.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D Enter)
    {
        if (Enter.CompareTag("Player"))
        {
            Debug.Log("It's working here.");
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D Exit)
    {
        if (Exit.CompareTag("Player"))
        {
            isPlayerInside = false;
            BackRoomMenu.SetActive(false);
        }
    }
}
