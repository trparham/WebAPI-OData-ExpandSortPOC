﻿using System.Linq;
using ExpandSortPOC.Delegates.v1;
using ExpandSortPOC.Models.v1;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using ExpandSortPOC.Models.v1;

namespace ExpandSortPOC.Controllers.OData4.v1
{
    public class PocSubjectV4_1Controller : ODataController
    {
        #region Entities

        /// <summary>
        /// OData endpoint for the PocSubject EntitySet
        /// </summary>
        /// <returns>A collection of PocSubject</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocSubjectDelegate.PageSize)]
        public IEnumerable<PocSubject> GetPocSubject()
        {
            return PocSubjectDelegate.GetPocSubject();
        }

        /// <summary>
        /// OData endpoint for the PocSubject Entity
        /// </summary>
        /// <param name="siteId">Compound key for PocSubject</param>
        /// <param name="clnclId">Compound key for PocSubject</param>
        /// <returns>A single PocSubject</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocSubjectDelegate.PageSize)]
        public SingleResult<PocSubject> GetPocSubject([FromODataUri] decimal siteId, [FromODataUri] string clnclId)
        {
            return PocSubjectDelegate.GetPocSubject(siteId, clnclId);
        }

        #endregion Entities

        #region Navigation

        /// <summary>
        /// OData endpoint for the PocCntry associated to the PocSubject Entity
        /// </summary>
        /// <param name="siteId">Compound key for PocSubject</param>
        /// <param name="clnclId">Compound key for PocSubject</param>
        /// <returns>a single PocCntry</returns>
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All, MaxExpansionDepth = 5, PageSize = PocCntryDelegate.PageSize)]
        public SingleResult<PocCntry> GetPocCntry([FromODataUri] decimal siteId, [FromODataUri] string clnclId)
        {
            return PocSubjectDelegate.GetPocCntry(siteId, clnclId);
        }

        #endregion Navigation
    }
}