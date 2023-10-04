using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;
    private Transform target;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        transform.position = startPos;
        GameManager.Instance.EnableDrag();
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        /*if (target)
        {
            transform.position = target.position;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
            GetComponent<BoxCollider2D>().enabled = false;
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
        }*/
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("z"))
        {
            GameManager.Instance.StopDrag();
            PickUp();
        }
        if (collision.transform.CompareTag("c"))
        {
            GameManager.Instance.GetCurrentLevel().RemoveObject(collision.gameObject);
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
        }
        if (collision.transform.CompareTag("b"))
        {
            if(GameManager.Instance.GetCurrentLevel().collectObj >= GameManager.Instance.GetCurrentLevel().countObj)
            {
                GameManager.Instance.CheckLevelUp();
            }
        }
    }
    
}
