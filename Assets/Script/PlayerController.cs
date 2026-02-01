using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Score du joueur
    private int score = 0;
    // Texte du score
    public Text scoreText;
    // Texte de la santé
    public Text healthText;
    // Texte pour l'écran de victoire/défaite
    public Text WinOrLoose;
    // Image de fond pour l'écran de victoire/défaite
    public Image WinLoseBG;
    // Santé du joueur
    public int health = 5;
    // Vitesse du joueur
    [Tooltip("speed of the player")]
    [SerializeField]
    public float speed;
    // Rigidbody du joueur
    private Rigidbody rb;
    // Initialisation
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Gérer les mises à jour chaque frame
    public void Update()
    {
        // Vérifier la santé du joueur
        if (health == 0)
        {
            WinLoseBG.color = Color.red;
            WinOrLoose.color = Color.white;
            WinOrLoose.text = "Game Over!";
            WinLoseBG.gameObject.SetActive(true);
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
        }
        // Retour au menu principal avec la touche Echap
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnButtonClicked();
        }
    }
    // Gérer le mouvement du joueur
    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
    // Gérer les collisions avec les déclencheurs
    void OnTriggerEnter(Collider other)
    {
        // Ramasser les objets
        if (other.CompareTag("Pickup")) 
        {
            score += 1;
            //Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }
        // Dommage des pièges
        else if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }
        //  Victoire
        else if (other.CompareTag("Goal"))
        {
            WinLoseBG.color = Color.green;
            WinOrLoose.color = Color.black;
            WinOrLoose.text = "You Win!";
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            //Debug.Log("You win!");
        }
    }
    // Met à jour le texte du score
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
    // Met à jour le texte de la santé
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }
    // Recharger la scène après un délai
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Retour au menu principal
    void OnButtonClicked()
    {
        SceneManager.LoadScene (sceneName:"menu");
    }
}
