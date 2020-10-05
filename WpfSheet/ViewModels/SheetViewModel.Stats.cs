using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfSheet.Content;
using WpfSheet.Models;

namespace WpfSheet.ViewModels
{
    public sealed partial class SheetViewModel : ViewModelBase
    {

        #region Embedded Enums
        internal enum BonusType
        {
            Defense,
            SpecialDefense,
            Speed
        }
        #endregion

        private int _healthStat;
        private int _attackStat;
        private int _defenseStat;
        private int _specialAttackStat;
        private int _specialDefenseStat;
        private int _speedStat;
        private ObservableCollection<Nature> _natures;
        private Nature _selectedNature;

        public int HealthStat { get => _healthStat; set => Set(nameof(HealthStat), ref _healthStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalHealth) }); }
        public int TotalHealth { get => CalculateTotalStatPoint("health", SelectedPokemon.Stats.Health, HealthStat, SelectedNature); }

        public int AttackStat { get => _attackStat; set => Set(nameof(AttackStat), ref _attackStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalAttack) }); }
        public int TotalAttack { get => CalculateTotalStatPoint("attack", SelectedPokemon.Stats.Attack, AttackStat, SelectedNature); }

        public int DefenseStat { get => _defenseStat; set => Set(nameof(DefenseStat), ref _defenseStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalDefense), nameof(PhysicalBonus) }); }
        public int TotalDefense { get => CalculateTotalStatPoint("defense", SelectedPokemon.Stats.Defense, DefenseStat, SelectedNature); }

        public int SpecialAttackStat { get => _specialAttackStat; set => Set(nameof(SpecialAttackStat), ref _specialAttackStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpecialAttack) }); }
        public int TotalSpecialAttack { get => CalculateTotalStatPoint("special attack", SelectedPokemon.Stats.SpecialAttack, SpecialAttackStat, SelectedNature); }


        public int SpecialDefenseStat { get => _specialDefenseStat; set => Set(nameof(SpecialDefenseStat), ref _specialDefenseStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpecialDefense), nameof(SpecialBonus) }); }
        public int TotalSpecialDefense { get => CalculateTotalStatPoint("special defense", SelectedPokemon.Stats.SpecialDefense, SpecialDefenseStat, SelectedNature); }

        public int SpeedStat { get => _speedStat; set => Set(nameof(SpeedStat), ref _speedStat, value, others: new[] { nameof(MaximumRemainingStatPoints), nameof(TotalSpeed), nameof(SpeedBonus) }); }
        public int TotalSpeed { get => CalculateTotalStatPoint("speed", SelectedPokemon.Stats.Speed, SpeedStat, SelectedNature); }


        public int PhysicalBonus { get => CalculateBonusValue(TotalDefense, BonusType.Defense); }
        public int SpecialBonus { get => CalculateBonusValue(TotalSpecialDefense, BonusType.SpecialDefense); }
        public int SpeedBonus { get => CalculateBonusValue(TotalSpeed, BonusType.Speed); }


        public int MaximumRemainingStatPoints { get => CalculateRemainingStatPoints(CurrentLevel, HealthStat, AttackStat, DefenseStat, SpecialAttackStat, SpecialDefenseStat, SpeedStat); }
        public ObservableCollection<Nature> Natures { get => _natures; set => Set(nameof(Natures), ref _natures, value); }
        public Nature SelectedNature { get => _selectedNature; set => Set(nameof(SelectedNature), ref _selectedNature, value, others: new[] { nameof(TotalHealth), nameof(TotalAttack), nameof(TotalDefense), nameof(TotalSpecialAttack), nameof(TotalSpecialDefense), nameof(TotalSpeed) }); }


        private int CalculateTotalStatPoint(string stat, int baseValue, int added, Nature n)
        {
            var total = baseValue + added;
            if (n.IncreaseStat.Equals(stat, StringComparison.OrdinalIgnoreCase)) total += n.IncreaseBy;
            if (n.DecreaseStat.Equals(stat, StringComparison.OrdinalIgnoreCase)) total -= n.DecreaseBy;
            return total;
        }

        private int CalculateRemainingStatPoints(int currentLevel, int hp, int attack, int defense, int spAtk, int spDef, int speed)
        {
            var maxPoints = ResourceHandler.CalculateAvailablePoints(currentLevel);
            return maxPoints - (hp + attack + defense + spAtk + spDef + speed);
        }

        private int CalculateBonusValue(int currentStat, BonusType bonusType)
        {
            switch(bonusType)
            {
                case BonusType.Defense:
                case BonusType.SpecialDefense:
                    return currentStat / 5;
                case BonusType.Speed:
                    return currentStat / 10;
                default:
                    throw new InvalidEnumArgumentException(nameof(bonusType), (int)bonusType, typeof(BonusType));
            }
        }

    }

}
