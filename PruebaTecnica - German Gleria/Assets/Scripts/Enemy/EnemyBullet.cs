using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float destroyAfter = 5f;

    void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}


