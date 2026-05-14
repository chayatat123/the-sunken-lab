using UnityEngine;

public class DoorPressurePlate : MonoBehaviour
{
    [Header("อ้างอิงประตู")]
    public GameObject door; // ลากวัตถุประตูมาใส่
    public Vector3 openPositionOffset = new Vector3(0, -3f, 0); // ระยะที่ประตูจะเลื่อน (เช่น เลื่อนลงดิน 3 เมตร)
    public float openSpeed = 2f; // ความเร็วในการเปิด

    private Vector3 closedPos;
    private Vector3 targetPos;
    

    void Start()
    {
        // จำตำแหน่งเริ่มต้นของประตูไว้ (ตอนปิด)
        if (door != null)
        {
            closedPos = door.transform.position;
            targetPos = closedPos;
        }
    }

    void Update()
    {
        // ทำให้ประตูค่อยๆ เลื่อนไปยังตำแหน่งเป้าหมาย
        if (door != null)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPos, Time.deltaTime * openSpeed);
        }
    }

    // เมื่อเดินเข้ามาเหยียบ
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            Debug.Log("เหยียบแผ่นเหลือง: ประตูเปิด");
            targetPos = closedPos + openPositionOffset;
        }
    }



}