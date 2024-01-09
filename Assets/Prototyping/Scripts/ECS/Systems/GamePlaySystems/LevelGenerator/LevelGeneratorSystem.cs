using Leopotam.Ecs;
using PinBallRunner.Prototyping.Scripts.MonoComponents.GameEnviroment;
using PinBallRunner.Prototyping.Scripts.Systems.GamePlaySystems.LevelGenerator;
using System.Collections.Generic;
using UnityEngine;

namespace PinBallRunner.Prototyping.Scripts.Systems.Level
{
    public class LevelGeneratorSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<Ball> _ballFilter;
        private readonly EcsFilter<LevelSegment> _segmentFilter;
        private readonly LevelGeneratorData _data;

        private readonly List<LevelSegmentView> _disabledSegments = new();
        private LevelSegmentView[] _segments;
        private LevelSegmentView _lastSpawnedSegment;

        private float _levelLength;

        public void Init()
        {
            _segments = _data.Segments;
            StartSegmentInit();
        }

        public void Run()
        {
            foreach (var i in _ballFilter)
            {
                List<EcsEntity> forDelete = new();

                ref var ball = ref _ballFilter.Get1(i);

                foreach (var ii in _segmentFilter)
                {
                    ref var segment = ref _segmentFilter.Get1(ii);
                    var distance = ball.Transform.position.z - segment.End.z;

                    if (distance >= 5f)
                    {                      
                        if (!_disabledSegments.Contains(segment.View) && !segment.View.IsStart)
                        {
                            _disabledSegments.Add(segment.View);                                          
                        }

                        segment.View.gameObject.SetActive(false);
                        ref var segmentEntity = ref _segmentFilter.GetEntity(ii);

                        forDelete.Add(segmentEntity);
                    }

                    distance = _levelLength - ball.Transform.position.z;

                    if (distance <= 15f)
                    {
                        GenerateSegment();
                    }
                }

                foreach(var entity in forDelete)
                {
                    entity.Del<LevelSegment>();
                }
            }
        }

        private void StartSegmentInit()
        {
            var startSegment = Object.Instantiate(_data.StartSegment);
            ref var segment = ref _world.NewEntity().Get<LevelSegment>();
            segment.View = startSegment;
            segment.End = startSegment.End.position;

            _lastSpawnedSegment = startSegment;

            _levelLength = segment.End.z;
        }

        private void GenerateSegment()
        {            
            LevelSegmentView segmentGO = null;

            if (_disabledSegments.Count < _segments.Length)
            {
                LevelSegmentView randomSegment;

                do
                {
                    randomSegment = _segments[Random.Range(0, _segments.Length)];
                }
                while (_lastSpawnedSegment == randomSegment);

                segmentGO = Object.Instantiate(randomSegment, _lastSpawnedSegment.End.position, Quaternion.identity);               
            }
            if (_disabledSegments.Count >= _segments.Length) 
            {
                do
                {
                    segmentGO = _disabledSegments[Random.Range(0, _disabledSegments.Count)];
                }
                while (_lastSpawnedSegment == segmentGO);

                _disabledSegments.Remove(segmentGO);
                segmentGO.gameObject.SetActive(true);
                segmentGO.transform.position = _lastSpawnedSegment.End.position;
            }

            if (segmentGO == null)
                return;

            ref var newEntity = ref _world.NewEntity().Get<LevelSegment>();
            newEntity.View = segmentGO;
            newEntity.End = segmentGO.End.position;

            _lastSpawnedSegment = segmentGO;
            _levelLength = _lastSpawnedSegment.End.position.z;
        }
    }
}
