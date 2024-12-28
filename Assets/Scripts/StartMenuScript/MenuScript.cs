using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject _soundOnImage;
    public GameObject _soundOffImage;
    public Button button;
    public bool isOn;

    public AudioSource audioSource;

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        _soundOnImage.SetActive(true);
        _soundOffImage.SetActive(false);
       
    }


    public void ButtonClicked()
    {

        if (isOn)
        {
            _soundOnImage.SetActive(false);
            _soundOffImage.SetActive(true);
            isOn = false;
            audioSource.mute = true;
            Debug.Log(isOn);
        }
        else 
        {
            _soundOnImage.SetActive(true);
            _soundOffImage.SetActive(false);
            isOn = true;
            audioSource.mute = false;
            Debug.Log(isOn);
        }
    }



    public void LoadMainScene()//load scene
    {
        SceneManager.LoadScene("MainScene");
       
    }
    public void Quit()//quit game
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

}
