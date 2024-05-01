using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float remainingTime = 60;


    // Update is called once per frame
    void Update()
    {

        if(remainingTime > 0) {
            remainingTime -= Time.deltaTime;
        } else if(remainingTime < 0) {
            remainingTime = 0;
            //gameover
            timerText.color = Color.red;    
            SceneManager.LoadSceneAsync(2);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = "Time:" + string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
