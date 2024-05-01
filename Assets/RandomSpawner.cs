using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
   
    public Transform[] spawnPoints;

    public GameObject[] target;

    public GameObject[] targetClones;

    public LerpMovement[] lerpMovementScript;

    [SerializeField] private AudioSource normalHitSound;
    [SerializeField] private AudioSource criticalHitSound;

    [SerializeField] private AudioSource missSound;

    [SerializeField] private AudioSource dissapearedSound;

    [SerializeField] private AudioSource backgroundMusic;

    [SerializeField] private AudioSource windowSpawnSound;
    private int score = 0;

     // Start is called before the first frame update
    void Start()
    {   
        lerpMovementScript = new LerpMovement[targetClones.Length];

         for(int i = 0; i < 6; i++) {
            targetClones[i] = Instantiate(target[i], spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            targetClones[i].GetComponent<Box>().SetComponent(this);
            targetClones[i].GetComponent<LerpMovement>().SetComponent(this);
            lerpMovementScript[i] = targetClones[i].GetComponent<LerpMovement>();
        }
    }

    void OnEnable() {
        
    }

    // Update is called once per frame
    void Update()
    { 

       // Debug.Log(targetClones.transform.localScale + "Spawn Script");
        for(int j = 0; j < targetClones.Length; j++) {
            if(!targetClones[j].activeSelf)
            {   
            //verify if the reason it got disabled was for being shot normally, critical hit or not shot in time !!!

            //int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            targetClones[j].transform.position = spawnPoints[randSpawnPoint].position;
            targetClones[j].transform.localScale = lerpMovementScript[j].getStartScale();
            targetClones[j].SetActive(true);
            windowSpawnSound.Play();

            } 
        }
           
    }

    public void SetScore(int value) {
        if(this.score + value <= 0) {
            this.score = 0;
        } else if(score + value > 0) {
            this.score += value;
        }
    }

    public int GetScore() {
        return score;
    }

    public AudioSource GetNormalHitSound() {
        return normalHitSound;
    }

    public AudioSource GetCriticalHitSound() {
        return criticalHitSound;
    }

    public AudioSource GetMissSound() {
        return missSound;
    }

    public AudioSource GetDissapearedSound() {
        return dissapearedSound;
    }

    public AudioSource GetWindowSpawnSound() {
        return windowSpawnSound;
    }

}
