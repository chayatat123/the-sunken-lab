using UnityEngine;

public class GunSystem : MonoBehaviour
{
    [Header("ตั้งค่าปืน")]
    public float fireRate = 0.5f;

    [Header("กระสุน")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;

    [Header("เอฟเฟกต์")]
    public ParticleSystem muzzleFlash;

    [Header("เสียง")]
    public AudioSource gunAudio;     // 🔊 Audio Source
    public AudioClip shootSound;     // 🔫 เสียงยิง

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // 🔥 เอฟเฟกต์ปากกระบอก
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        // 🔊 เสียงยิง (เพิ่มตรงนี้)
        if (gunAudio != null && shootSound != null)
        {
            gunAudio.pitch = Random.Range(0.9f, 1.1f); // เสียงไม่ซ้ำ
            gunAudio.PlayOneShot(shootSound);
        }

        // 🔫 สร้างกระสุน
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet b = bullet.GetComponent<Bullet>();
        if (b != null)
        {
            b.isEnemyBullet = false;
        }
    }
}