using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TetrisBlock
{
    List<Block> blocks;
    public TetrisBlock()
        :this(new List<Block>())
    {
    }
    public TetrisBlock(List<Block> blocks)
    {
        this.blocks = blocks;
    }

    public void BasicMovement(Vector3 movement)
    {
        blocks[0].blockObject.transform.position += movement;
    }
}