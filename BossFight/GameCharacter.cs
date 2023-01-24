
namespace BossFight
{
    internal class GameCharacter
    {
        private string _name;
        private int _health;
        private int _maxStrength;
        private int _stamina;
        public GameCharacter(string name, int health, int strength, int stamina)
        {
            _name = name;
            _health = health;
            _maxStrength = strength;
            _stamina = stamina;
        }
        public void Fight(GameCharacter opponentCharacter)
        {
            if (_stamina != 0)
            {
                var randomAttackDmg = RandomStrengthAttack();
                opponentCharacter._health -= randomAttackDmg;
                _stamina -= 10;
                Console.WriteLine(_name 
                                  + " hits " 
                                  + opponentCharacter._name 
                                  + " with " + randomAttackDmg 
                                  + "," + opponentCharacter._name 
                                  + " now has" + opponentCharacter._health 
                                  + "left");
            }
            else
            {
                Recharge();
                Console.WriteLine(_name + "has no stamina left! Recharge used instead of attack!");
            }
        }
        private int RandomStrengthAttack()
        {
            var random = new Random();
            return random.Next(0, _maxStrength);
        }

        public void Recharge()
        {
            _stamina += 10;
        }
        public void Show()
        {
            Console.WriteLine(_name);
        }
    }
}
