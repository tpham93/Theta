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

    public Rect getBounds()
    {
        Vector3 min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        Vector3 max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

        for (int i = 0; i < 4; ++i )
        {
            if (blocks[i].Offset.x < min.x)
            {
                min.x = blocks[i].Offset.x;
            }
            if (blocks[i].Offset.y < min.y)
            {
                min.y = blocks[i].Offset.y;
            }
            if (blocks[i].Offset.z < min.z)
            {
                min.z = blocks[i].Offset.z;
            }


            if (blocks[i].Offset.x > max.x)
            {
                max.x = blocks[i].Offset.x;
            }
            if (blocks[i].Offset.y > max.y)
            {
                max.y = blocks[i].Offset.y;
            }
            if (blocks[i].Offset.z > max.z)
            {
                max.z = blocks[i].Offset.z;
            }
        }
        float x = min.x;
        float y = min.z;
        float width = max.x - min.x;
        float height = max.z - min.z;

        return new Rect(x,y, width, height);
    }

    public void move(Vector3 movement)
    {
        blocks[0].BlockObject.transform.position += movement;
    }

} 