# WebAPI-OData-ExpandSortPOC

Proof of concept to demonstrate issue with expanded collections not being returned in a consistent order.

Issue: When expanding into a set of data, the expanded set is not returned in order by primary key.  This 
causes some records to be skipped and others to be duplicated when using pagination and the provided 
nextLink.

Test URL
http://localhost:5542/odata3/v1/PocCntry?$expand=PocSubject

Returns
<pre>
{
  "odata.metadata":"http://localhost:5542/odata3/v1/$metadata#PocCntry","value":[
    {
      "PocSubject":[
        {
          "SiteId":"-234","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"3"
        },{
          "SiteId":"-220","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"7"
        },{
          "SiteId":"-233","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"14"
        },{
          "SiteId":"-228","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"3"
        },{
          "SiteId":"-246","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"4"
        },{
          "SiteId":"-231","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"2"
        },{
          "SiteId":"-250","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"3"
        },{
          "SiteId":"-251","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"4"
        },{
          "SiteId":"-345","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"0"
        },{
          "SiteId":"-232","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"1"
        }
      ],"PocSubject@odata.nextLink":"http://localhost:5542/odata3/v1/PocCntry(-101M)/PocSubject?$skip=10","CntryId":"-101","ClnclId":"-12117"
    }
  ]
}
</pre>

The provided nextLink (http://localhost:5542/odata3/v1/PocCntry(-101M)/PocSubject?$skip=10) then returns
8 PocSubject records, some of which are duplicates from the original 10.  This also means some of the 18 
PocSubject records are skipped.
<pre>
{
  "odata.metadata":"http://localhost:5542/odata3/v1/$metadata#PocSubject","value":[
    {
      "SiteId":"-233","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"14"
    },{
      "SiteId":"-232","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"1"
    },{
      "SiteId":"-231","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"2"
    },{
      "SiteId":"-230","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"11"
    },{
      "SiteId":"-229","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"6"
    },{
      "SiteId":"-228","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"3"
    },{
      "SiteId":"-227","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"6"
    },{
      "SiteId":"-220","ClnclId":"-12117","CntryId":"-101","SubjEntrScrng":"7"
    }
  ]
}
</pre>