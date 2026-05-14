using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("การตั้งค่าการเคลื่อนที่")]
    public float speed = 2f;      // ความเร็วในการขยับ
    public float distance = 3f;   // ระยะทางที่สวิงไป-กลับ

    [Tooltip("กำหนดแกนที่จะให้ขยับ เช่น (1,0,0) คือแกน X, (0,0,1) คือแกน Z")]
    public Vector3 moveAxis = new Vector3(1, 0, 0);

    private Vector3 startPosition;

    void Start()
    {
        // บันทึกตำแหน่งเริ่มต้นไว้
        startPosition = transform.position;
    }

    void Update()
    {
        // คำนวณการเลื่อนไป-กลับด้วย Mathf.Sin
        float movement = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPosition + (moveAxis.normalized * movement);
    }
}