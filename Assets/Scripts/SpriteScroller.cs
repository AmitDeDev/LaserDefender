using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 offset;
    private Material _material;
    private SceneManager _sceneManager;
    private Scene _currentActiveScene;
    
    void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
        _currentActiveScene = SceneManager.GetActiveScene();
    }
    
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += offset;
        OnPlayerMoveScrollDirection();
    }
    
    void OnPlayerMoveScrollDirection()
    {
        if (_currentActiveScene.ToString() != "Game")
        {
            return;
        }
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
