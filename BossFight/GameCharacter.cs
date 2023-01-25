
namespace BossFight
{
    internal class GameCharacter
    {
        public string _name;
        public int _health;
        public int _maxStrength;
        public int _stamina;
        public bool _isBoss;
        public GameCharacter(string name, int health, int strength, int stamina, bool isBoss)
        {
            _name = name;
            _health = health;
            _maxStrength = strength;
            _stamina = stamina;
            _isBoss = isBoss;
        }
        public void Fight(GameCharacter opponentCharacter)
        {
            if (_stamina != 0)
            {
                if (_isBoss)
                {
                    var randomAttackDmg = RandomStrengthAttack();
                    opponentCharacter._health -= randomAttackDmg;
                    _stamina -= 10;
                    Console.WriteLine(_name
                                      + " hits "
                                      + opponentCharacter._name
                                      + " with "
                                      + randomAttackDmg
                                      + " damage,"
                                      + opponentCharacter._name
                                      + " now has " + opponentCharacter._health
                                      + " health left");
                    Thread.Sleep(1000);
                }
                else
                {
                    opponentCharacter._health -= _maxStrength;
                    _stamina -= 10;
                    Console.WriteLine(_name
                                      + " hits "
                                      + opponentCharacter._name
                                      + " with "
                                      + _maxStrength
                                      + "," + opponentCharacter._name
                                      + " now has " + opponentCharacter._health
                                      + " health left");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                Recharge();
                Console.WriteLine(_name + " has no stamina left! Recharge used instead of attack!");
                Thread.Sleep(1000);
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
            Console.WriteLine(@$"Status: 
Name: {_name}
Health: {_health}
Stamina: {_stamina}
Strength: {_maxStrength}
");
            Console.WriteLine();
        }
    }
}