using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] SpriteRenderer spriteRenderer;
    public float fireRate = 0.5f;
    public float maxAngle = 45f;
    private bool isFacingRight = false;
    private float nextFireTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        firePoint = transform.Find("OutputPointGun");
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot " + firePoint.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Aim()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);
        if (!isFacingRight) angle = -angle;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void FlipWeapon(bool isFacingRight)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !isFacingRight;
        }
        this.isFacingRight = isFacingRight;
    } 
}