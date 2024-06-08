using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShooting2D : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 20f; 
    public float fireRate = 1f; 
    private float nextTimeToFire = 0f; 
    private Transform player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        bulletSpeed = 750f;
        fireRate = 0.8f;
    }

    void Update()
    {
        if (player != null)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 direction = (player.position - firePoint.position).normalized; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

	Destroy(bullet, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
