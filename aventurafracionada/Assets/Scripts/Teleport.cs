using UnityEngine;
using UnityEngine.SceneManagement; // Permite trocar de cena

public class Teleport : MonoBehaviour
{
    public string sceneName = "cena2"; // Nome da cena para teleportar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Se o jogador tocar no cubo
        {
            SceneManager.LoadScene(sceneName); // Muda para a nova cena
        }
    }
}
