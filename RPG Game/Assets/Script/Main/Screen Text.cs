using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePageScript : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    private string[] messages = { "This will be the first set of text", "This will be the second set of text" };
    private int currentMessageIndex = -1;
    private bool isTyping = false;
    public string nextclass = "Customization";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping)
        {
            currentMessageIndex++;
            if (currentMessageIndex < messages.Length)
            {
                StartCoroutine(TypeText(messages[currentMessageIndex]));
            }
            else
            {
                LoadNextScene();
            }
        }
    }

    IEnumerator TypeText(string message)
    {
        isTyping = true;
        titleText.text = "";
        foreach (char letter in message)
        {
            titleText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextclass);
    }
}
