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

        public bool Started { get; private set; } = false;
        public bool Finished { get; private set; } = false;

        private void Start()
        {
            _spawnPacksCoroutine = _spawnSequence.SpawnPacksCoroutineFixedTime(Time.fixedDeltaTime, transform.position);
            Started = true;
        }

        private void FixedUpdate()
        {
            if (Finished)
                return;

            if (!_spawnPacksCoroutine.MoveNext())
                Finished = true;
        }

        public void OverrideSpawnSequence(SpawnSequence spawnSequence)
        {
            if (Started)
                throw new InvalidOperationException($"Nope, too late to override. {nameof(SpawnSequence)} {_spawnSequence.name} is already running.");

            _spawnSequence = spawnSequence;
        }
    }
}
