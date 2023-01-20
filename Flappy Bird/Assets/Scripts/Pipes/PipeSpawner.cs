using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pipesDifficultyPrefab;
    
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnTime = 1f;
    
    public float pipesSpwaned { get; set; }
    
    private float minHeight = -1f;
    private float maxHeight = 1f;

    private float chanceOfRidingPipe = 0f;
    private float chanceOfTitlePipe = 20f;
    
    private int difficulty = 0;

    private void Awake()
    {
        SetDifficulty(Difficulty.Easy);
    }

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible,
        Unreal,
    }
    
    private Difficulty GetDifficulty()
    {
        if (pipesSpwaned >= 40)
            return Difficulty.Unreal;
        
        if (pipesSpwaned >= 30)
            return Difficulty.Impossible;
        
        if (pipesSpwaned >= 20)
            return Difficulty.Hard;
        
        if (pipesSpwaned >= 10)
            return Difficulty.Medium;
        
        return Difficulty.Easy;
    }

    private void SetDifficulty(Difficulty gameDifficulty)
    {
        switch (gameDifficulty)
        {
            case Difficulty.Easy:
                difficulty = 0;
                chanceOfRidingPipe = 0f;
                chanceOfTitlePipe = 20f;
                break;
            
            case Difficulty.Medium:
                difficulty = 1;
                chanceOfRidingPipe = 20f;
                chanceOfTitlePipe = 20f;
                break;
            
            case Difficulty.Hard:
                difficulty = 2;
                chanceOfRidingPipe = 30f;
                chanceOfTitlePipe = 30f;
                break;
            
            case Difficulty.Impossible:
                difficulty = 3;
                chanceOfRidingPipe = 50f;
                chanceOfTitlePipe = 30f;
                break;
            
            case Difficulty.Unreal:
                difficulty = 4;
                chanceOfRidingPipe = 100f;
                chanceOfTitlePipe = 50f;
                break;
        }
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnTime, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        pipesSpwaned++;
        
        SetDifficulty(GetDifficulty());
        
        GameObject pipes = Instantiate(pipesDifficultyPrefab[difficulty], transform.position, Quaternion.identity);
        
        if (Random.Range(0f, 100f) < chanceOfTitlePipe)
        {
            pipes.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-33f, 33f));
        }
        
        if (Random.Range(0f, 100f) < chanceOfRidingPipe)
        {
            pipes.GetComponent<PipeRiding>().enabled = true;
        }
        
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
