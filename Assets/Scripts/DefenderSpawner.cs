using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] AudioClip kakashiName;
    [SerializeField] GameObject safeBox;


    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";


    AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
        
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    private void OnMouseDown()
    {
        AttemptToSpawnDefender(MousePosition());
    }
    private Vector2 MousePosition()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = GridPosition(worldPos);
        return gridPos;
    }
    private Vector2 GridPosition(Vector2 rawWorldPos)
    {
        float newXPos = Mathf.RoundToInt(rawWorldPos.x);
        float newYPos = Mathf.FloorToInt(rawWorldPos.y);
        Vector2 gridPos = new Vector2(newXPos,newYPos);
        return gridPos;
    }
    public void AttemptToSpawnDefender(Vector2 gridPos)
    {
        var lifeErgDisplay = FindObjectOfType<LifeEnergyDisplay>();
        int defenderCost = defender.GetLifeEnergyCost();
        if (lifeErgDisplay.isAllowedToSpwan(defenderCost))
        {
            SpawnDefender(gridPos);
            lifeErgDisplay.ReduceLifeEnergy(defenderCost);
        }
        


    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        Defender newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
        //Debug.Log(roundedPos);
    }





















    /// Safe Area///
    private Vector2 SafeArea()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mouseToWorld = Camera.main.ScreenToWorldPoint(mousePos);

        float roundedMousePosX = Mathf.RoundToInt(mouseToWorld.x);
        float roundedMousePosY = Mathf.FloorToInt(mouseToWorld.y);

        Vector2 roundedPos = new Vector2(roundedMousePosX, roundedMousePosY);

       // Debug.Log(roundedPos);

        return roundedPos;
    }
    private void OnMouseOver()
    {
        safeBox.SetActive(true);
        Vector2 safeAreaPos = SafeArea();
        if (SafeArea().y == 0f)
        {
            safeBox.transform.position = new Vector2(SafeArea().x, 1f);
        }
        else
        {
            safeBox.transform.position = SafeArea();
        }
    }
    private void OnMouseExit()
    {
        safeBox.SetActive(false);
    }
}
