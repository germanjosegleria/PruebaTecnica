using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
   
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
