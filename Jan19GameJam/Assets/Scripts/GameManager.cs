using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.transform.position.y < -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Application.LoadLevel(Application.loadedLevel);
        }
    }
}
