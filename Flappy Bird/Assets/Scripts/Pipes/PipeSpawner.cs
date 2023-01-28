using UnityEngine;
using Random = UnityEngine.Random;

namespace Pipes
{
    public class PipeSpawner : MonoBehaviour
    {
        public float PipesSpwaned { get; set; }
        
        [SerializeField] private GameObject[] _pipesDifficultyPrefab;
    
        [SerializeField] private float _spawnRate = 1f;
        [SerializeField] private float _spawnTime = 1f;

        private const float _minHeight = -1f;
        private const float _maxHeight = 1f;

        private float _chanceOfRidingPipe;
        private float _chanceOfTitlePipe = 20f;
    
        private int _difficulty;

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
                    _difficulty = 0;
                    _chanceOfRidingPipe = 0f;
                    _chanceOfTitlePipe = 20f;
                    break;
            
                case Difficulty.Medium:
                    _difficulty = 1;
                    _chanceOfRidingPipe = 20f;
                    _chanceOfTitlePipe = 20f;
                    break;
            
                case Difficulty.Hard:
                    _difficulty = 2;
                    _chanceOfRidingPipe = 30f;
                    _chanceOfTitlePipe = 30f;
                    break;
            
                case Difficulty.Impossible:
                    _difficulty = 3;
                    _chanceOfRidingPipe = 50f;
                    _chanceOfTitlePipe = 30f;
                    break;
            
                case Difficulty.Unreal:
                    _difficulty = 4;
                    _chanceOfRidingPipe = 100f;
                    _chanceOfTitlePipe = 50f;
                    break;
            }
        }
        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), _spawnTime, _spawnRate);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Spawn));
        }

        private void Spawn()
        {
            PipesSpwaned++;
        
            SetDifficulty(GetDifficulty());
        
            GameObject pipes = Instantiate(_pipesDifficultyPrefab[_difficulty], transform.position, Quaternion.identity);
        
            if (Random.Range(0f, 100f) < _chanceOfTitlePipe)
            {
                pipes.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-33f, 33f));
            }
        
            if (Random.Range(0f, 100f) < _chanceOfRidingPipe)
            {
                pipes.GetComponent<PipeRiding>().enabled = true;
            }
        
            pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
        }
    }
}
