using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject resetText;

    public void Lose() {
        loseText.SetActive(true);
        resetText.SetActive(true);
    }

    public void Win() {
        winText.SetActive(true);
        resetText.SetActive(true);
    }

    public void RestartPressed() {
        winText.SetActive(false);
        loseText.SetActive(false);
        resetText.SetActive(false);
        Settings.Restart();
    }

    void Update() {
        if (resetText.activeInHierarchy && Input.GetKeyDown(KeyCode.R)) {
            RestartPressed();
        }
    }
}
