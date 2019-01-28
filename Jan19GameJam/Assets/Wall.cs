using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public List<Switch> switches = new List<Switch>();
    public MeshRenderer renderer;

    private void Update()
    {
        bool isActive = false;
        foreach (Switch s in switches)
        {
            if (s.activated)
            {
                isActive = true;
            }
        }

        if (isActive)
        {
            renderer.enabled = false;
        }
        else
        {
            renderer.enabled = true;
        }
    }
}
