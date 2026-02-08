using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;

    public Button QuitButton;

    public Button OptionButton;

    public Button BackButton;

    public GameObject MainMenuPage;

    public GameObject OptionPage;

    public Material trapMat;

    public Material goalMat;

    public Toggle colorblindMode;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClicked);
        OptionButton.onClick.AddListener(OptionButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);
        BackButton.onClick.AddListener(BackButtonClicked);
    }

    // Update is called once per frame
    void PlayButtonClicked()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene(sceneName:"maze"); 
    }

    void QuitButtonClicked()
    {
        Debug.Log("Quit Game");
    }

    void OptionButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(false);
        OptionPage.gameObject.SetActive(true);
    }

    void BackButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(true);
        OptionPage.gameObject.SetActive(false);
    }
}
