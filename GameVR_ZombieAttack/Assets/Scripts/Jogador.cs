using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public Camera PlayerCamera;
    public Light flashLight;
    public TextMesh txtReloading;
    public AudioClip[] Clips;

    private GameObject currentObject;
    private AudioSource _audioSource;

    public bool reloading;

    public static int life;
    public static int bullets;
    public static int score;


    // Start is called before the first frame update
    void Start()
    {
        

        txtReloading.GetComponent<MeshRenderer>().enabled = false;
        _audioSource = GetComponent<AudioSource>();
        PlayerCamera = GetComponent<Camera>();
        flashLight.GetComponent<Light>().enabled = false;

        life = 100;
        bullets = 6;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentObject = Command();

        if(Input.GetButtonDown("Fire1") && !reloading && bullets > 0)
        {
            StartCoroutine(Flashlight());
            _audioSource.clip = Clips[0];
            _audioSource.volume = 0.5f;
            _audioSource.Play();
            bullets--;   
        }
        else if (Input.GetButtonDown("Fire1") && bullets <= 0 && !reloading)
        {
            StartCoroutine(Reload());

        }
        else if (Input.GetButtonDown("Fire1") && reloading)
        {
            _audioSource.clip = Clips[2];
            _audioSource.volume = 0.5f;
            _audioSource.Play();
        }

        if (Input.GetButtonDown("Fire1") && bullets > 0 && currentObject != null)
        {         
            currentObject.GetComponentInParent<ZombieScript>().Damage(currentObject.tag);
        
        }
    }

    IEnumerator Reload()
    {

        reloading = true;
        txtReloading.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        txtReloading.GetComponent<MeshRenderer>().enabled = false;
        bullets = 6;
        reloading = false;
    }

    

    IEnumerator Flashlight()
    {
        flashLight.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        flashLight.GetComponent<Light>().enabled = false;
    }

    GameObject Command()
    {
        Ray ray = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;
        

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit))
            {
                return hit.collider.gameObject;
            }           
        }

        return null;
        
    }
}
