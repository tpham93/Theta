using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TetrisManagerScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public const int MAP_WIDTH = 10;
    public const int MAP_HEIGHT = 5;
    public const int MAP_LENGTH = 20;

    GameObject[] players;
    Block[, ,] map;
    public GameObject SampleBlock;
    TetrisBlock currentMovingBlock;
    float lastSpawnedBlockTime = 0;
    System.Random random = new System.Random();

    // Use this for initialization
    void Start()
    {
        random = new System.Random();
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

        List<Vector3> possibleSpawnLocations = new List<Vector3>();

        for (int i = 0; i < 4; ++i)
        {
            Vector3 pos = new Vector3();
            do
            {
                pos = new Vector3(random.Next(MAP_WIDTH), 0.0f, random.Next(2));
            } while (map[(int)pos.x, (int)pos.y, (int)pos.z] != null);
            pos.Scale(SampleBlock.transform.lossyScale);
            pos += new Vector3(0, 0, SampleBlock.transform.lossyScale.z / 2);
            GameObject blockObject = (GameObject)GameObject.Instantiate(SampleBlock, pos, Quaternion.identity);
            map[(int)pos.x, (int)pos.y, (int)pos.z] = new Block(blockObject, new Vector3());
            possibleSpawnLocations.Add(pos);
        }
        for (int x = 0; x < MAP_WIDTH; ++x)
        {
            for (int z = 0; z < 2; ++z)
            {
                Vector3 pos = new Vector3(x, 0.0f, z);
                if (map[(int)pos.x, (int)pos.y, (int)pos.z] == null  && random.NextDouble() < 0.6)
                {
                    pos.Scale(SampleBlock.transform.lossyScale);
                    pos += new Vector3(0, 0, SampleBlock.transform.lossyScale.z / 2);
                    GameObject blockObject = (GameObject)GameObject.Instantiate(SampleBlock, pos, Quaternion.identity);
                    map[(int)pos.x, (int)pos.y, (int)pos.z] = new Block(blockObject, new Vector3());
                }
            }
        }

        GameObject[] playerPrefab = { player1, player2, player3, player4 };
        players = new GameObject[4];
        for (int i = 0; i < 4; ++i)
        {
            int locationIndex = random.Next(possibleSpawnLocations.Count);
            Vector3 spawnLocation = possibleSpawnLocations[locationIndex];
            possibleSpawnLocations.RemoveAt(locationIndex);

            players[i] = (GameObject)GameObject.Instantiate(playerPrefab[i], spawnLocation + new Vector3(0,1,0), Quaternion.identity);
        }

        currentMovingBlock = null;
    }

    // Update is called once per frame
    void Update()
    {
        bool hasToStop = false;
        Vector3 moveOffset = new Vector3(0.0f, 0.0f, -0.1f * SampleBlock.transform.lossyScale.z);

        if (currentMovingBlock == null)
        {
            currentMovingBlock = spawnTetrisBlock(new Vector3(0, 0, 0));
            Rect bounds = currentMovingBlock.getBounds();
            currentMovingBlock.move(new Vector3(-bounds.x, 0, bounds.y + MAP_LENGTH * SampleBlock.transform.lossyScale.z));
            currentMovingBlock.move(new Vector3((int)(Random.Range(0.0f, MAP_WIDTH - bounds.width)) * SampleBlock.transform.lossyScale.x, 0, 0));
        }

        for (int i = 0; i < currentMovingBlock.Blocks.Count; ++i)
        {
            Block currentBlock = currentMovingBlock.Blocks[i];
            Vector3 scale = currentBlock.BlockObject.transform.lossyScale;
            Vector3 currentBlockLeftBottom = currentBlock.BlockObject.transform.position;
            Vector3 mapCoordinate = new Vector3(currentBlockLeftBottom.x / scale.x, currentBlockLeftBottom.y / scale.y, (currentBlockLeftBottom.z + moveOffset.z - scale.z / 2) / scale.z);
            hasToStop |= (mapCoordinate.z) < 0 || ((int)(mapCoordinate.z) < MAP_LENGTH && map[(int)(mapCoordinate.x), (int)(mapCoordinate.y), (int)(mapCoordinate.z)] != null);
        }

        if (hasToStop)
        {
            Vector3 startPosition = currentMovingBlock.Blocks[0].BlockObject.transform.position;
            for (int i = 0; i < currentMovingBlock.Blocks.Count; ++i)
            {
                Block currentBlock = currentMovingBlock.Blocks[i];

                Vector3 scale = currentBlock.BlockObject.transform.lossyScale;
                Vector3 currentBlockLeftBottom = currentBlock.BlockObject.transform.position;
                Vector3 mapCoordinate = new Vector3(currentBlockLeftBottom.x / scale.x, currentBlockLeftBottom.y / scale.y, (currentBlockLeftBottom.z) / scale.z);
                map[(int)(mapCoordinate.x), (int)(mapCoordinate.y), (int)(mapCoordinate.z)] = currentBlock;
            }
            currentMovingBlock = null;
        }
        else
        {
            currentMovingBlock.move(moveOffset);
        }

        for (int i = 0; i < 4; ++i)
        {
            if (!players[i].transform.FindChild("vypp").animation.isPlaying)
            {
                players[i].transform.FindChild("vypp").animation.Play("Walk", PlayMode.StopAll);
            }
        }

    }



    private Vector3 offset2DToVector3D(Vector2 offset)
    {
        return new Vector3(offset.x * SampleBlock.transform.lossyScale.x, 0, offset.y * SampleBlock.transform.lossyScale.y);
    }

    private TetrisBlock spawnTetrisBlock(Vector3 startPosition)
    {
        List<Block> blocks = new List<Block>();
        Block[,] blocksMap = new Block[4, 4];
        List<Vector2> possiblePositions = new List<Vector2>();
        blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition, Quaternion.identity), Vector3.zero));
        blocksMap[1, 1] = blocks[0];
        possiblePositions.Add(new Vector2(1, 0));
        possiblePositions.Add(new Vector2(0, 1));
        possiblePositions.Add(new Vector2(2, 1));
        possiblePositions.Add(new Vector2(1, 2));

        for (int i = 1; i < 4; ++i)
        {
            int positionIndex = random.Next(possiblePositions.Count);
            Vector2 position = possiblePositions[positionIndex];
            possiblePositions.RemoveAt(positionIndex);

            Vector2 offset = position - new Vector2(1, 1);
            Vector3 worldOffset = offset2DToVector3D(offset);

            blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition + worldOffset, Quaternion.identity), worldOffset));
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
            int stackingNum = random.Next(MAP_HEIGHT - 1);
            for (int s = 1; s <= stackingNum; ++s)
            {
                Vector3 worldOffset = blocks[i].Offset + new Vector3(0,s,0);
                blocks.Add(new Block((GameObject)GameObject.Instantiate(SampleBlock, startPosition + worldOffset, Quaternion.identity), worldOffset));
            blocks[blocks.Count - 1].BlockObject.transform.parent = blocks[0].BlockObject.transform;
            }
        }
        TetrisBlock newBlock = new TetrisBlock(blocks);
        return newBlock;
    }
}
