﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnStart : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject);
    }
}
