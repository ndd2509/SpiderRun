using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIStart : MonoBehaviour
{
     public Texture2D[] icon;
    public GUIStyle mySkin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI() {         
        if(GUI.Button(new Rect(350,150,200,250),icon[0],mySkin)){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
