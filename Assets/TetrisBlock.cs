using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TetrisBlock
{
    List<Block> blocks;

    public List<Block> Blocks
    {
        get { return blocks; }
    }
    public TetrisBlock()
        :this(new List<Block>())
    {
    }
    public TetrisBlock(List<Block> blocks)
    {
        this.blocks = blocks;
    }

    public void move(Vector3 movement)
    {
        blocks[0].BlockObject.transform.position += movement;
    }

}