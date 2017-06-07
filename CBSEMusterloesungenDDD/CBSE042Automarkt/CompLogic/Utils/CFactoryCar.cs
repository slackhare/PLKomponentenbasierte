namespace CompLogic.Utils {
    public class CFactoryCar : IFactoryICar {
        public ICar Create() {
            return new Car();
        }
    }
}
