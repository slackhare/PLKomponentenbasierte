using System.Collections.Generic;
using System.Data;
namespace CompLogic
{
    public interface ILogic
    {
        ILogicSearch LogicSearch { get; }
        ILogicInsert LogicInsert { get; }
        ILogicUpdate LogicUpdate { get; }
        ILogicWarning LogicWarning { get; }
    }

    public interface ILogicSearch
    {
        void SelectAllProducts(ref DataTable dataTable);
        void SelectAllProductCategories(ref DataTable dataTable);
        void FillListProduct(ref List<IProduct> listIProduct, List<IProductCategory> listIProductCategory);
        void FillListCategory(ref List<IProductCategory> ListICategory);
    }

    public interface ILogicInsert
    {
        bool InsertProduct(IProduct iProduct);

        void InsertProductCategory(IProductCategory iProductCategory);
    }

    public interface ILogicUpdate
    {
        /// <summary>
        /// Restocks a product with the given GUID with the number given 
        /// </summary>
        /// <param name="guid">GUID of the Product to Restock</param>
        /// <param name="restockNumber">number to add to stock</param>
        /// <returns></returns>
        bool RestockProduct(string guid, int restockNumber);
        void RestockProduct(IProduct iProduct);
        bool SellProduct(string guid, int restockNumber);
    }

    public interface ILogicWarning
    {
        DataTable Format(DataTable toformat, decimal limit);
        /// <summary>
        /// Returns a formated DataTable where all unnecessary columns and rows witch are above the given limit of stock,
        /// are deleted
        /// </summary>
        /// <param name="limit">limit at witch the rows with more stock will be removed</param>
        /// <returns>The formated DataTable</returns>
        DataTable Format(decimal limit);
    }



}
