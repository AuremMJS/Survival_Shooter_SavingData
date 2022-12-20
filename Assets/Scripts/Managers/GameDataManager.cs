using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Serializable class to store player health and score
[System.Serializable]
public class GameData
{
    private int playerHealth;
    private int playerScore;

    public void SetHealth(int health)
    {
        playerHealth = health;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void ResetData()
    {
        playerHealth = 0;
        playerScore = 0;
    }
}

public class GameDataManager {

    private readonly string filePath = Application.persistentDataPath + "/playerData.data";
    private GameData gameData;

    // Singleton implementation
    private static GameDataManager instance;
    public static GameDataManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameDataManager();
            }
            return instance;
        }
    }

    // Constructor
    public GameDataManager()
    {
        LoadData();
    }

    // Save the persistent data
    public void SaveData()
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, gameData);

        dataStream.Close();
    }

    // Load persistent data
    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            gameData = converter.Deserialize(dataStream) as GameData;

            dataStream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in " + filePath);
            gameData = new GameData();
        }
    }

    // Set score
    public void SetScore(int score)
    {
        gameData.SetScore(score);
    }

    // Set health
    public void SetHealth(int health)
    {
        gameData.SetHealth(health);
    }

    // Reset game data
    public void ResetGameData()
    {
        gameData.ResetData();
    }

    // Get Score
    public int GetScore()
    {
        return gameData.GetScore();    
    }

    // Get health
    public int GetHealth()
    {
        return gameData.GetHealth();
    }
}
