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
    public float timeCounted;
    
    // Start is called before the first frame update
    void Start()
    {
        chicken = Resources.LoadAll("SFX/chicken",typeof(AudioClip));
        drop = Resources.LoadAll("SFX/drop", typeof(AudioClip));
        source = GetComponent<AudioSource>();
        findObjectGameController = GameObject.Find("GameController"); // get GameController Script because we want to access the GameController Component
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        timeCounted = findObjectGameController.GetComponent<GameController>().timeLeft; // we want to update timeLeft from GameCOntroller because when time left is zero, chickens are not allowed to give birth.
    }
    
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);
        while (timeCounted > 0)
        {
            Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            var sound = (AudioClip)chicken[Random.Range(0, chicken.Length)];
            // Play sound

            sound = (AudioClip)drop[Random.Range(0, drop.Length)];
            source.PlayOneShot(sound,(float)0.5);
            source.PlayOneShot(sound);

            Instantiate(egg, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 2.0f));
        }
        
    }
    
}
