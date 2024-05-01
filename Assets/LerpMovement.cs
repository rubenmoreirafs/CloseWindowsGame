using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public float ShrinkDuration = 100f;
    public Vector3 TargetScale = Vector3.zero;
    Vector3 startScale;
    public float t = 0;

    public bool isErased = false;

    public bool wasNotHit;

    public Component spawnPoints;
    public RandomSpawner randomSpawner;




    // Start is called before the first frame update
    void Start()
    {
        randomSpawner = spawnPoints.GetComponent<RandomSpawner>();
    }

    void OnEnable() {
        startScale = transform.localScale;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime / ShrinkDuration;

        Vector3 newScale =  Vector3.Lerp(startScale, TargetScale, t);

        transform.localScale = newScale;

        //Debug.Log(gameObject.transform.localScale + "Movement Script");


        if (t > 1) 
        {
            randomSpawner.GetDissapearedSound().Play();
            randomSpawner.SetScore(-3);
            this.gameObject.SetActive(false);
        }

    }

    public Vector3 getStartScale() {
        return this.startScale;
    }

    public void SetComponent(Component component) {
        this.spawnPoints = component;
    }
}
