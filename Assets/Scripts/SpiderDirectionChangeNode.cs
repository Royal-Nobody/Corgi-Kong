using System;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDirectionChangeNode : MonoBehaviour
{
    public List<SpiderMovement.MovementDirection> possibleDirections;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spider")
        {
            SpiderMovement spiderCode = other.gameObject.GetComponent<SpiderMovement>();
            
            spiderCode.SwitchDirection(PickRandomDirection());
        }
    }
    
    public SpiderMovement.MovementDirection PickRandomDirection()
    {
        return possibleDirections[UnityEngine.Random.Range(0, possibleDirections.Count)];
    }
}
