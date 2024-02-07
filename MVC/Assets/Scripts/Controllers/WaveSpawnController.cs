using System;
using System.Collections;
using MVC.Capabilities;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MVC.Controllers
{
    public class WaveSpawnController : MonoBehaviour
    {
        public enum SpawnState
        {
            Spawning,
            Waiting,
            Counting,
            Finished
        }

        [Serializable]
        public class Wave
        {
            public string name;
            public Targetable enemy;

            [Range(0, 50)]
            public int count;

            [Range(0, 1)]
            public float spawnRate;
        }

        [BoxGroup("Waves"), SerializeField]
        private Wave[] _waves;

        [BoxGroup("Settings"), Range(0, 60), SuffixLabel("seconds"), SerializeField]
        private float _timeBetweenWaves, _searchCountdown;

        [BoxGroup("Spawn Points"), SerializeField]
        private Transform[] _spawnPoints;

        [BoxGroup("UI"), SerializeField]
        private TextMeshProUGUI _waveCounterText, _remainingEnemiesText;

        private float _waveCountdown;
        private int _nextWave = 0;
        private SpawnState _state = SpawnState.Counting;

        public UnityEvent onAllWavesCompleted;

        private void Start()
        {
            _waveCountdown = _timeBetweenWaves;
        }

        private void Update()
        {
            if (_state == SpawnState.Waiting)
            {
                if (AreEnemiesDead())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (_state == SpawnState.Finished)
            {
                return;
            }

            if (_waveCountdown <= 0)
            {
                if (_state != SpawnState.Spawning)
                {
                    StartCoroutine(SpawnWave(_waves[_nextWave]));
                }

                _remainingEnemiesText.SetText($"Enemies: {GameController.Instance.Enemies.Count}");
            }
            else
            {
                _waveCounterText.SetText($"Loading Next Wave");
                _remainingEnemiesText.SetText("");

                _waveCountdown -= Time.deltaTime;
            }

        }

        private IEnumerator SpawnWave(Wave wave)
        {
            _waveCounterText.SetText($"{wave.name}");

            _state = SpawnState.Spawning;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);

                yield return new WaitForSeconds(1 / wave.spawnRate);
            }

            _state = SpawnState.Waiting;

            yield break;
        }

        private void SpawnEnemy(Targetable enemy)
        {
            Targetable enemyInstance = ObjectPoolController.Instance.GetPooledObject<Targetable>(enemy.name, _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].transform.position);
            GameController.Instance.Enemies.Add(enemyInstance);
        }

        private bool AreEnemiesDead()
        {
            print(_searchCountdown);

            _searchCountdown -= Time.deltaTime;
            if (_searchCountdown <= 0f)
            {
                _searchCountdown = 1f;
                if (GameController.Instance.Enemies.Count <= 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void WaveCompleted()
        {
            _state = SpawnState.Counting;
            _waveCountdown = _timeBetweenWaves;

            if (_nextWave + 1 > _waves.Length - 1)
            {
                _state = SpawnState.Finished;

                _waveCounterText.SetText($"Finished");
                _remainingEnemiesText.SetText("");

                onAllWavesCompleted?.Invoke();
            }
            else
            {
                _nextWave++;
            }
        }
    }
}