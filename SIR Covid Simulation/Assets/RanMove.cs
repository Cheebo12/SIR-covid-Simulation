using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RanMove : Clock
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform movespot;
      
    public bool Iscovid;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
 
    public int age =0;
    public char Gender;
    
    

    public SpriteRenderer sprite;
 
    private int day = 0;   

    public int day_start = -1;
    
    public float s;
    // Start is called before the first frame update
    void Start()
    {  
        
        waitTime = startWaitTime;
        movespot.position = new Vector2(Random.Range(MinX,MaxX), Random.Range(MinY,MaxY));
        float xo = transform.position.x;
        float yo = transform.position.y;
        
         
        sprite = GetComponent<SpriteRenderer>();
        
        if(Iscovid == true){
             gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    
    
   
        if(s <= 24.0){    
    s = s + 0.01f;
    }else{
        if(day_start >=0){
         day_start++;
        }
        s = 0.0f;
        day++;
        death();
        recovery();
    } 
        
        
    if(age > 7 & Gender == 'M' & ((s>5.09 & s < 5.59)||(s > 13f && s < 13.5f) || (s > 16.3f && s < 17f) || (s > 18f && s < 18.5f) || (s > 19.5f && s < 20f) )){
        movespot.position = new Vector2(Random.Range(6.54f, 4.89f), Random.Range(4.27f, 3.05f));
        transform.position = Vector2.MoveTowards(transform.position,movespot.position, speed*Time.deltaTime);
    }else if(age > 15 & (s>9 & s<21)){
                
        movespot.position = new Vector2(Random.Range(-5.09f, -6.47f), Random.Range(4.27f, 3.05f));
        transform.position = Vector2.MoveTowards(transform.position,movespot.position, speed*Time.deltaTime);
    }else if(s > 9 & s < 21){
        transform.position = Vector2.MoveTowards(transform.position, movespot.position, speed*Time.deltaTime);

        if(Vector2.Distance(transform.position, movespot.position) < 0.2f){
           
          
           
           if(waitTime <= 0){
               movespot.position = new Vector2(Random.Range(MaxX,MinX), Random.Range(MaxY,MinY));
               waitTime = startWaitTime;
           } else {
               waitTime -= Time.deltaTime;
           }

        }
    }else{
        
        movespot.position = new Vector2(Random.Range(-5.27f,4.4f), Random.Range(-3.23f, -4.83f));
        transform.position = Vector2.MoveTowards(transform.position,movespot.position,speed*Time.deltaTime);
    }

        if(Iscovid == true){
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
}
private void OnCollisionEnter2D(Collision2D collision){
       
    if(collision.gameObject.tag == "person" & Iscovid == true  & (transform.position.y >-3.19 || (transform.position.x < -4.27 & transform.position.x > 4.69)) &  collision.gameObject.GetComponent<RanMove>().Iscovid == false  ){
       Debug.Log("asdasda");
        float ran = Random.Range(0.0f, 100.0f);
        if( (age <= 9 & ran <= 2.3) || ((age > 9 & age <= 19) & (ran>2.3 & ran <= 7.4)) || ((age > 19 & age <= 29) & (ran>7.4 & ran <= 22.9)) ||((age > 30 & age <= 39) & (ran>22.9 & ran <= 39.8)) || ((age > 40 & age <= 49) & (ran > 39.8 & ran <= 56.2))  || ((age > 50 & age <= 59) & (ran > 56.2 & ran <= 72.6)) || ((age > 60 & age <= 69) & (ran > 72.6 & ran <= 84.5)) || ((age > 70 & age <= 79) & (ran > 84.5 & ran <= 91.5)) || (age >= 80  & ran > 91.5 ))
                  collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
                  collision.gameObject.GetComponent<RanMove>().Iscovid = true;
                    collision.gameObject.GetComponent<RanMove>().day_start += 1;
    }
}



private void death(){
    if(Iscovid == true){
        float ran = Random.Range(0.0f, 100.0f);
        if((age <= 17 && ran <= 0.06) || ((age > 17 & age <= 44)&(ran > 0.06 & ran <= 3.96)) || ((age > 44 & age <= 64)&(ran > 3.96 & ran <= 26.36)) || ((age > 64 & age <= 74)&(ran > 26.36 & ran <= 51.26)) || ((age > 74)&(ran > 51.26 )) ){

            Destroy(gameObject);            
        }
        
    }
}

private void recovery(){

   if(Iscovid == true && day_start >= 14){
       Iscovid = false;
       gameObject.GetComponent<Renderer>().material.color = Color.white;
       day_start = -1;
   }
   

}
}