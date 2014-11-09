using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Block
{
    private GameObject blockObject;
    private Vector3 offset;

    public Vector3 Offset
    {
        get { return offset; }
    }
    public GameObject BlockObject
    {
        get { return blockObject; }
    }

    public Block(GameObject blockObject, Vector3 offset)
    {
        this.blockObject = blockObject;
        this.offset = offset;
    }
}