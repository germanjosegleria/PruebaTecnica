using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int vida = 3;
    public GameObject explosionPrefab;
    private SpriteRenderer spriteRenderer;
    private Color colorOriginal;
    public AudioSource sonidoDaño;
    public CameraShake sacudidaCamara;
    public AudioClip sonidoExplosion;
    public LifeUIController lifeUI;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorOriginal = spriteRenderer.color;

        lifeUI.UpdateHealth(vida);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        Vector3 pos = transform.position;

        float screenHalfHeight = Camera.main.orthographicSize;
        float screenHalfWidth = screenHalfHeight * Camera.main.aspect;

        float playerHalfHeight = spriteRenderer.bounds.extents.y;
        float playerHalfWidth = spriteRenderer.bounds.extents.x;

        pos.x = Mathf.Clamp(pos.x, -screenHalfWidth + playerHalfWidth, screenHalfWidth - playerHalfWidth);
        pos.y = Mathf.Clamp(pos.y, -screenHalfHeight + playerHalfHeight, screenHalfHeight - playerHalfHeight);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            RecibirDaño(1);
            Destroy(collision.gameObject);
        }
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;

        lifeUI.UpdateHealth(vida);

        if (sonidoDaño != null)
        {
            sonidoDaño.Play();
        }

        StartCoroutine(ParpadearRojo());

        if (sacudidaCamara != null)
        {
            StartCoroutine(sacudidaCamara.Sacudir(0.2f, 0.2f));
        }

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Debug.Log("¡El jugador ha muerto!");

        if (ScoreManager.instancia != null)
        {
            string playerName = ScoreManager.instancia.currentPlayerName;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                Debug.LogWarning("El nombre del jugador no está configurado en ScoreManager.");
                playerName = "Jugador";
            }

            Debug.Log("Registrando puntaje para: " + playerName);

            ScoreManager.instancia.AddPlayerToLeaderboard(playerName);
            ScoreManager.instancia.SaveScore();
        }
        else
        {
            Debug.LogWarning("ScoreManager no está configurado o es nulo.");
        }

        Destroy(gameObject);
        SceneManager.LoadScene("GameOverScene");
    }

    private IEnumerator ParpadearRojo()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = colorOriginal;
    }
}

