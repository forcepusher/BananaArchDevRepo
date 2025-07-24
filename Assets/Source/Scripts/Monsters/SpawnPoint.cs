using System;
using System.Collections;
using UnityEngine;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private SpawnSequence _spawnSequence;

        private IEnumerator _spawnPacksCoroutine;

        public bool SpawnSequenceFinished { get; private set; } = false;

        private void Start()
        {
            _spawnPacksCoroutine = _spawnSequence.SpawnPacksCoroutineFixedTime(Time.fixedDeltaTime, transform.position);
        }

        private void FixedUpdate()
        {
            if (SpawnSequenceFinished)
                return;

            if (!_spawnPacksCoroutine.MoveNext())
                SpawnSequenceFinished = true;
        }

        public void OverrideSpawnSequence(SpawnSequence spawnSequence)
        {
            if (_spawnPacksCoroutine != null)
                throw new InvalidOperationException($"Nope, too late to override. {nameof(SpawnSequence)} {_spawnSequence.name} is already running.");

            _spawnSequence = spawnSequence;
        }
    }
}
