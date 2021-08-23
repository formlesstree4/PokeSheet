using PtaSheet3.Core.Content;
using PtaSheet3.Core.Models;
using PtaSheet3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PtaSheet3.Services
{
    public sealed class AbilityDataProvider : IAbilityDataProvider
    {

        private readonly AbilityCollection abilities;

        public AbilityDataProvider()
        {
            var abilityContent = System.IO.File.ReadAllText(ResourceHandler.GetAbilityFile);
            abilities = System.Text.Json.JsonSerializer.Deserialize<AbilityCollection>(abilityContent);
        }

        public void FlushChanges()
        {
            var abilityContent = System.Text.Json.JsonSerializer.Serialize<AbilityCollection>(abilities);
            System.IO.File.WriteAllText(ResourceHandler.GetAbilityFile, abilityContent);
        }

        public Ability GetAbility(string name) => abilities.Abilities.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Ability> GetPokemonHighAbilities(Pokemon pokemon) =>
            from a in pokemon.Abilities.High.Ability
            let high = GetAbility(a)
            where high != null
            select high;

        public IEnumerable<Ability> GetPokemonRegularAbilities(Pokemon pokemon) =>
            from a in pokemon.Abilities.Basic.Ability
            let basic = GetAbility(a)
            where basic != null
            select basic;

        public AbilityCollection RetrieveAbilities() => abilities;
    }
}
