using UnityEngine;
using Random = UnityEngine.Random;

namespace Pipes
{
    public class PipeSpawner : MonoBehaviour
    {
        public float PipesSpwaned { get; set; }
        
        [SerializeField] private GameObject[] pipesDifficultyPrefab;
    
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private float spawnTime = 1f;

        private const float MinHeight = -1f;
        private const float MaxHeight = 1f;

        private float chanceOfRidingPipe;
        private float chanceOfTitlePipe = 20f;
    
        private int difficulty;

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
            if (PipesSpwaned >= 40)
                return Difficulty.Unreal;
        
            if (PipesSpwaned >= 30)
                return Difficulty.Impossible;
        
            if (PipesSpwaned >= 20)
                return Difficulty.Hard;
        
            if (PipesSpwaned >= 10)
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
            PipesSpwaned++;
        
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
        
            pipes.transform.position += Vector3.up * Random.Range(MinHeight, MaxHeight);
        }
    }
}
