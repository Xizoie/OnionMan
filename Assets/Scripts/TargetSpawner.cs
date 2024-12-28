using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Sprite[] targetSprite;


    [SerializeField] private BoxCollider2D cd;
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float coolDown;
    private float timer;

    private int sushiCreated;
    private int sushiMilestone;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = coolDown;
            sushiCreated++;

            if(sushiCreated > sushiMilestone && coolDown > 0.5f)
            {
                sushiMilestone += 10;
                coolDown -= 0.3f;
            }

            GameObject newTarget = Instantiate(targetPrefab);
            

            float randomX = Random.Range(cd.bounds.min.x, cd.bounds.max.x);

            newTarget.transform.position = new Vector2(randomX, transform.position.y);

            newTarget.GetComponent<SpriteRenderer>().sprite = targetSprite[Random.Range(0, targetSprite.Length)];

            

        }

    }
}
