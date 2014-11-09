using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TetrisManagerScript : MonoBehaviour
{

    public const int MAP_WIDTH = 10;
    public const int MAP_HEIGHT = 5;
    public const int MAP_LENGTH = 20;

    Block[, ,] map;
    public GameObject SampleBlock;
    TetrisBlock currentMovingBlock;
    float lastSpawnedBlockTime = 0;

    // Use this for initialization
    void Start()
    {
        this.map = new Block[MAP_WIDTH, MAP_HEIGHT, MAP_LENGTH];
        for (int x = 0; x < MAP_WIDTH; ++x)
        {
            for (int y = 0; y < MAP_HEIGHT; ++y)
            {
                for (int z = 0; z < MAP_HEIGHT; ++z)
                {
                    map[x, y, z] = null;
                }
            }
        }
        currentMovingBlock = spawnTetrisBlock(new Vector3(SampleBlock.transform.lossyScale.x, 0, 20 * SampleBlock.transform.lossyScale.z));
    }

    // Update is called once per frame
    void Update()
    {
        //lastSpawnedBlockTime += Time.deltaTime;
        //if (lastSpawnedBlockTime > 2)
        //{
        //    currentMovingBlock = spawnTetrisBlock(new Vector3(0, 0,20));
        //    lastSpawnedBlockTime = 0;
        //}
        bool hasToStop = false;
        Vector3 moveOffset = new Vector3(0.0f, 0.0f, -0.1f * SampleBlock.transform.lossyScale.z);
        for (int i = 0; i < currentMovingBlock.Blocks.Count; ++i)
        {
            Block currentBlock = currentMovingBlock.Blocks[i];
            Vector3 scale = currentBlock.BlockObject.transform.lossyScale;
            Vector3 currentBlockLeftBottom = currentBlock.BlockObject.transform.position;
            Vector3 mapCoordinate = new Vector3(currentBlockLeftBottom.x / scale.x, currentBlockLeftBottom.y / scale.y, (currentBlockLeftBottom.z + moveOffset.z - scale.z/2) / scale.z);
            hasToStop |= (mapCoordinate.z) < 0 || ((int)(mapCoordinate.z) < MAP_LENGTH && map[(int)(mapCoordinate.x), (int)(mapCoordinate.y), (int)  (mapCoordinate.z)] != null);
        }

        if (hasToStop)
        {
            Vector3 startPosition = currentMovingBlock.Blocks[0].BlockObject.transform.position;
            for (int i = 0; i < currentMovingBlock.Blocks.Count; ++i)
            {
                Block currentBlock = currentMovingBlock.Blocks[i];

                Vector3 scale = currentBlock.BlockObject.transform.lossyScale;
                Vector3 currentBlockLeftBottom = currentBlock.BlockObject.transform.position;
                Vector3 mapCoordinate = new Vector3(currentBlockLeftBottom.x / scale.x, currentBlockLeftBottom.y / scale.y, (currentBlockLeftBottom.z - scale.z/2) / scale.z);
                map[(int)(mapCoordinate.x), (int)(mapCoordinate.y), (int)(mapCoordinate.z)] = currentBlock;
            }
            currentMovingBlock = spawnTetrisBlock(new Vector3(SampleBlock.transform.lossyScale.x, 0, 20 * SampleBlock.transform.lossyScale.z));
        }
        else
        {
            currentMovingBlock.move(moveOffset);
        }
        Debug.Log("NEWLINE");
        for (int y = 0; y < MAP_LENGTH; ++y)
        {
            String line = "";

            for (int x = 0; x < MAP_WIDTH; ++x)
            {
                line += map[x,0,MAP_LENGTH - y - 1] == null? '_' : 'x';
            }
            Debug.Log(line);
        }
    }



    private Vector3 offset2DToVector3D(Vector2 offset)
    {
        return new Vector3(offset.x * SampleBlock.transform.lossyScale.x, 0, offset.y * SampleBlock.transform.lossyScale.y);
    }

    private TetrisBlock spawnTetrisBlock(Vector3 startPosition)
    {
        List<Block> blocks = new List<Block>();
        Block[,] blocksMap = new Block[4, 2];
        List<Vector2> possiblePositions = new List<Vector2>();
        blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition, Quaternion.identity), Vector3.zero));
        blocksMap[1, 0] = blocks[0];
        possiblePositions.Add(new Vector2(0, 0));
        possiblePositions.Add(new Vector2(1, 1));
        possiblePositions.Add(new Vector2(2, 0));
        System.Random random = new System.Random();
        for (int i = 1; i < 4; ++i)
        {
            int positionIndex = random.Next(possiblePositions.Count);
            Vector2 position = possiblePositions[positionIndex];
            possiblePositions.RemoveAt(positionIndex);

            Vector2 offset = position - new Vector2(1, 0);

            blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition + offset2DToVector3D(offset), Quaternion.identity), offset2DToVector3D(offset)));
            blocks[blocks.Count - 1].BlockObject.transform.parent = blocks[0].BlockObject.transform;
            blocksMap[(int)position.x, (int)position.y] = blocks[i];

            for (int x = -1; x < 2; ++x)
            {
                for (int y = -1; y < 2; ++y)
                {
                    Vector2 currentPosition = position + new Vector2(x, y);
                    if (currentPosition.x >= 0 && currentPosition.x <= 3 && currentPosition.y >= 0 && currentPosition.y <= 1 && (x == 0 || y == 0))
                    {
                        if (blocksMap[(int)currentPosition.x, (int)currentPosition.y] == null)
                        {
                            possiblePositions.Add(new Vector2(currentPosition.x, currentPosition.y));
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 4; ++i)
        {
            int numStackingBlocks = (int)(random.NextDouble() * random.NextDouble() * random.NextDouble() * MAP_HEIGHT);
            for (int s = 1; s <= numStackingBlocks; ++s)
            {
                blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, blocks[i].BlockObject.transform.position + new Vector3(0, s * SampleBlock.transform.lossyScale.y, 0), Quaternion.identity), offset2DToVector3D(new Vector3(0, s))));
                blocks[blocks.Count - 1].BlockObject.transform.parent = blocks[i].BlockObject.transform;
            }
        }

        TetrisBlock newBlock = new TetrisBlock(blocks);
        return newBlock;
    }
}
