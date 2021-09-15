using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    int life;
    float speed;
    bool walking;

    AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        life = Random.Range(1, 6);
        speed = 0.35f;
        walking = true;
    }

    void Update()
    {
        if(walking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        }


        if(life <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void Damage(string _tag)
    {
        if(_tag == "Corpo")
        {
            life--;
        }else if(_tag == "Cabeca")
        {
            life = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Jogador.life--;
            life = 0;
        }
        
    }

    
    
}
