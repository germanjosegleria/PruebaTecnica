using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool; 
    [SerializeField] private Transform shootTransform; 
    [SerializeField] private float bulletSpeed = 10f;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();

        if (bullet == null) 
        {
            Debug.LogWarning("No se pudo disparar porque no hay balas disponibles en el pool.");
            return; 
        }

        bullet.transform.position = transform.position; 
        bullet.transform.rotation = transform.rotation; 

        
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.up * bulletSpeed; 
        }
        else
        {
            Debug.LogError("El prefab de la bala no tiene un componente Rigidbody2D.");
        }
    }
}

