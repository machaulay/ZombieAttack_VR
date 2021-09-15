using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuVR : MonoBehaviour
{
    Camera _camera;


    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 100.0f, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            //Ray ray = _camera.ScreenPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);

            //if(Physics.Raycast(ray, out hit))
            //{
            //    if(hit.collider.tag == "BT-Iniciar")
            //    {
            //        SceneManager.LoadScene("GameScene");
            //    }
            //}

            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 100.0f))
            {
                if (hit.collider.tag == "BT-Iniciar")
                {
                    SceneManager.LoadScene("GameScene");
                }

            }
        }
    }
}
