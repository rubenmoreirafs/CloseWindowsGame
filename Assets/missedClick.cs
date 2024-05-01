using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missedClick : MonoBehaviour
{
    public Component spawnPoints;
    public RandomSpawner randomSpawner;
    // Start is called before the first frame update
    void Start()
    {
        randomSpawner = spawnPoints.GetComponent<RandomSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {

        
        
        if(Input.GetMouseButtonDown(0)) {
            randomSpawner.GetMissSound().Play();
            randomSpawner.SetScore(-1); 
        }

        
    
    }

    public void SetComponent(Component component) {
        this.spawnPoints = component;
    }
}
