using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Référence au joueur
    public GameObject player;

    // Distance entre la caméra et le joueur
    private Vector3 offset;

    void Start()
    {
        // Calcul de l’offset initial entre la caméra et le joueur
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // La caméra suit le joueur en gardant le même offset
        transform.position = player.transform.position + offset;
    }
}
