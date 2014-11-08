using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TetrisManagerScript : MonoBehaviour {
    
    public const int MAP_WIDTH = 10;
    public const int MAP_HEIGHT = 20;

    Block[,] map;
    public GameObject SampleBlock;
    TetrisBlock currentMovingBlock;
    float lastSpawnedBlockTime = 0;

	// Use this for initialization
	void Start () {
        this.map = new Block[MAP_WIDTH, MAP_HEIGHT];
        for(int x = 0; x < MAP_WIDTH; ++x)
        {
            for (int y = 0; y < MAP_HEIGHT; ++y)
            {
                map[x, y] = null;
            }
        }
        currentMovingBlock = spawnTetrisBlock();
    }
	
	// Update is called once per frame
	void Update () 
    {
        //currentMovingBlock.move(new Vector3(0.1f, 0, 0));
        //lastSpawnedBlockTime += Time.deltaTime;
        //if(lastSpawnedBlockTime > 1)
        //{
        //    currentMovingBlock = spawnTetrisBlock();
        //    lastSpawnedBlockTime = 0;
        //}
	}

    private Vector3 offset2DToVector3D(Vector2 offset)
    {
        return new Vector3(-offset.y,0,offset.x);
    }

    private TetrisBlock spawnTetrisBlock()
    {
        Vector3 startPosition = new Vector3();
        List<Block> blocks = new List<Block>();
        Block[,] blocksMap = new Block[4, 2];
        List<Vector2> possiblePositions = new List<Vector2>();
        blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition, Quaternion.identity), new Vector3()));
        blocksMap[1, 0] = blocks[0];
        possiblePositions.Add(new Vector2(0, 0));
        possiblePositions.Add(new Vector2(1, 1));
        possiblePositions.Add(new Vector2(2, 0));
        System.Random random = new System.Random();
        for(int i = 1; i < 4; ++i)
        {
            int positionIndex = random.Next(possiblePositions.Count);
            Vector2 position = possiblePositions[positionIndex];
            possiblePositions.RemoveAt(positionIndex);

            Vector2 offset = position - new Vector2(1,0);

            blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition + offset2DToVector3D(offset), Quaternion.identity), offset2DToVector3D(offset)));
            blocks[i].blockObject.transform.parent = blocks[0].blockObject.transform;

            blocksMap[(int)position.x, (int)position.y] = blocks[i];

            for (int x = -1; x < 2; ++x)
            {
                for (int y = -1; y < 2; ++y)
                {
                    Vector2 currentPosition = position + new Vector2(x, y);
                    if(currentPosition.x >= 0 && currentPosition.x <= 3 &&currentPosition.y >= 0 && currentPosition.y <= 1)
                    {
                        if (blocksMap[(int)currentPosition.x, (int)currentPosition.y] == null)
                        {
                            possiblePositions.Add(new Vector2(currentPosition.x, currentPosition.y));
                        }
                    }
                }
            }
        }

        TetrisBlock newBlock = new TetrisBlock(blocks);
        return newBlock;
    }
}
