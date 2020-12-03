using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] Text scoreText;//スコアテキストを挿入
    AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    private int score;
    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;

    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        this.gameoverText = GameObject.Find("GameOverText");
        sceneName = SceneManager.GetActiveScene().name;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent < Text >().text= "Game Over\r\nスペースキー\r\nでリトライ";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "SmallStarTag")
        {
            score += 100;
            audioSource.PlayOneShot(audioClips[0]);
        }
        if (other.gameObject.tag == "LargeStarTag")
        {
            score += 500;
            audioSource.PlayOneShot(audioClips[1]);
        }
        if (other.gameObject.tag == "SmallCloudTag")
        {
            score += 1000;
            audioSource.PlayOneShot(audioClips[2]);
        }
        if (other.gameObject.tag == "LargeCloudTag")
        {
            score += 5000;
            audioSource.PlayOneShot(audioClips[3]);
        }
        scoreText.text = score.ToString();
    }

}
