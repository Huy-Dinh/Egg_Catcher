using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLaying : MonoBehaviour
{
    public GameObject ball;
    private AudioSource source;
    private Object[] drop;
    private Object[] chicken;
    // Start is called before the first frame update
    void Start()
    {
        chicken = Resources.LoadAll("SFX/chicken",typeof(AudioClip));
        drop = Resources.LoadAll("SFX/drop", typeof(AudioClip));
        source = GetComponent<AudioSource>();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);

            // Play sound
            var sound = (AudioClip)chicken[Random.Range(0, chicken.Length)];
            source.PlayOneShot(sound,(float)0.5);
            sound = (AudioClip)drop[Random.Range(0, drop.Length)];
            source.PlayOneShot(sound);

            yield return new WaitForSeconds(UnityEngine.Random.Range(3.0f, 6.0f));
        }
    }
}
