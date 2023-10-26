using AI;
using Sound;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject bosss;
    public Image endScreenImage;
    public TextWriting textWriting;
    public PauseMenu pauseMenu;
    public AudioManager audioManager;
    public AudioSource endGameAudioSource;
    public float endScreenSpeed;

    bool endScreen;
    bool textEnd;

    private void Start()
    {
        textWriting.onReachedEnd.AddListener(TextEnd);
    }

    private void Update()
    {
        if (bosss == null && !endScreen)
        {
            endScreen = true;
            audioManager.Stop();
            endScreenImage.gameObject.SetActive(true);
            endGameAudioSource.Play();
        }

        if (endScreen)
        {
            Time.timeScale = 0f;
            endScreenImage.fillAmount = Mathf.Lerp(endScreenImage.fillAmount, 1, Time.unscaledDeltaTime * endScreenSpeed);
            if(endScreenImage.fillAmount > 0.9)
            {
                endScreenImage.fillAmount = 1;
                textWriting.StartText();
            }
        }

        if (textEnd)
        {
            if (Input.anyKeyDown && textEnd)
            {
                pauseMenu.MainMenu();
            }
        }
       
    }

    public void TextEnd()
    {
        textEnd = true;
    }
}
