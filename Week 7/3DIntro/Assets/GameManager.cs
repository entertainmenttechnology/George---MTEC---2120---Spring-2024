using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager _gameManager;

    public SimpleControl player;

    private bool isPlayerAnimating;

    public delegate void OnAnimationChanged(bool isAnimating);

    public event OnAnimationChanged Changed;

    static public GameManager gameManager
    {
        get
        {
            if(_gameManager == null)
            {
                _gameManager =  FindFirstObjectByType<GameManager>();
            }
            if(_gameManager == null)
            {
                GameObject temp = new GameObject("GameManager");
                _gameManager = temp.AddComponent<GameManager>();
                
            }
            return _gameManager;
        }
        
    }
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerAnimating && player.isAnimating())
        {
            //alert animation start
            Changed(true);

        }
        if(isPlayerAnimating && !player.isAnimating())
        {
            Changed(false);
            //alert animation end
        }
        isPlayerAnimating = player.isAnimating();
    }

   
}
