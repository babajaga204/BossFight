
namespace BossFight
{
    internal class GameCharacter
    {
        public string Name;
        public int Health;
        public int MaxStrength;
        public int Stamina;
        public bool IsBoss;

        public GameCharacter(string name, int health, int strength, int stamina, bool isBoss)
        {
            Name = name;
            Health = health;
            MaxStrength = strength;
            Stamina = stamina;
            IsBoss = isBoss;
        }

        public void Fight(GameCharacter opponentCharacter)
        {
            if (Stamina != 0)
            {
                if (IsBoss)
                {
                    var randomAttackDmg = RandomStrengthAttack();
                    opponentCharacter.Health -= randomAttackDmg;
                    Stamina -= 10;
                    Console.WriteLine(Name
                                      + " hits "
                                      + opponentCharacter.Name
                                      + " with "
                                      + randomAttackDmg
                                      + " damage, "
                                      + opponentCharacter.Name
                                      + " now has " + opponentCharacter.Health
                                      + " health left");
                    Thread.Sleep(1000);
                }
                else
                {
                    opponentCharacter.Health -= MaxStrength;
                    Stamina -= 10;
                    Console.WriteLine(Name
                                      + " hits "
                                      + opponentCharacter.Name
                                      + " with "
                                      + MaxStrength
                                      + ", " + opponentCharacter.Name
                                      + " now has " + opponentCharacter.Health
                                      + " health left");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Recharge();
                Console.WriteLine(Name + " has no stamina left! Recharge used instead of attack!");
                Thread.Sleep(1000);
            }
        }

        private int RandomStrengthAttack()
        {
            var random = new Random();
            return random.Next(0, MaxStrength);
        }

        public void Recharge()
        {
            Stamina += 10;
        }

        public void Show()
        {
            Console.WriteLine(@$"Status: 
Name: {Name}
Health: {Health}
Stamina: {Stamina}
Strength: {MaxStrength}
");
            Console.WriteLine();
        }

        public void TakePotion(Item item, GameCharacter opponentCharacter)
        {
            switch (item.ItemType)
            {
                case "StaminaPotion":
                {
                    Console.WriteLine(Name + " takes a stamina potion! Stamina increased by 10!");
                    Recharge();
                    break;
                }
                case "HealthPotion":
                {
                    Console.WriteLine(Name + " takes a health potion! Health restored.");
                    Health = 100;
                    break;
                }
                case "StrengthPotion":
                {
                    Console.WriteLine(Name + " takes a strength potion. Next attack increased by 30!");
                    HeavyAttack(opponentCharacter);
                    break;
                }
            }
        }

        private void HeavyAttack(GameCharacter opponentCharacter)
        {
            opponentCharacter.Health -= MaxStrength + 30;
            Stamina -= 10;
            Console.WriteLine(Name
                              + " hits "
                              + opponentCharacter.Name
                              + " with "
                              + MaxStrength + 30
                              + ", " + opponentCharacter.Name
                              + " now has " + opponentCharacter.Health
                              + " health left");
            Thread.Sleep(1000);
        }
    }
}