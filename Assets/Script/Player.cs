using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public bool isJumping = false, isDbJump = false;
    public Rigidbody2D r2;
        public Animator anim;
        public int blood = 10;
        public Slider bloods;
        public bool isPause = false;
       

        public GUIMenu GUImenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        GUImenu = GameObject.FindGameObjectWithTag("GUIController").GetComponent<GUIMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        bloods.value = blood;
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isDbJump", isDbJump);

      
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (!isJumping)
            {
                isJumping = true;
                isDbJump = true;
               r2.AddForce(Vector2.up * jumpPow);
           
            }
            else
            {
                if(isDbJump){
                    isDbJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 2f);
                }
            }
        }

//         if(Input.GetKeyDown(KeyCode.D)){
// gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
//         }
    }

  void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
        {
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        }
         if (r2.velocity.x < -maxspeed)
        {
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        }
  }
        
//  void OnCollisionEnter2D(Collision2D other) {
//  }


// public GUIStyle style1,style2;

// private void OnGUI() {
//     if(blood == 0){
//         Time.timeScale = 0;

//         if(GUI.Button(new Rect(220,200,70,50),"CHOI LAI DI")){
//             SceneManager.LoadScene("SampleScene");
//         }
//         GUI.Button(new Rect(350,200,70,50),"MENU");
//     }
    // if(GUI.Button(new Rect(565,260,70,50),"",style1)){
    //     if(isPause == false){
    //         Time.timeScale = 0;
    //         isPause = true;
    //     }
    //     else{
    //         Time.timeScale = 1
    //     }
    // }
    // GUI.Box(new Rect(170,10,150,70),icon[0],style1);
    // GUI.Label(new Rect(260,25,150,70),coin.ToString(),style1);
    // if(blood == 0){
    //     GUI.Box(new Rect(170,10,150,70),icon[0],style1);
    // GUI.Label(new Rect(260,25,150,70)," X " + GUImenu.coin.ToString(),style1);
    // }
// }


void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "coin"){
            Destroy(other.gameObject);
               GUImenu.coin += 1;           
        }    
        if(other.tag == "end"){
     blood = 0;
     Time.timeScale = 0;
 }    
        }

}
