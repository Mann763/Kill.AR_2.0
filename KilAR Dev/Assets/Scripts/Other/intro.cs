using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public VideoPlayer Vplayer;
    public Animator Anim;

    float Tframes;
    // Start is called before the first frame update
    void Start()
    {
        Vplayer = GetComponent<VideoPlayer>();
        Tframes = Vplayer.frameCount;
        Anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vplayer.frame >= Tframes)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Anim.SetTrigger("Start");
        }
    }
}
