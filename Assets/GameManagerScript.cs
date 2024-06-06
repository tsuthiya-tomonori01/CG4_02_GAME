using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;

    public GameObject block2;

    public GameObject Goal;

    public GameObject coin;

    public TextMeshProUGUI scoreText;

    public GameObject goalParticle;

    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1980, 1080, false);

        score = 0;

        int[,] map =
        {
         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
         {1,0,0,0,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,1,1,1,1,1},
         {1,0,3,0,1,1,0,0,0,1,1,0,3,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,1,1,1,0,0,0,0,1,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {1,0,3,0,0,0,1,0,0,0,0,0,3,0,0,0,0,0,3,0,3,0,3,0,3,0,3,0,3,0,3,3,0,3,0,3,0,0,2,1},
         {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        Vector3 position = Vector3.zero;
        //Instantiate(block, position, Quaternion.identity);

        int lenY = map.GetLength(0);

        int lenX = map.GetLength(1);

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x + 5;

                position.y = -y + 5;

                if (map[y,x] == 1)
                {
                    Instantiate(block, position, Quaternion.identity);
                }

                if (map[y,x] == 2)
                {
                    Instantiate(Goal, position, Quaternion.identity);
                    Goal.transform.position = position;
                    goalParticle.transform.position = position;
                }
                if (map[y,x] == 3)
                {
                    Instantiate(coin, position, Quaternion.identity);
                }
            }
        }

        for (int y = 0; y < lenY; y++)
        {
            for(int x = 0; x < lenX; x++)
            {
                position.x = x + 5;
                position.y = -y + 5;
                position.z = 3;
                Instantiate(block2, position, Quaternion.identity);
            }
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE " + score;

        if(GoalScript.isGameClear == true)
        {
            if(Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("TitleScene");

                GoalScript.isGameClear = false;
            }
        }
    }
}
