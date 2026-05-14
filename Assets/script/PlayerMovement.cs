using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("คอมโพเนนต์บังคับ")]
    public CharacterController controller;

    [Header("ตั้งค่าการเคลื่อนที่")]
    public float speed = 8f;
    public float gravity = -19.62f;
    public float jumpHeight = 2f;

    [Header("ระบบตรวจสอบพื้น")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("เสียงเดิน")]
    public AudioSource footstepAudio;

    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        // 🔥 เช็คพื้น (สำคัญมาก)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }

        // 🔥 รับ input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        // 🔥 เดิน
        controller.Move(move * speed * Time.deltaTime);

        // =========================
        // 🎧 ระบบเสียงเดิน (แก้สมบูรณ์)
        // =========================
        bool isMoving = move.magnitude > 0.1f;

        if (footstepAudio != null)
        {
            if (isMoving && isGrounded)
            {
                if (!footstepAudio.isPlaying)
                {
                    footstepAudio.pitch = Random.Range(0.9f, 1.1f);
                    footstepAudio.Play();
                }
            }
            else
            {
                if (footstepAudio.isPlaying)
                {
                    footstepAudio.Pause(); // ลื่นกว่า Stop
                }
            }
        }

        // 🔥 กระโดด
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // 🔥 gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void RespawnAtCheckpoint()
    {
        if (controller != null) controller.enabled = false;

        SpikeSystem spike = FindAnyObjectByType<SpikeSystem>();

        if (spike != null && spike.hasCheckpoint)
        {
            transform.position = spike.lastCheckpointPosition;
            Debug.Log("วาร์ปไปจุดวาง Spike ล่าสุด!");
        }
        else
        {
            transform.position = new Vector3(0f, 2f, 0f);
            Debug.Log("ยังไม่มี Checkpoint กลับไปจุดเริ่ม");
        }

        if (controller != null) controller.enabled = true;
    }
}