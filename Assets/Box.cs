using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Box : MonoBehaviour
{

    BoxCollider2D boxCollider2D;
    CircleCollider2D circleCollider2D;

    public Component spawnPoints;
    public RandomSpawner randomSpawner;






    void Start() {

        boxCollider2D = GetComponent<BoxCollider2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        randomSpawner = spawnPoints.GetComponent<RandomSpawner>();

    }
    // Update is called once per frame
    void Update()
    {

    
         
    }

    void OnMouseDown() {

        
        
        if(Input.GetMouseButtonDown(0)) {

            Vector3 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider == boxCollider2D) {

                randomSpawner.GetNormalHitSound().Play();
                randomSpawner.SetScore(1);
                this.gameObject.SetActive(false);
                Debug.Log("normal hit");
                
            
            }
            if(hit.collider == circleCollider2D) {
                randomSpawner.GetCriticalHitSound().Play();
                randomSpawner.SetScore(6);
                this.gameObject.SetActive(false);
                Debug.Log("critical hit");
            
            }
        }

        
    
    }

    public void SetComponent(Component component) {
        this.spawnPoints = component;
    }
}   
