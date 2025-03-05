using System;

namespace Scripts.Menu.ShopSystem
{
    public interface IChangeable
    {
        public int Value { get; }

        public event Action Changed;
    }
}