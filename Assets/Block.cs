using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Block
{
    public Vector3 offset;
    public GameObject blockObject;

    public Block(GameObject blockObject, Vector3 offset)
    {
        this.offset = offset;
        this.blockObject = blockObject;
    }
}