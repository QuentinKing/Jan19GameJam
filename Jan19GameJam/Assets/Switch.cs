using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public FlameController player;
    public float distanceToActivate = 5.0f;
    public List<MeshRenderer> wires = new List<MeshRenderer>();

    public Material blackWire;
    public Material yellowWire;

    public bool activated = false;

    void Update()
    {
        if (Input.GetButtonDown("Ignite"))
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, this.transform.position);
            if (distanceToPlayer < 5.0f && (activated || player.HasUses()))
            {
                if (activated)
                {
                    Deactivate();
                    player.GainFlame();
                }
                else
                {
                    Activate();
                    player.LoseFlame();
                }
            }
        }
    }

    void Activate()
    {
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        activated = true;

        foreach (MeshRenderer r in wires)
        {
            r.sharedMaterial = yellowWire;
        }
    }

    void Deactivate()
    {
        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        activated = false;

        foreach (MeshRenderer r in wires)
        {
            r.sharedMaterial = blackWire;
        }
    }
}
