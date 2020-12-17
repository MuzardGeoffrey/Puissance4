using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public List<ChoiseButton> choiseButtons;
    public int BlockActif; 
    private float Cooldown;
    public GameGestion GameGestion;
    private Color ColorJeton;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < choiseButtons.Count; i++)
        {
            choiseButtons[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            BlockActif = 0;
        }
        choiseButtons[0].gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        BlockActif = 0;
        Cooldown = 0;
        ColorJeton = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        choiseColumn();
        if (Cooldown <= 0)
        {
            summonJeton();
            
        }
        Cooldown -= Time.deltaTime;
    }

    private void choiseColumn()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (BlockActif != 6)
            {
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                BlockActif++;
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (BlockActif != 0)
            {
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                BlockActif--;
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }

    private void summonJeton()
    {
        switch (GameGestion.PlayerTurn)
        {
            case 1:
                ColorJeton = Color.red;
                break;
            case 2:
                ColorJeton = Color.yellow;
                break;
            default:

                break;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Cooldown = 1;
            choiseButtons[BlockActif].SummunJeton(ColorJeton);
            GameGestion.Playjeton(BlockActif);
        }
        
    }
}
