using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject managementRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("문 열고 들어가기");
            managementRoom.SetActive(true);
            platform.SetActive(false);
        }
    }
}
