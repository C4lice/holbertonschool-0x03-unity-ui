using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Démarrer le jeu en chargeant la scène suivante
    public void PlayGame()
    {
        SceneManager.LoadScene("maze"); // dans PlayMaze()
        SceneManager.LoadScene("MainMenu"); // dans PlayerController pour Esc

    }
    // Quitter le jeu
    public void QuitGame()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }
}
