using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instancia;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public string currentPlayerName = "Jugador";
    public List<PlayerData> playerScores = new List<PlayerData>();

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        Debug.Log($"Escena cargada: {scene.name}");

        if (scoreText == null)
        {
            scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
            if (scoreText == null)
            {
                Debug.LogWarning($"No se encontró un objeto de texto llamado 'ScoreText' en la escena '{scene.name}'.");
            }
            else
            {
                UpdateScoreText();
            }
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }

    public void AddScore(int puntos)
    {
        score += puntos;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.Save();
    }

    public void AddPlayerToLeaderboard(string playerName)
    {
        if (string.IsNullOrWhiteSpace(playerName))
        {
            Debug.LogWarning("El nombre del jugador es inválido, no se añadirá al leaderboard.");
            return;
        }

        Debug.Log($"Añadiendo al leaderboard: {playerName} con puntaje: {score}");
        playerScores.Add(new PlayerData(playerName, score));
        playerScores.Sort((a, b) => b.score.CompareTo(a.score));
    }

    public List<PlayerData> GetLeaderboard()
    {
        Debug.Log($"Cantidad de jugadores en el leaderboard: {playerScores.Count}");
        return playerScores;
    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int score;

        public PlayerData(string playerName, int score)
        {
            this.playerName = playerName;
            this.score = score;
        }
    }
}




