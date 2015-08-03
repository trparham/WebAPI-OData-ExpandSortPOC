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

        private static readonly List<PocCntry> PocCntries = new List<PocCntry>()
        {
            new PocCntry()
            {
                CntryId = -101,
                ClnclId = "-12117",
                PocSubject = new List<PocSubject>()
                {
                     new PocSubject() {SiteId = -234, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 3},
                     new PocSubject() {SiteId = -220, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 7},
                     new PocSubject() {SiteId = -233, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 14},
                     new PocSubject() {SiteId = -228, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 3},
                     new PocSubject() {SiteId = -246, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 4},
                     new PocSubject() {SiteId = -244, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 2},
                     new PocSubject() {SiteId = -250, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 3},
                     new PocSubject() {SiteId = -251, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 4},
                     new PocSubject() {SiteId = -345, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 0},
                     new PocSubject() {SiteId = -232, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 1},
                     new PocSubject() {SiteId = -231, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 2},
                     new PocSubject() {SiteId = -245, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 16},
                     new PocSubject() {SiteId = -243, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 29},
                     new PocSubject() {SiteId = -241, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 15},
                     new PocSubject() {SiteId = -227, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 6},
                     new PocSubject() {SiteId = -229, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 6},
                     new PocSubject() {SiteId = -247, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 42},
                     new PocSubject() {SiteId = -230, ClnclId = "-12117", CntryId = -101, SubjEntrScrng = 11},
                }
            }
        };

        #region Entities

        /// <summary>
        /// Returns all PocCntry, filtering and page size are controlled
        /// through the OData query attributes.
        /// </summary>

        /// <returns>A collection of PocCntry</returns>
        public static IEnumerable<PocCntry> GetPocCntry()
        {
            //var db = new ExpandSortEntities();
            //var entities = db.PocCntry;
            //return entities;
            return PocCntries;
        }

        /// <summary>
        /// Returns a single PocCntry based on primary key
        /// </summary>
        /// <param name="key">Primary key for PocCntry</param>

        /// <returns>A single PocCntry</returns>
        public static PocCntry GetPocCntry(decimal key)
        {
            //var db = new ExpandSortEntities();
            //var entities = db.PocCntry.Where(x => x.CntryId == key);
            var entities = PocCntries.Where(x => x.CntryId == key);
            return entities.FirstOrDefault();
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
            //var db = new ExpandSortEntities();
            //var entities = db.PocCntry.Where(x => x.CntryId == key)
            //    .SelectMany(x => x.PocSubject);
            //return entities;
            return PocCntries.Where(x => x.CntryId == key).SelectMany(x => x.PocSubject);
        }

        #endregion Navigation
    }
}