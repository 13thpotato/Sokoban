using UnityEngine;
using UnityEngine.SceneManagement;

//ƒ^ƒCƒgƒ‹‚É–ß‚é
public class ClearManager : MonoBehaviour
{
    public void ReturnToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
