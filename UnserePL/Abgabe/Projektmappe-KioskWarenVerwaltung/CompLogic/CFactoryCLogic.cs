namespace CompLogic {
    public class CFactoryCLogic: IFactoryILogic {
        // Legt eine Instanz der Konkreten Logic Klasse an
        public ILogic Create( IData iDbase ) {
            return new CLogic( iDbase );
        }
    }
}
