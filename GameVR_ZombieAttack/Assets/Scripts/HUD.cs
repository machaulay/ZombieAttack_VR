using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public TextMesh txt_life;
    public TextMesh txt_bullet;
    public TextMesh txt_score;

    void Start()
    {
        
    }

    void Update()
    {
        txt_life.text = Jogador.life + "%";
        txt_bullet.text = Jogador.bullets.ToString();
        txt_score.text = Jogador.score.ToString();
    }
}
