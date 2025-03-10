using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class MainMenuUI : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI scoreText;

    public void PlayGame()
    {
        if (ScoreManager.instancia != null)
        {
            string playerName = nameInputField.text;

            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Jugador"; 
            }

            
            ScoreManager.instancia.currentPlayerName = playerName;
            Debug.Log("Nombre configurado en el ScoreManager: " + playerName);

           
            ScoreManager.instancia.ResetScore();
        }

       
        SceneManager.LoadScene("Game");
    }
    public void OpenControlsScene()
    {
        
        SceneManager.LoadScene("Controls");
    }

    public void OpenCreditsScene()
    {

        SceneManager.LoadScene("CreditsScene");
    }

    public void ExitGame()
    {
        Debug.Log("El juego se está cerrando.");
        Application.Quit();
    }
}