using System.Collections.ObjectModel;
using WpfSheet.Content;
using WpfSheet.Models;

namespace WpfSheet.ViewModels
{
    public sealed partial class SheetViewModel : ViewModelBase
    {


        private int _healthStat;
        private int _attackStat;
        private int _defenseStat;
        private int _specialAttackStat;
        private int _specialDefenseStat;
        private int _speedStat;
        private ObservableCollection<Nature> _natures;
        private Nature _selectedNature;

        public int HealthStat { get => _healthStat; set => Set(nameof(HealthStat), ref _healthStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalHealth) }); }
        public int TotalHealth { get => CalculateTotalStatPoint("health", SelectedPokemon.Stats.Health, HealthStat); }

        public int AttackStat { get => _attackStat; set => Set(nameof(AttackStat), ref _attackStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalAttack) }); }
        public int TotalAttack { get => CalculateTotalStatPoint("attack", SelectedPokemon.Stats.Attack, AttackStat); }

        public int DefenseStat { get => _defenseStat; set => Set(nameof(DefenseStat), ref _defenseStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalDefense) }); }
        public int TotalDefense { get => CalculateTotalStatPoint("defense", SelectedPokemon.Stats.Defense, DefenseStat); }

        public int SpecialAttackStat { get => _specialAttackStat; set => Set(nameof(SpecialAttackStat), ref _specialAttackStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpecialAttack) }); }
        public int TotalSpecialAttack { get => CalculateTotalStatPoint("special attack", SelectedPokemon.Stats.SpecialAttack, SpecialAttackStat); }


        public int SpecialDefenseStat { get => _specialDefenseStat; set => Set(nameof(SpecialDefenseStat), ref _specialDefenseStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpecialDefense) }); }
        public int TotalSpecialDefense { get => CalculateTotalStatPoint("special defense", SelectedPokemon.Stats.SpecialDefense, SpecialDefenseStat); }

        public int SpeedStat { get => _speedStat; set => Set(nameof(SpeedStat), ref _speedStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpeed) }); }
        public int TotalSpeed { get => CalculateTotalStatPoint("speed", SelectedPokemon.Stats.Speed, SpeedStat); }


        public int MaximumRemainingStatPoints { get => CalculateRemainingStatPoints(); }
        public ObservableCollection<Nature> Natures { get => _natures; set => Set(nameof(Natures), ref _natures, value); }
        public Nature SelectedNature { get => _selectedNature; set => Set(nameof(SelectedNature), ref _selectedNature, value, others: new[] { nameof(TotalHealth), nameof(TotalAttack), nameof(TotalDefense), nameof(TotalSpecialAttack), nameof(TotalSpecialDefense), nameof(TotalSpeed) }); }


        private int CalculateTotalStatPoint(string stat, int baseValue, int added)
        {
            var total = baseValue + added;
            if (SelectedNature.IncreaseStat.Equals(stat, System.StringComparison.OrdinalIgnoreCase)) total += SelectedNature.IncreaseBy;
            if (SelectedNature.DecreaseStat.Equals(stat, System.StringComparison.OrdinalIgnoreCase)) total -= SelectedNature.DecreaseBy;
            return total;
        }

        private int CalculateRemainingStatPoints()
        {
            var maxPoints = ResourceHandler.CalculateAvailablePoints(CurrentLevel);
            return maxPoints - (HealthStat + AttackStat + DefenseStat + SpecialAttackStat + SpecialDefenseStat + SpeedStat);
        }

    }

}
