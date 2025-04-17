using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int timer = 60;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timeUpText;

    private void CountDown()
    {
        timer--;
        timerText.text = timer.ToString();

        if(timer <= 0)
        {
            CancelInvoke(nameof(CountDown));
            GameOver();
        }
    }

    private void GameOver()
    {
        timeUpText.SetActive(true);
        Invoke(nameof(GoToMenu), 2);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        timerText.text = timer.ToString();
        InvokeRepeating(nameof(CountDown), 1, 1);
    }
}
