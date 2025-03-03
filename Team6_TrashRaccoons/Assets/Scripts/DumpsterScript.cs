using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DumpsterScript : MonoBehaviour
{
    public int TrashBags = 0;
    public int TrashToMoveOn = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TrashBags >= TrashToMoveOn)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
