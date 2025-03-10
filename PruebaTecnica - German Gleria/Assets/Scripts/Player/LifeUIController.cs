using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeUIController : MonoBehaviour
{
    public Image[] hearts; 

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].gameObject.SetActive(true); 
            }
            else
            {
                hearts[i].gameObject.SetActive(false); 
            }
        }
    }
}
