using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText; 

    void Start()
    {
       
        if (ScoreManager.instancia == null)
        {
            Debug.LogWarning("Esperando inicialización de ScoreManager...");
            return;
        }

        
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        if (ScoreManager.instancia != null && leaderboardText != null)
        {
            
            leaderboardText.text = "Leaderboard:\n";

            
            foreach (ScoreManager.PlayerData player in ScoreManager.instancia.GetLeaderboard())
            {
                leaderboardText.text += $"{player.playerName}: {player.score}\n";
            }

            Debug.Log("Leaderboard actualizado correctamente.");
        }
        else
        {
            
            Debug.LogError("ScoreManager o leaderboardText no están configurados correctamente.");
        }
    }
}

