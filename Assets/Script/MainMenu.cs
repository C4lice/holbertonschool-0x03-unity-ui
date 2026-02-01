using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Bouton jouer
    public Button PlayButton;
    // Bouton quitter
    public Button QuitButton;
    // Bouton des options
    public Button OptionButton;
    // Bouton retour
    public Button BackButton;
    // Page du menu principal
    public GameObject MainMenuPage;
    // Page des options
    public GameObject OptionPage;
    // Matériel des pièges
    public Material trapMat;
    // Matériel de l'objectif
    public Material goalMat;
    // Option daltonien
    public Toggle colorblindMode;

    // Initialisation
    void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClicked);
        OptionButton.onClick.AddListener(OptionButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);
        BackButton.onClick.AddListener(BackButtonClicked);
    }

    // Lancer le jeu
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
    // Quitter le jeu
    void QuitButtonClicked()
    {
        Debug.Log("Quit Game");
    }
    // Ouvrir la page des options
    void OptionButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(false);
        OptionPage.gameObject.SetActive(true);
    }
    // Retour au menu principal
    void BackButtonClicked()
    {
        MainMenuPage.gameObject.SetActive(true);
        OptionPage.gameObject.SetActive(false);
    }
}
