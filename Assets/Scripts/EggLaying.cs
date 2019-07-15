using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggLaying : MonoBehaviour
{
    public GameObject egg;
    private AudioSource source;
    private Object[] drop;
    private Object[] chicken;
    public GameObject findObjectGameController;
    
    // Start is called before the first frame update
    void Start()
    {
        chicken = Resources.LoadAll("SFX/chicken",typeof(AudioClip));
        drop = Resources.LoadAll("SFX/drop", typeof(AudioClip));
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void LayEgg()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
        Quaternion spawnRotation = Quaternion.identity;

        // Play sound
        var sound = (AudioClip)chicken[Random.Range(0, chicken.Length)];
        source.PlayOneShot(sound, (float)0.5);
        sound = (AudioClip)drop[Random.Range(0, drop.Length)];
        source.PlayOneShot(sound);
        transform.parent.transform.GetComponent<Animator>().SetTrigger("givingBirth");
        Instantiate(egg, spawnPosition, spawnRotation);
    }
    
}
