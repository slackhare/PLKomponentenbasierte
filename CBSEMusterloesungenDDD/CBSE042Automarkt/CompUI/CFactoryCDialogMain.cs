using CompLogic;
namespace CompUI {
   public class CFactoryCDialogMain : IFactoryIDialogMain {
      public IDialog Create( ILogic iLogic ) {
         return new CDialogMain( iLogic );
      }
   }
}
