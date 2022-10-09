namespace Game.Model
{
    public abstract class RestorePotion : IUsable, ICollectable
    {
        public readonly int RestoreAmount;
        private readonly VitalCharacteristic _target;

        public RestorePotion(int restoreAmount, VitalCharacteristic target)
        {
            RestoreAmount = restoreAmount;
            _target = target;
        }

        public void Use()
        {
            _target.Regenerate(RestoreAmount);
        }
    }
}