using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Score : MonoBehaviour
{
    

    public Component spawnPoints;

    public RandomSpawner randomSpawner;


    public Text scoreText;


   

    void Start() {
        randomSpawner = spawnPoints.GetComponent<RandomSpawner>();
    }

    void OnEnable() {
        
    


    }

    // Update is called once per frame
    void Update()
    {
       scoreText.text =  "Score:" + randomSpawner.GetScore().ToString("000");
    }

    
}
