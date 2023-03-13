using Leopotam.Ecs;

namespace Interfaces
{
    internal interface IDamageable
    {
        void TakeDamage(EcsEntity entity, int damage);
    }
}