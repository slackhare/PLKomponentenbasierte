namespace CompLogic {
    public class CFactoryCLogic: IFactoryILogic {
        public ILogic Create( IData iDbase ) {
            return new CLogic( iDbase );
        }
    }
}
