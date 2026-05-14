using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // เช็กว่าโดน Player หรือไม่
        if (other.CompareTag("Player"))
        {
            DoRespawn(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // เผื่อในกรณีที่ไม่ได้ตั้งเป็น Trigger
        if (collision.gameObject.CompareTag("Player"))
        {
            DoRespawn(collision.gameObject);
        }
    }

    void DoRespawn(GameObject playerObj)
    {
        Debug.Log("Spike Hit Player!");
        PlayerMovement pm = playerObj.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            pm.RespawnAtCheckpoint();
        }
    }
}