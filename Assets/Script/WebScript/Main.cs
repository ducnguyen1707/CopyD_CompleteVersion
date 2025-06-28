using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour
{
    public static Main Instance; // dong nay de ke thua cac gias tri trong script khac

    public Web Web;
    private void Awake()
    {
        Instance = this;
       
    }
    void Start()
    {
        
    }

}
