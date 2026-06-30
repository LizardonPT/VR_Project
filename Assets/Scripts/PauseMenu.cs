using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Input")]
    public InputActionProperty pauseAction;

    [Header("References")]
    public GameObject menuCanvas;
    public Transform playerCamera;
    public GameObject xrRayInteractorRight;
    public GameObject xrRayInteractorLeft;

    [Header("Settings")]
    public float distanceFromPlayer = 1.2f;

    private bool isPaused = false;

    void Update()
    {
        if (pauseAction.action.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }
    }

    void ShowMenu()
    {
        Time.timeScale = 0;

        menuCanvas.SetActive(true);

        xrRayInteractorRight.SetActive(true);
        xrRayInteractorLeft.SetActive(true);

        // Coloca o menu à frente do jogador
        menuCanvas.transform.position =
            playerCamera.position + playerCamera.forward * distanceFromPlayer;

        // Ignora a inclinação da cabeça
        Vector3 forward = playerCamera.forward;
        forward.y = 0;
        menuCanvas.transform.rotation = Quaternion.LookRotation(forward);
    }

    void HideMenu()
    {
        Time.timeScale = 1;
        menuCanvas.SetActive(false);
        xrRayInteractorRight.SetActive(false);
        xrRayInteractorLeft.SetActive(false);
    }

    public void ContinueGame()
    {
        TogglePause();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
