using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Threading.Tasks;
public class AddBananaDucks : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Transform bananaDucks;
    private List<Transform> followers;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        followers = new List<Transform>();
        followers.Add(this.transform);
        score=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void savescore()
    {
        string text = "2";

        //fr.WriteAllText("score.txt", text);
    }

    private void addFollowers()
    {
        Transform bananaDuck = Instantiate(this.bananaDucks);

        bananaDuck.position = followers[followers.Count - 1].position;

        followers.Add(bananaDuck);
    }
    private void FixedUpdate(){
        for(int i =followers.Count - 1; i > 0; i--){
            followers[i].position = followers[i-1].position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(score);
        if(other.tag == "BananaDuck")
        {
            Debug.Log("Duck");
            addFollowers();   
        }

        if(other.tag=="Pollution"){
            if(followers.Count==1){
                Debug.Log("gameover");
                
                savescore();

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                double Third=Mathf.Round(followers.Count/3)+1;
                Destroy(followers[followers.Count-1].gameObject);
                followers.RemoveAt(followers.Count-1);
                for(int i=1;i<Third;i++){
                    Destroy(followers[followers.Count-1].gameObject);
                    followers.RemoveAt(followers.Count-1);
                }

            }
        }
        if(other.tag=="Coupe"){
           for(int i =followers.Count - 1; i > 0; i--){
               followers[i].position = new Vector3(12,4,0);
               Destroy(followers[i].gameObject);
                followers.RemoveAt(i);
                score +=1;
                scoreText.text = "Score: " + score;
            }
        }
    }

}
