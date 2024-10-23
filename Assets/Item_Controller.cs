using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txt;
    public AudioSource effect;
    void Start()
    {
        Collider2D c;
        if (!GetComponent<Collider2D>())
        {
            c = gameObject.AddComponent<BoxCollider2D>();
        }
        else 
        {
            c = GetComponent<Collider2D>();
        }
        c.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        GameManager.nScore++;
        txt.text = "" + GameManager.nScore;
        
       // AudioSource audio = GetComponent<AudioSource> ();
        effect.Play();

        Destroy(gameObject, 0.5f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
