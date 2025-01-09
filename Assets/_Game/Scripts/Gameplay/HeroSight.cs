using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroSight : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Transform barrierPoint;
    private readonly List<Character> listTargetInsight = new();

    private void Start()
    {
       
        if (character is PistolHero)
        {
            character.MoveToTarget(null);
        }
        else
        {
            character.MoveToTarget(barrierPoint);
        }
    }

    private void LateUpdate()
    {
        if (character is Zombie)
        {
            Debug.Log(listTargetInsight.Count());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // sight of hero
        if (other.CompareTag("Zombie"))
        {
            if(!listTargetInsight.Contains(other.GetComponent<Character>()))
            {
                listTargetInsight.Add(other.GetComponent<Character>());
            }
            character.MoveToTarget(listTargetInsight[0].transform);
        }
        // sight of zombie
        if(other.CompareTag("Hero"))
        {
            /*if (!listTargetInsight.Contains())
            {
                listTargetInsight.Add(other.GetComponent<Character>());
            }*/
            if (!listTargetInsight.Contains(other.GetComponent<Character>()))
            {
                listTargetInsight.Add(other.GetComponent<Character>());
            }
            character.MoveToTarget(listTargetInsight[0].transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            listTargetInsight.Remove(other.GetComponent<Character>()); 
            if (character is MeleeHero &&  listTargetInsight.Count == 0)
            {
                character.MoveToTarget(barrierPoint.transform);
            }
            if (character is PistolHero)
            {
                if(listTargetInsight.Count != 0)
                {
                    character.MoveToTarget(listTargetInsight[0].transform);
                }
                else
                {
                    character.MoveToTarget(null);
                }
            }
        }
        if (other.CompareTag("Hero"))
        {
            /*if (!listTargetInsight.Contains())
            {
                listTargetInsight.Add(other.GetComponent<Character>());
            }*/
            character.SetTargetPos(barrierPoint);
        }
    }
}
