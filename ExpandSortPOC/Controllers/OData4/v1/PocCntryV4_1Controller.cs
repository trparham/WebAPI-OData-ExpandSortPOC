using System.Linq;
using ExpandSortPOC.Delegates.v1;
using ExpandSortPOC.Models.v1;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;

namespace Lilly.Services.ClinicalData.Controllers.OData4.v1
{
    public class PocCntryV4_1Controller : ODataController
    {
        #region Entities

        /// <summary>
        /// OData endpoint for the PocCntry EntitySet
        /// </summary>
        /// <returns>A collection of PocCntry</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocCntryDelegate.PageSize)]
        public IEnumerable<PocCntry> GetPocCntry()
        {
            return PocCntryDelegate.GetPocCntry();
        }


        /// <summary>
        /// OData endpoint for the PocCntry Entity
        /// </summary>
        /// <param name="key">Primary key for PocCntry</param>
        /// <returns>A single PocCntry</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocCntryDelegate.PageSize)]
        public SingleResult<PocCntry> GetStudyCountry([FromODataUri] decimal key)
        {
            return PocCntryDelegate.GetPocCntry(key);
        }

        #endregion Entities

        #region Navigation

        /// <summary>
        /// OData endpoint for the PocSubject associated to the PocCntry Entity
        /// </summary>
        /// <param name="key">Primary key for PocCntry</param>
        /// <returns>a collection of PocSubject</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocCntryDelegate.PageSize)]
        public IEnumerable<PocSubject> GetPocSubject([FromODataUri] decimal key)
        {
            return PocCntryDelegate.GetPocSubject(key);
        }

        #endregion Navigation
    }
}