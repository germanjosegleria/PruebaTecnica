using TMPro;
using UnityEngine;
using UnityEngine.UI;


using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText; // Referencia al elemento de texto del leaderboard

    void Start()
    {
        // Verifica que el ScoreManager esté inicializado
        if (ScoreManager.instancia == null)
        {
            Debug.LogWarning("Esperando inicialización de ScoreManager...");
            return;
        }

        // Actualiza el leaderboard
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        if (ScoreManager.instancia != null && leaderboardText != null)
        {
            // Inicializa el texto del leaderboard
            leaderboardText.text = "Leaderboard:\n";

            // Obtén la lista del Leaderboard y muestra los nombres y puntajes
            foreach (ScoreManager.PlayerData player in ScoreManager.instancia.GetLeaderboard())
            {
                leaderboardText.text += $"{player.playerName}: {player.score}\n";
            }

            Debug.Log("Leaderboard actualizado correctamente.");
        }
        else
        {
            // Si algo no está configurado, muestra advertencia
            Debug.LogError("ScoreManager o leaderboardText no están configurados correctamente.");
        }
    }
}

