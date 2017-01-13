﻿using UnityEngine;
using Improbable.Worker;
using Improbable.General;
using Improbable.Math;
using Improbable.Unity.Core.Acls;
using Improbable.Gameplay;

namespace Assets.EntityTemplates
{
    public class GoalSphereEntityTemplate : MonoBehaviour
    {
        // Template definition for a Example entity
        public static SnapshotEntity GenerateGoalSphereSnapshotEntityTemplate()
        {
            // Set name of Unity prefab associated with this entity
            var goalSphereEntity = new SnapshotEntity { Prefab = "GoalSphere" };

            // Define components attached to snapshot entity
            goalSphereEntity.Add(new WorldTransform.Data(new WorldTransformData(RandomCoordinates(), 0)));

            goalSphereEntity.SetAcl(BuildACL());

            return goalSphereEntity;
        }

        public static Entity GenerateGoalSphereEntityTemplate()
        {
            var goalSphereEntity = new Entity();

            goalSphereEntity.Add(new WorldTransform.Data(new WorldTransformData(RandomCoordinates(), 0)));

            goalSphereEntity.SetAcl(BuildACL());

            return goalSphereEntity;
        }

        private static Acl BuildACL()
        {
            var acl = Acl.Build()
                // Both FSim (server) workers and client workers granted read access over all states
                .SetReadAccess(CommonPredicates.PhysicsOrVisual)
                // Only FSim workers granted write access over WorldTransform component
                .SetWriteAccess<WorldTransform>(CommonPredicates.PhysicsOnly);
            return acl;
        }

        private static Coordinates RandomCoordinates()
        {
            float x = (Random.value * 50) - 25;
            float z = (Random.value * 40) - 20;
            return new Coordinates(x, 1, z);
        }
    }
}