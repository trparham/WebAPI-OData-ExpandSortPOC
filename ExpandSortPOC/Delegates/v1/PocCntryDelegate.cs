using ExpandSortPOC.Models.v1;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ExpandSortPOC.Delegates.v1
{
    public static class PocCntryDelegate
    {
        // Constant for the default pagesize on returns, used in the controllers
        public const int PageSize = 10;

        #region Entities

        /// <summary>
        /// Returns all PocCntry, filtering and page size are controlled
        /// through the OData query attributes.
        /// </summary>

        /// <returns>A collection of PocCntry</returns>
        public static IEnumerable<PocCntry> GetPocCntry()
        {
            var db = new ExpandSortEntities();
            var entities = db.PocCntry;
            return entities;
        }

        /// <summary>
        /// Returns a single PocCntry based on primary key
        /// </summary>
        /// <param name="key">Primary key for PocCntry</param>

        /// <returns>A single PocCntry</returns>
        public static SingleResult<PocCntry> GetPocCntry(decimal key)
        {
            var db = new ExpandSortEntities();
            var entities = db.PocCntry.Where(x => x.CntryId == key);
            return SingleResult.Create(entities);
        }

        #endregion Entities

        #region Navigation

        /// <summary>
        /// Returns all PocSubject associated to PocCntry
        /// </summary>
        /// <param name="key">Primary key for PocCntry</param>

        /// <returns>A collection of PocSubject</returns>
        public static IEnumerable<PocSubject> GetPocSubject(decimal key)
        {
            var db = new ExpandSortEntities();
            var entities = db.PocCntry.Where(x => x.CntryId == key)
                .SelectMany(x => x.PocSubject);
            return entities;
        }

        #endregion Navigation
    }
}