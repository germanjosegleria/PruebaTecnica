using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public float lifeTime; 

    void OnEnable()
    {
        
        Invoke("Desactivar", lifeTime);
    }

    void Desactivar()
    {
       
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        
        CancelInvoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false); 
            gameObject.SetActive(false); 
        }
    }
}

