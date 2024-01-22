using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public static ChunkManager instance;
    [SerializeField] private LevelSO[] levels;    

    private GameObject finishLine;

    private void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance=this;
        }
    }

    void Start(){
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }    

    private void GenerateLevel(){
        int currentLevel = GetLevel();

        currentLevel %= levels.Length;

        LevelSO level = levels[currentLevel];

        CreateLevel(level.chunks);
    }

    private void CreateLevel(Chunk[] levelChunks){
        Vector3 chunkPosition = Vector3.zero;

        for(int i=0; i<levelChunks.Length; i++){

            Chunk chunkToCreate = levelChunks[i];

            if(i>0){
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate,chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
            
        }
    }


    public float GetFinishZ(){
        return finishLine.transform.position.z;
    }

    public int GetLevel(){
        return PlayerPrefs.GetInt("level", 0);
    }
}




/*private void CreateOrderedLevel(){
        Vector3 chunkPosition = Vector3.zero;

        for(int i=0; i<levelChunks.Length; i++){

            Chunk chunkToCreate = levelChunks[i];

            if(i>0){
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate,chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
            
        }
    }

    private void CreateRandomLevel(){
        Vector3 chunkPosition = Vector3.zero;

        for(int i=0; i<10; i++){

            Chunk chunkToCreate = chunkPrefabs[Random.Range(0,chunkPrefabs.Length)];

            if(i>0){
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate,chunkPosition, Quaternion.identity, transform);

            chunkPosition.z += chunkInstance.GetLength() / 2;
            
        }
    }*/