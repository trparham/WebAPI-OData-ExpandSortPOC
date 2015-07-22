using ExpandSortPOC.Models.v1;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ExpandSortPOC.Delegates.v1
{
    public static class PocSubjectDelegate
    {
        // Constant for the default pagesize on returns, used in the controllers
        public const int PageSize = 10;

        #region Entities

        /// <summary>
        /// Returns all PocSubject, filtering and page size are controlled
        /// through the OData query attributes.
        /// </summary>

        /// <returns>A collection of PocSubject</returns>
        public static IEnumerable<PocSubject> GetPocSubject()
        {
            var db = new ExpandSortEntities();
            var entities = db.PocSubject;
            return entities;
        }

        /// <summary>
        /// Returns a single PocSubject based on primary key
        /// </summary>
        /// <param name="siteId">Composite key for PocSubject</param>
        /// <param name="clnclId">Composite key for PocSubject</param>
        /// <returns>A single PocSubject</returns>
        public static SingleResult<PocSubject> GetPocSubject(decimal siteId, string clnclId)
        {
            var db = new ExpandSortEntities();
            var entities = db.PocSubject.Where(x => x.SiteId == siteId && x.ClnclId == clnclId);
            return SingleResult.Create(entities);
        }

        #endregion Entities

        #region Navigation

        /// <summary>
        /// Returns PocCntry associated to PocSubject
        /// </summary>
        /// <param name="siteId">Composite key for PocSubject</param>
        /// <param name="clnclId">Composite key for PocSubject</param>
        /// <returns>A single PocCntry</returns>
        public static SingleResult<PocCntry> GetPocCntry(decimal siteId, string clnclId)
        {
            var db = new ExpandSortEntities();
            var entities = db.PocSubject.Where(x => x.SiteId == siteId && x.ClnclId == clnclId)
                .Select(x => x.PocCntry);
            return SingleResult.Create(entities);
        }

        #endregion Navigation
    }
}