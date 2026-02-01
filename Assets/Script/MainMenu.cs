using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    public void PlayMaze()
    {
        // Vérifie si le mode daltonien est activé
        if (colorblindMode.isOn)
        {
            // Orange pour les pièges
            trapMat.color = new Color32(255, 112, 0, 1);

            // Bleu pour l'objectif
            goalMat.color = Color.blue;
        }

        // Charge la scène du labyrinthe
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
