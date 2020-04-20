using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public class PedestalColliderSystem : ComponentSystem
{
    // After balls spawn, don't want colliders interfering with player movement
    // Don't need to turn them into triggers like GameObject versions, so remove them
    protected override void OnUpdate() {
        if (Settings.DoneSpawning()) {
            Entities.WithAll<PedestalColliderTag>().ForEach((Entity entity) => {
                PostUpdateCommands.DestroyEntity(entity);
            });
        }
    }
}