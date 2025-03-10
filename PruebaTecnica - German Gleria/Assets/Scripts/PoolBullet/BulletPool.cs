using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public int poolSize = 10; 

    private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Add(bullet);
            Debug.Log($"Bala creada: {bullet.name}"); 
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in pool)
        {
            if (bullet != null && !bullet.activeInHierarchy) 
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(true);
        pool.Add(newBullet);
        return newBullet;
    }
}
