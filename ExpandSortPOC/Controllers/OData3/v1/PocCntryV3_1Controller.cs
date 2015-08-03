using ExpandSortPOC.Delegates.v1;
using ExpandSortPOC.Extensions;
using ExpandSortPOC.Helpers;
using ExpandSortPOC.Models.v1;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace Lilly.Services.ClinicalData.Controllers.OData3.v1
{
    public class PocCntryV3_1Controller : ODataController
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
        public PocCntry GetStudyCountry([FromODataUri] decimal key)
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