using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("scene0");
    }
}
