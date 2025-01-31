﻿using UnityEngine;
using System;
using Obstacles.Sequence;
using Scripts.Obstacles;
using Scripts.Structures;

namespace Obstacles
{
    public class ObstacleMovement : MonoBehaviour
    {
        
        [SerializeField] private FloatRange _moveDuration;
        [SerializeField] private FloatRange _changeSpeedDuration;
        [SerializeField] private FloatRange _speed;
        [SerializeField] private AnimationCurve _changeSpeedCurve;
        
        [ContextMenu(nameof(Start))]
       
        private void Start()
        {
            IMovement movement = new RotationMovement(transform, Vector3.up);
            var terms = new IMovementSequenceTerm[]
            {
                new ChangeSpeedSequenceTerm(movement, _speed, _changeSpeedDuration, _changeSpeedCurve),
                new MoveSequenceTerm(movement, _moveDuration)
            };
            CoroutineExecutor coroutineExecutor = new CoroutineExecutor(this);
            MovementSequence sequence = new MovementSequence(terms, coroutineExecutor);
            sequence.StartProcessing();
        }
    }
  
}