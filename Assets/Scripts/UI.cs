using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private AudioSource _winSound;

    public static UI instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    private float elapsedTime = 0.5f;
    [SerializeField] private TextMeshProUGUI ammoText;

    public int scoreValue;

    [Space]

    [SerializeField] private GunController gunContoller;

    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private GameObject WinButton;

    private void Awake()
    {
        instance = this;
    }
    

    void Update()
    {
        if (Time.time > 0)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = elapsedTime.ToString("#,#");
        }

        ammoText.text = gunContoller.currentBullet + "/" + gunContoller.maxBullet;
    }

    public void AddScrore()
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString("#,#");
        if (scoreValue >= 60)
        {
            _winSound.Play();
            WinButton.SetActive(true);
            Time.timeScale = 0;
            Destroy(GameObject.FindWithTag("Player"));
        }

    }

    public void OpenEndScreen()
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadStartMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

}
