using System.Numerics;
using Content.Server.Atmos.EntitySystems;
using Content.Server.Chat.Systems;
using Content.Server.NPC;
using Content.Server.NPC.HTN;
using Content.Server.NPC.Systems;
using Content.Server.Popups;
using Content.Shared.Atmos;
using Content.Shared.Dataset;
using Content.Shared.Nutrition.Components;
using Content.Shared.Nutrition.EntitySystems;
using Content.Shared.Pointing;
using Content.Shared.AlienXeno;
using Robust.Shared.Map;
using Robust.Shared.Random;

namespace Content.Server.AlienXeno
{
    public sealed class AlienXenoSystem : SharedAlienXenoSystem
    {
        [Dependency] private readonly AtmosphereSystem _atmos = default!;
        [Dependency] private readonly ChatSystem _chat = default!;
        [Dependency] private readonly HTNSystem _htn = default!;
        [Dependency] private readonly HungerSystem _hunger = default!;
        [Dependency] private readonly NPCSystem _npc = default!;
        [Dependency] private readonly PopupSystem _popup = default!;

        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<AlienXenoComponent, AlienXenoActionEvent>(OnRaiseArmy);
        }

        private void OnRaiseArmy(EntityUid uid, AlienXenoComponent component, AlienXenoActionEvent args)
        {
            if (args.Handled)
                return;

            if (!TryComp<HungerComponent>(uid, out var hunger))
                return;

            //make sure the hunger doesn't go into the negatives
            if (hunger.CurrentHunger < component.HungerPerArmyUse)
            {
                _popup.PopupEntity(Loc.GetString("Вы слишком голодны"), uid, uid);
                return;
            }
            args.Handled = true;
            _hunger.ModifyHunger(uid, -component.HungerPerArmyUse, hunger);
            Spawn(component.ArmyMobSpawnId, Transform(uid).Coordinates);
        }
    }
}
