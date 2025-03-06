using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        // Limitar o FPS a 60
        Application.targetFrameRate = 60;
    }
}
