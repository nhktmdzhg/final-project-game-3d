using UnityEngine;
using UnityEngine.SceneManagement;   // ✅ Needed for SceneManager

public class StartButton : MonoBehaviour
{
    // This function will be called when the button is clicked
    public void OnStartButtonClicked()
    {
        Debug.Log("Start Button Clicked! Loading SampleScene...");
        // Load the scene named "SampleScene"
        SceneManager.LoadScene("SampleScene");

    }
}
