using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("ตั้งค่าความไวเมาส์")]
    public float mouseSensitivity = 100f;

    [Header("ลากตัวละคร (Player) มาใส่ช่องนี้")]
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        // ล็อคเคอร์เซอร์เมาส์ไว้ตรงกลางจอและซ่อนลูกศรเมาส์
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. รับค่าการขยับเมาส์ ซ้าย-ขวา (X) และ บน-ล่าง (Y)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 2. คำนวณมุมก้มและเงย (ใช้ -mouseY เพื่อไม่ให้ทิศทางสลับกัน)
        xRotation -= mouseY;

        // 3. ล็อคมุมกล้องไม่ให้หมุนเกิน 90 องศา (ไม่ให้ตีลังกากลับหลัง)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 4. สั่งให้กล้องหมุนขึ้น-ลง
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 5. สั่งให้ตัวละครทั้งหมดหมุนซ้าย-ขวา ตามเมาส์
        playerBody.Rotate(Vector3.up * mouseX);
    }
}