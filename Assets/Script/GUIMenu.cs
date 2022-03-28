using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMenu : MonoBehaviour
{
  public Texture2D[] icon;
    public GUIStyle mySkin, mySkin2;
    bool pause = false;
    public GameObject player;
    public int score, coin = 0;
    public Player play;
    public bool isPause = false;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
                play = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void OnGUI() {
        score = (int) player.transform.position.x;
        
        // GUI.skin = mySkin;
        if (GUI.Button (new Rect (15, 15, 70, 70), icon[0], mySkin)) 
        {                   
    


            pause = !pause;
            if (pause == true)
            {
                Time.timeScale = 0;
                 
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        GUI.Box (new Rect (780, 15, 150, 60), icon[1], mySkin);
        GUI.Box (new Rect (780, 65, 150, 60), icon[2], mySkin);
        GUI.Label (new Rect (840, 30, 150, 60), score + " m ", mySkin);
    
        GUI.Label (new Rect (840, 80, 150, 60), coin.ToString(), mySkin);


        if(play.blood == 0){
             Time.timeScale = 0;
        GUI.Box(new Rect(200,40,450,250),icon[4],mySkin);
        if(GUI.Button(new Rect(320,230,100,50),icon[5],mySkin)){
            SceneManager.LoadScene("SampleScene");
        }
        if(GUI.Button(new Rect(440,230,100,50),icon[6],mySkin)){
            SceneManager.LoadScene("MenuScene");
        }        
        }
if(play.blood == 0){
    //  GUI.Box(new Rect(335,153,35,70),icon[3],mySkin);
    GUI.Label(new Rect(350,105,100,70),"X " + coin.ToString(),mySkin2);
    
        //  GUI.Box(new Rect(335,190,35,70),icon[7],mySkin);
    GUI.Label(new Rect(310,145,200,70),score + " m ",mySkin2);
}

    }
}
