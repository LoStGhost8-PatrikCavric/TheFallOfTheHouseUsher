using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLight : MonoBehaviour
{
    public GameObject Player;
    public bool PickedUp = false;
    public bool InRange;
    public float checkRadius;
    public LayerMask PlayerMask;

    public void Update()
    {

        if (PickedUp)
        {
            gameObject.transform.SetParent(Player.transform);
        }
        else if(!PickedUp)
        {
            gameObject.transform.SetParent(null);
        }

        if (Physics2D.Raycast(transform.position, Vector2.left, checkRadius, PlayerMask) || Physics2D.Raycast(transform.position, Vector2.up, checkRadius, PlayerMask) || Physics2D.Raycast(transform.position, Vector2.right, checkRadius, PlayerMask) || Physics2D.Raycast(transform.position, Vector2.down, checkRadius, PlayerMask)) InRange = true;


        if (Input.GetKeyDown(KeyCode.E) && !PickedUp && InRange) PickedUp = true;
        else if (Input.GetKeyDown(KeyCode.E) && PickedUp) PickedUp = false;
    }


}
