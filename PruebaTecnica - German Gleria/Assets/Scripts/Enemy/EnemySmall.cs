using UnityEngine;

public class EnemySmall : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 1.5f;
    public float destroyAfter = 5f;
    public float bulletSpeed = 5f;
    public float moveSpeed = 2f;
    public float zigzagAmplitude = 2f;
    public float zigzagFrequency = 2f;
    public Transform shootTransform;
    public GameObject explosionPrefab;
    private float startX;
    public int puntosPorEliminar = 10;

    void Start()
    {

        startX = transform.position.x;


        InvokeRepeating("Shoot", 1f, shootInterval);
        Destroy(gameObject, destroyAfter);
    }

    void Update()
    {

        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);


        float zigzag = Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude;
        transform.position = new Vector3(startX + zigzag, transform.position.y, -transform.position.z);
    }

    void Shoot()
    {

        Vector3 shootPosition = shootTransform != null ? shootTransform.position : transform.position;

        GameObject bullet = Instantiate(bulletPrefab, shootPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Eliminar();
            Destroy(gameObject);
        }
    }

    public void Eliminar()
    {
        ScoreManager.instancia.AddScore(puntosPorEliminar);
        Destroy(gameObject);
    }
}
