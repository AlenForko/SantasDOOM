using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;

        public static bool isPaused;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
        }
        
        public void OnResume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        public void MainMenu()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            isPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
