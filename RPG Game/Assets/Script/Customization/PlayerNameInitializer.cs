using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerNameInitializer : MonoBehaviour
{
    public InputField nameInputField;
    public Button startButton;

    private string playerName;

    void Start()
    {
        playerName = "";
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        string newName = nameInputField.text;

        if (!string.IsNullOrWhiteSpace(newName))
        {
            playerName = newName;
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.Log("Name cannot be empty!");
        }
    }

    void OnEnable()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }
    }
}
