using UnityEngine;

public class Respawn : MonoBehaviour
{
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    public void RespawnPlayer()
    {
        if (cc != null) cc.enabled = false;

        // 🔥 ใช้ checkpoint ล่าสุด
        if (SpikeSystem.lastActivatedSpike != null &&
            SpikeSystem.lastActivatedSpike.hasCheckpoint)
        {
            transform.position = SpikeSystem.lastActivatedSpike.lastCheckpointPosition;
        }
        else
        {
            transform.position = new Vector3(0, 2, 0);
        }

        if (cc != null) cc.enabled = true;
    }
}