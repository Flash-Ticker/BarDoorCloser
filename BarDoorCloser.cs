using Oxide.Core;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("BarDoorCloser", "RustFlash", "1.0.0")]
    class BarDoorCloser : RustPlugin
    {
        private float doorCloseDelay = 2.3f;

        private void OnDoorOpened(Door door, BasePlayer player)
        {
            if (door.PrefabName == "assets/prefabs/misc/decor_dlc/bardoors/door.double.hinged.bardoors.prefab")
            {
                timer.Once(doorCloseDelay, () =>
                {
                    CloseDoor(door);
                });
            }
        }

        private void CloseDoor(Door door)
        {
            if (door != null && door is BaseEntity)
            {
                (door as BaseEntity).SetFlag(BaseEntity.Flags.Open, false);
                door.SendNetworkUpdateImmediate();
            }
        }
    }
}
