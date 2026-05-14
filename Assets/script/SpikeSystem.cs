using UnityEngine;
using UnityEngine.SceneManagement;
public class SpikeSystem : MonoBehaviour
{
    public int myStage = 1;

    public GameObject spikePrefab;
    public Transform plantPoint;
    public ZoneManager zm;
    public static SpikeSystem lastActivatedSpike;
    [Header("Checkpoint")]
    public bool hasCheckpoint = false;
    public Vector3 lastCheckpointPosition;

    public Transform player; // 🔥 เพิ่ม

    private bool isPlayerInZone = false;
    private bool hasPlanted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("กด F");

            Debug.Log("อยู่ในโซน: " + isPlayerInZone);
            Debug.Log("ฆ่า: " + zm.currentKills + "/" + zm.killsRequired);
            Debug.Log("Stage: " + zm.currentStage + " / myStage: " + myStage);

            if (!isPlayerInZone) return;
            if (hasPlanted) return;
            if (zm.currentStage != myStage) return;
            if (zm.currentKills < zm.killsRequired) return;

            Debug.Log("ผ่านทุกเงื่อนไขแล้ว!");
            PlantSpike();
        }
    }

    void PlantSpike()
    {
        Instantiate(spikePrefab, plantPoint.position, plantPoint.rotation);

        if (player != null)
        {
            hasCheckpoint = true;
            lastCheckpointPosition = player.position;
            lastActivatedSpike = this;
        }

        hasPlanted = true;

        zm.currentStage++;

        // 🔥 ตรงนี้แหละ จุดจบเกม
        if (zm.currentStage > 4)
        {
            Debug.Log("ไปหน้า WIN!");
            SceneManager.LoadScene("Win"); // 👈 อยู่ตรงนี้
            return;
        }

        zm.SetStage(zm.currentStage);
        zm.UpdateUIExternal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerInZone = false;
    }
}