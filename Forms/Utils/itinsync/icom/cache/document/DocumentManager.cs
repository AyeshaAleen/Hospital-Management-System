using Domains.itinsync.icom.lookup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.itinsync.icom.cache.global;
using Utils.itinsync.icom.constant.application;
using Domains.itinsync.icom.idocument.definition;
using Domains.itinsync.icom.idocument.section;
using Domains.itinsync.icom.idocument.table;
using Domains.itinsync.icom.idocument.table.calculation;
using Domains.itinsync.icom.idocument.table.content;
using Domains.itinsync.icom.idocument.table.td;
using Domains.itinsync.icom.idocument.table.tr;
using Domains.itinsync.icom.idocument.role;
using Domains.itinsync.icom.idocument.route;
using Domains.itinsync.icom.idocument.routeusers;

namespace Utils.itinsync.icom.cache.document
{
    public static class DocumentManager
    {

        public static List<XDocumentDefination> getDefinitions()
        {
            List<XDocumentDefination> list = new List<XDocumentDefination>();

            foreach (Int32 key in GlobalStaticCache.documentDefinition.Keys)
            {

                list.Add( GlobalStaticCache.documentDefinition[key]);
            }

            return list;

        }

        public static XDocumentDefination getDocumentDefinition(Int64 doumentDefinitionID)
        {
            if (GlobalStaticCache.documentDefinition.ContainsKey(doumentDefinitionID))
                return GlobalStaticCache.documentDefinition[doumentDefinitionID];
            else
            {
                // write code to reload data
                return null;
            }

        }
        
        public static XDocumentRole getDocumentRole(Int32 doumentRoleID)
        {
            if (GlobalStaticCache.documentRole.ContainsKey(doumentRoleID))
                return GlobalStaticCache.documentRole[doumentRoleID];
            else
            {
                // write code to reload data
                return null;
            }
        }
        public static XDocumentRoute getDocumentRoute(Int32 id)
        {
            if (GlobalStaticCache.documentRoute.ContainsKey(id))
                return GlobalStaticCache.documentRoute[id];
            else
            {
                // write code to reload data
                return null;
            }

        }
        public static XDocumentRouteUsers getDocumentRouteUsers(Int32 id)
        {
            if (GlobalStaticCache.documentRouteUser.ContainsKey(id))
                return GlobalStaticCache.documentRouteUser[id];
            else
            {
                // write code to reload data
                return null;
            }

        }
        public static XDocumentSection getDocumentSection(Int32 doumentSectionID)
        {
            if (GlobalStaticCache.documentSection.ContainsKey(doumentSectionID))
                return GlobalStaticCache.documentSection[doumentSectionID];
            else
            {
                // write code to reload data
                return null;
            }

        }
        public static List<XDocumentSection> getDocumentSections(Int64 doumentDefinitionID)
        {
            if (GlobalStaticCache.documentDefinition.ContainsKey(doumentDefinitionID))
                return GlobalStaticCache.documentDefinition[doumentDefinitionID].documentSections;
            else
            {
                // write code to reload data
                return null;
            }

        }
        public static XDocumentSection getDocumentSectionID(Int32 sectionID)
        {
            if (GlobalStaticCache.documentSection.ContainsKey(sectionID))
                return GlobalStaticCache.documentSection[sectionID];
            else
            {
                // write code to reload data
                return null;
            }

        }


        public static List<XDocumentTable> getDocumentTables(Int32 documentSectionID, Int32 doumentDefinitionID)
        {
            foreach (XDocumentSection documentSection in getDocumentSections(doumentDefinitionID))
            {
                if (documentSection.documentsectionid == documentSectionID)
                    return documentSection.documentTable;
            }

            return null;

        }
        public static XDocumentTable getDocumentTableID(Int32 tableID)
        {
            if (GlobalStaticCache.documentTables.ContainsKey(tableID))
                return GlobalStaticCache.documentTables[tableID];
            else
            {
                // write code to reload data
                return null;
            }

        }

        public static List<XDocumentTableTR> getDocumentTablesTRS(Int32 tableID, Int32 documentSectionID, Int32 doumentDefinitionID)
        {
            foreach (XDocumentTable documenttable in getDocumentTables(documentSectionID, doumentDefinitionID))
            {
                if (documenttable.documentTableID == tableID)
                    return documenttable.trs;
            }

            return null;

        }

        public static XDocumentTableTR getDocumentTablesTRID(Int32 trID)
        {
            if (GlobalStaticCache.documentTablesTR.ContainsKey(trID))
                return GlobalStaticCache.documentTablesTR[trID];
            else
            {
                // write code to reload data
                return null;
            }

        }

        public static List<XDocumentTableTD> getDocumentTablesTDS(Int32 trID, Int32 tableID, Int32 documentSectionID, Int32 doumentDefinitionID)
        {
            foreach (XDocumentTableTR documenttableTR in getDocumentTablesTRS(tableID, documentSectionID, doumentDefinitionID))
            {
                if (documenttableTR.trID == trID)
                    return documenttableTR.tds;
            }

            return null;

        }

        public static XDocumentTableTD getDocumentTablesTDID(Int32 tdID)
        {
            if (GlobalStaticCache.documentTablesTD.ContainsKey(tdID))
                return GlobalStaticCache.documentTablesTD[tdID];
            else
            {
                // write code to reload data
                return null;
            }

        }

        public static List<XDocumentTableContent> getDocumentTablesContents(Int32 tdID, Int32 trID, Int32 tableID, Int32 documentSectionID, Int32 doumentDefinitionID)
        {
            foreach (XDocumentTableTD documenttableTD in getDocumentTablesTDS(trID, tableID, documentSectionID, doumentDefinitionID))
            {
                if (documenttableTD.tdID == tdID)
                    return documenttableTD.fields;
            }

            return null;

        }

        public static XDocumentTableContent getDocumentTablesContentID(Int32 contentID)
        {
            if (GlobalStaticCache.documentContent.ContainsKey(contentID))
                return GlobalStaticCache.documentContent[contentID];
            else
            {
                // write code to reload data
                return null;
            }

        }

        public static List<XDocumentCalculation> getDocumentTablesCalculations(Int32 contentID, Int32 tdID, Int32 trID, Int32 tableID, Int32 documentSectionID, Int32 doumentDefinitionID)
        {
            foreach (XDocumentTableContent documentContent in getDocumentTablesContents(tdID, trID, tableID, documentSectionID, doumentDefinitionID))
            {
                if (documentContent.documentTableContentID == contentID)
                    return documentContent.calculations;
            }

            return null;

        }
        public static XDocumentCalculation getDocumentTablesCalculationID(Int32 calculationID)
        {
            if (GlobalStaticCache.documentCalculation.ContainsKey(calculationID))
                return GlobalStaticCache.documentCalculation[calculationID];
            else
            {
                // write code to reload data
                return null;
            }

        }
    }
}
