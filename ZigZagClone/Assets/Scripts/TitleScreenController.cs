using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public void LoadNextScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
