using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 offset;
    private Material _material;
    private LevelManager _levelManager;
    
    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        _levelManager = FindObjectOfType<LevelManager>();
    }
    
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += offset;
        //TODO need to fix the issue of BG scrolling direction when on game scene related to scene manager current active scene index
        if (_levelManager.GetCurrentActiveSceneIndex() == 1)
        {
            OnPlayerMoveScrollDirection();
        }
    }
    
    void OnPlayerMoveScrollDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveSpeed.y = 0.35f;
        }
        else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveSpeed.y = 0.1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveSpeed.x = 0.1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveSpeed.x = -0.1f;
        }
        else
        {
            moveSpeed.y = 0.2f;
            moveSpeed.x = 0f;
        }
    }
}
