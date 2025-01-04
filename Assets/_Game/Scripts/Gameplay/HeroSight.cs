using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Transform barrierPoint;
    private List<Zombie> listCharacterInSight = new();

    private void Awake()
    {
        if (character is MeleeHero || character is Zombie)
        {
            character.SetTargetPos(barrierPoint);
        }
        if (character is GunHero)
        {
            character.SetTargetPos(null);
        }
    }

/*    private void LateUpdate()
    {
        if(hero is GunHero)
        {
            Debug.Log(listZombieInSight.Count());
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            if(!listCharacterInSight.Contains(other.GetComponent<Zombie>()))
            {
                listCharacterInSight.Add(other.GetComponent<Zombie>());
            }
            character.SetTargetPos(listCharacterInSight[0].transform);
        }
        Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            listCharacterInSight.Remove(other.GetComponent<Zombie>()); 
            if (character is MeleeHero &&  listCharacterInSight.Count == 0)
            {
                character.SetTargetPos(barrierPoint.transform);
            }
            if (character is GunHero)
            {
                if(listCharacterInSight.Count != 0)
                {
                    character.SetTargetPos(listCharacterInSight[0].transform);
                }
                else
                {
                    character.SetTargetPos(null);
                }
            }
        }
    }
}
