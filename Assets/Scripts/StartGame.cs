using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(GameManager.instant.getlevel());
    }
}
