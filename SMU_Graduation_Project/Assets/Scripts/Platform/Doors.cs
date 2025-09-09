using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject managementRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�� ���� ����");
            managementRoom.SetActive(true);
            platform.SetActive(false);
        }
    }
}
