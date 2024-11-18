using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    private PlayerManager player;

    [HideInInspector]
    public bool Recogido;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerManager>();
    }
    
    public void UsoItem()
    {
        if(ID == 1)
        {
            player.CuracionMedKit();
        }

        if(ID == 2)
        {
            player.CuracionMata();
        }
    }

    

}
