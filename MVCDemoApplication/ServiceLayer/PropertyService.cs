using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Events;
using Framework.Data;
using Framework.Infrastructure;
using Framework.Domain;
using DataAccess;
using DataAccess.Data;

namespace ServiceLayer
{
   public class PropertyService //: IPropertyService
    {
        #region Fields
       private const string PROPERTIES_BY_ID_KEY = "Nop.property.id-{0}";

        private readonly IRepository<Property> _propertyRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
       
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="propertyRepository">Property repository</param>
        /// <param name="dataProvider">Data provider</param>
        /// <param name="dbContext">Database Context</param>
        public PropertyService(IRepository<Property> propertyRepository,
            IDataProvider dataProvider, IDbContext dbContext)
        {
            this._propertyRepository = propertyRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods

        #region Property

        /// <summary>
        /// Delete a property
        /// </summary>
        /// <param name="property">Property</param>
        public virtual void DeleteProperty(Property property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            property.Deleted = true;
            //delete property
            UpdateProperty(property);

            ////delete property variants
            //foreach (var propertyVariant in property.PropertyVariants)
            //    DeletePropertyVariant(propertyVariant);
        }

        /// <summary>
        /// Gets all propertys
        /// </summary>
        /// <returns>Property collection</returns>
        public virtual IList<Property> GetAllProperties(bool showHidden = false)
        {
            var query = from p in _propertyRepository.Table
                        orderby p.PropertyName
                        where 
                        !p.Deleted
                        select p;
            var properties = query.ToList();
            return properties;
        }

        
        /// <summary>
        /// Gets property
        /// </summary>
        /// <param name="propertyId">Property identifier</param>
        /// <returns>Property</returns>
        public virtual Property GetPropertyById(int propertyId)
        {
            if (propertyId == 0)
                return null;
            var property = _propertyRepository.GetById(propertyId);
                return property;
           
        }

        /// <summary>
        /// Get propertys by identifiers
        /// </summary>
        /// <param name="propertyIds">Property identifiers</param>
        /// <returns>Properties</returns>
        public virtual IList<Property> GetPropertiesByIds(int[] propertyIds)
        {
            if (propertyIds == null || propertyIds.Length == 0)
                return new List<Property>();

            var query = from p in _propertyRepository.Table
                        where propertyIds.Contains(p.Id)
                        select p;
            var propertys = query.ToList();
            //sort by passed identifiers
            var sortedProperties = new List<Property>();
            foreach (int id in propertyIds)
            {
                var property = propertys.Find(x => x.Id == id);
                if (property != null)
                    sortedProperties.Add(property);
            }
            return sortedProperties;
        }

        /// <summary>
        /// Inserts a property
        /// </summary>
        /// <param name="property">Property</param>
        public virtual void InsertProperty(Property property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            _propertyRepository.Insert(property);

            //event notification
            //_eventPublisher.EntityInserted(property);
        }

        /// <summary>
        /// Updates the Property
        /// </summary>
        /// <param name="property">Property</param>
        public virtual void UpdateProperty(Property property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            _propertyRepository.Update(property);

            
            //event notification
            //_eventPublisher.EntityUpdated(property);
        }

        ///// <summary>
        ///// Search propertys
        ///// </summary>
        ///// <returns>Property collection</returns>
        //public virtual IPagedList<Property> SearchProperties(int ProperyId, PropertySortingEnum orderBy,
        //    int pageIndex, int pageSize)
        //{
        //    return SearchProperties(categoryIds, manufacturerId, featuredProperties,
        //        priceMin, priceMax, propertyTagId, 
        //        keywords, searchDescriptions,searchPropertyTags, languageId,
        //        filteredSpecs, orderBy, pageIndex, pageSize,
        //        loadFilterableSpecificationAttributeOptionIds, out filterableSpecificationAttributeOptionIds, 
        //        showHidden);
        //}

        ///// <summary>
        ///// Search propertys
        ///// </summary>
        ///// <param name="categoryIds">Category identifiers</param>
        ///// <param name="manufacturerId">Manufacturer identifier; 0 to load all records</param>
        ///// <param name="featuredProperties">A value indicating whether loaded propertys are marked as featured (relates only to categories and manufacturers). 0 to load featured propertys only, 1 to load not featured propertys only, null to load all propertys</param>
        ///// <param name="priceMin">Minimum price; null to load all records</param>
        ///// <param name="priceMax">Maximum price; null to load all records</param>
        ///// <param name="propertyTagId">Property tag identifier; 0 to load all records</param>
        ///// <param name="keywords">Keywords</param>
        ///// <param name="searchDescriptions">A value indicating whether to search by a specified "keyword" in property descriptions</param>
        ///// <param name="searchPropertyTags">A value indicating whether to search by a specified "keyword" in property tags</param>
        ///// <param name="languageId">Language identifier</param>
        ///// <param name="filteredSpecs">Filtered property specification identifiers</param>
        ///// <param name="orderBy">Order by</param>
        ///// <param name="pageIndex">Page index</param>
        ///// <param name="pageSize">Page size</param>
        ///// <param name="loadFilterableSpecificationAttributeOptionIds">A value indicating whether we should load the specification attribute option identifiers applied to loaded propertys (all pages)</param>
        ///// <param name="filterableSpecificationAttributeOptionIds">The specification attribute option identifiers applied to loaded propertys (all pages)</param>
        ///// <param name="showHidden">A value indicating whether to show hidden records</param>
        ///// <returns>Property collection</returns>
        //public virtual IPagedList<Property> SearchProperties(IList<int> categoryIds, 
        //    int manufacturerId, bool? featuredProperties,
        //    decimal? priceMin, decimal? priceMax, int propertyTagId,
        //    string keywords, bool searchDescriptions, bool searchPropertyTags, int languageId,
        //    IList<int> filteredSpecs, PropertySortingEnum orderBy,
        //    int pageIndex, int pageSize,
        //    bool loadFilterableSpecificationAttributeOptionIds, out IList<int> filterableSpecificationAttributeOptionIds,
        //    bool showHidden = false)
        //{
        //    filterableSpecificationAttributeOptionIds = new List<int>();
        //    bool searchLocalizedValue = false;
        //    if (languageId > 0)
        //    {
        //        if (showHidden)
        //        {
        //            searchLocalizedValue = true;
        //        }
        //        else
        //        {
        //            //ensure that we have at least two published languages
        //            var totalPublishedLanguages = _languageService.GetAllLanguages(false).Count;
        //            searchLocalizedValue = totalPublishedLanguages >= 2;
        //        }
        //    }



        //    if (_commonSettings.UseStoredProceduresIfSupported && _dataProvider.StoredProceduredSupported)
        //    {
        //        //stored procedures are enabled and supported by the database. 
        //        //It's much faster than the LINQ implementation below 

        //        #region Use stored procedure
                
        //        //pass categry identifiers as comma-delimited string
        //        string commaSeparatedCategoryIds = "";
        //        if (categoryIds != null)
        //        {
        //            for (int i = 0; i < categoryIds.Count; i++)
        //            {
        //                commaSeparatedCategoryIds += categoryIds[i].ToString();
        //                if (i != categoryIds.Count - 1)
        //                {
        //                    commaSeparatedCategoryIds += ",";
        //                }
        //            }
        //        }

        //        //pass specification identifiers as comma-delimited string
        //        string commaSeparatedSpecIds = "";
        //        if (filteredSpecs != null)
        //        {
        //            ((List<int>)filteredSpecs).Sort();
        //            for (int i = 0; i < filteredSpecs.Count; i++)
        //            {
        //                commaSeparatedSpecIds += filteredSpecs[i].ToString();
        //                if (i != filteredSpecs.Count - 1)
        //                {
        //                    commaSeparatedSpecIds += ",";
        //                }
        //            }
        //        }

        //        //some databases don't support int.MaxValue
        //        if (pageSize == int.MaxValue)
        //            pageSize = int.MaxValue - 1;
                
        //        //prepare parameters
        //        var pCategoryIds = _dataProvider.GetParameter();
        //        pCategoryIds.ParameterName = "CategoryIds";
        //        pCategoryIds.Value = commaSeparatedCategoryIds != null ? (object)commaSeparatedCategoryIds : DBNull.Value;
        //        pCategoryIds.DbType = DbType.String;
                
        //        var pManufacturerId = _dataProvider.GetParameter();
        //        pManufacturerId.ParameterName = "ManufacturerId";
        //        pManufacturerId.Value = manufacturerId;
        //        pManufacturerId.DbType = DbType.Int32;

        //        var pPropertyTagId = _dataProvider.GetParameter();
        //        pPropertyTagId.ParameterName = "PropertyTagId";
        //        pPropertyTagId.Value = propertyTagId;
        //        pPropertyTagId.DbType = DbType.Int32;

        //        var pFeaturedProperties = _dataProvider.GetParameter();
        //        pFeaturedProperties.ParameterName = "FeaturedProperties";
        //        pFeaturedProperties.Value = featuredProperties.HasValue ? (object)featuredProperties.Value : DBNull.Value;
        //        pFeaturedProperties.DbType = DbType.Boolean;

        //        var pPriceMin = _dataProvider.GetParameter();
        //        pPriceMin.ParameterName = "PriceMin";
        //        pPriceMin.Value = priceMin.HasValue ? (object)priceMin.Value : DBNull.Value;
        //        pPriceMin.DbType = DbType.Decimal;
                
        //        var pPriceMax = _dataProvider.GetParameter();
        //        pPriceMax.ParameterName = "PriceMax";
        //        pPriceMax.Value = priceMax.HasValue ? (object)priceMax.Value : DBNull.Value;
        //        pPriceMax.DbType = DbType.Decimal;

        //        var pKeywords = _dataProvider.GetParameter();
        //        pKeywords.ParameterName = "Keywords";
        //        pKeywords.Value = keywords != null ? (object)keywords : DBNull.Value;
        //        pKeywords.DbType = DbType.String;

        //        var pSearchDescriptions = _dataProvider.GetParameter();
        //        pSearchDescriptions.ParameterName = "SearchDescriptions";
        //        pSearchDescriptions.Value = searchDescriptions;
        //        pSearchDescriptions.DbType = DbType.Boolean;

        //        var pSearchPropertyTags = _dataProvider.GetParameter();
        //        pSearchPropertyTags.ParameterName = "SearchPropertyTags";
        //        pSearchPropertyTags.Value = searchDescriptions;
        //        pSearchPropertyTags.DbType = DbType.Boolean;

        //        var pUseFullTextSearch = _dataProvider.GetParameter();
        //        pUseFullTextSearch.ParameterName = "UseFullTextSearch";
        //        pUseFullTextSearch.Value = _commonSettings.UseFullTextSearch;
        //        pUseFullTextSearch.DbType = DbType.Boolean;

        //        var pFullTextMode = _dataProvider.GetParameter();
        //        pFullTextMode.ParameterName = "FullTextMode";
        //        pFullTextMode.Value = (int)_commonSettings.FullTextMode;
        //        pFullTextMode.DbType = DbType.Int32;

        //        var pFilteredSpecs = _dataProvider.GetParameter();
        //        pFilteredSpecs.ParameterName = "FilteredSpecs";
        //        pFilteredSpecs.Value = commaSeparatedSpecIds != null ? (object)commaSeparatedSpecIds : DBNull.Value;
        //        pFilteredSpecs.DbType = DbType.String;

        //        var pLanguageId = _dataProvider.GetParameter();
        //        pLanguageId.ParameterName = "LanguageId";
        //        pLanguageId.Value = searchLocalizedValue ? languageId : 0;
        //        pLanguageId.DbType = DbType.Int32;

        //        var pOrderBy = _dataProvider.GetParameter();
        //        pOrderBy.ParameterName = "OrderBy";
        //        pOrderBy.Value = (int)orderBy;
        //        pOrderBy.DbType = DbType.Int32;

        //        var pPageIndex = _dataProvider.GetParameter();
        //        pPageIndex.ParameterName = "PageIndex";
        //        pPageIndex.Value = pageIndex;
        //        pPageIndex.DbType = DbType.Int32;

        //        var pPageSize = _dataProvider.GetParameter();
        //        pPageSize.ParameterName = "PageSize";
        //        pPageSize.Value = pageSize;
        //        pPageSize.DbType = DbType.Int32;

        //        var pShowHidden = _dataProvider.GetParameter();
        //        pShowHidden.ParameterName = "ShowHidden";
        //        pShowHidden.Value = showHidden;
        //        pShowHidden.DbType = DbType.Boolean;
                
        //        var pLoadFilterableSpecificationAttributeOptionIds = _dataProvider.GetParameter();
        //        pLoadFilterableSpecificationAttributeOptionIds.ParameterName = "LoadFilterableSpecificationAttributeOptionIds";
        //        pLoadFilterableSpecificationAttributeOptionIds.Value = loadFilterableSpecificationAttributeOptionIds;
        //        pLoadFilterableSpecificationAttributeOptionIds.DbType = DbType.Boolean;
                
        //        var pFilterableSpecificationAttributeOptionIds = _dataProvider.GetParameter();
        //        pFilterableSpecificationAttributeOptionIds.ParameterName = "FilterableSpecificationAttributeOptionIds";
        //        pFilterableSpecificationAttributeOptionIds.Direction = ParameterDirection.Output;
        //        pFilterableSpecificationAttributeOptionIds.Size = int.MaxValue - 1;
        //        pFilterableSpecificationAttributeOptionIds.DbType = DbType.String;

        //        var pTotalRecords = _dataProvider.GetParameter();
        //        pTotalRecords.ParameterName = "TotalRecords";
        //        pTotalRecords.Direction = ParameterDirection.Output;
        //        pTotalRecords.DbType = DbType.Int32;

        //        //invoke stored procedure
        //        var propertys = _dbContext.ExecuteStoredProcedureList<Property>(
        //            "PropertyLoadAllPaged",
        //            pCategoryIds,
        //            pManufacturerId,
        //            pPropertyTagId,
        //            pFeaturedProperties,
        //            pPriceMin,
        //            pPriceMax,
        //            pKeywords,
        //            pSearchDescriptions,
        //            pSearchPropertyTags,
        //            pUseFullTextSearch,
        //            pFullTextMode,
        //            pFilteredSpecs,
        //            pLanguageId,
        //            pOrderBy,
        //            pPageIndex,
        //            pPageSize,
        //            pShowHidden,
        //            pLoadFilterableSpecificationAttributeOptionIds,
        //            pFilterableSpecificationAttributeOptionIds,
        //            pTotalRecords);
        //        //get filterable specification attribute option identifier
        //        string filterableSpecificationAttributeOptionIdsStr = (pFilterableSpecificationAttributeOptionIds.Value != DBNull.Value) ? (string)pFilterableSpecificationAttributeOptionIds.Value : "";
        //        if (loadFilterableSpecificationAttributeOptionIds &&
        //            !string.IsNullOrWhiteSpace(filterableSpecificationAttributeOptionIdsStr))
        //        {
        //             filterableSpecificationAttributeOptionIds = filterableSpecificationAttributeOptionIdsStr
        //                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
        //                .Select(x => Convert.ToInt32(x.Trim()))
        //                .ToList();
        //        }
        //        //return propertys
        //        int totalRecords = (pTotalRecords.Value != DBNull.Value) ? Convert.ToInt32(pTotalRecords.Value) : 0;
        //        return new PagedList<Property>(propertys, pageIndex, pageSize, totalRecords);

        //        #endregion
        //    }
        //    else
        //    {
        //        //stored procedures aren't supported. Use LINQ

        //        #region Search propertys

        //        //propertys
        //        var query = _propertyRepository.Table;
        //        query = query.Where(p => !p.Deleted);
        //        if (!showHidden)
        //        {
        //            query = query.Where(p => p.Published);
        //        }

        //        //searching by keyword
        //        if (!String.IsNullOrWhiteSpace(keywords))
        //        {
        //            query = from p in query
        //                    join lp in _localizedPropertyRepository.Table on p.Id equals lp.EntityId into p_lp
        //                    from lp in p_lp.DefaultIfEmpty()
        //                    from pv in p.PropertyVariants.DefaultIfEmpty()
        //                    from pt in p.PropertyTags.DefaultIfEmpty()
        //                    where (p.Name.Contains(keywords)) ||
        //                          (searchDescriptions && p.ShortDescription.Contains(keywords)) ||
        //                          (searchDescriptions && p.FullDescription.Contains(keywords)) ||
        //                          (pv.Name.Contains(keywords)) ||
        //                          (searchDescriptions && pv.Description.Contains(keywords)) ||
        //                          (searchPropertyTags && pt.Name.Contains(keywords)) ||
        //                          //localized values
        //                          (searchLocalizedValue && lp.LanguageId == languageId && lp.LocaleKeyGroup == "Property" && lp.LocaleKey == "Name" && lp.LocaleValue.Contains(keywords)) ||
        //                          (searchDescriptions && searchLocalizedValue && lp.LanguageId == languageId && lp.LocaleKeyGroup == "Property" && lp.LocaleKey == "ShortDescription" && lp.LocaleValue.Contains(keywords)) ||
        //                          (searchDescriptions && searchLocalizedValue && lp.LanguageId == languageId && lp.LocaleKeyGroup == "Property" && lp.LocaleKey == "FullDescription" && lp.LocaleValue.Contains(keywords))
        //                          //UNDONE search localized values in associated property tags
        //                    select p;
        //        }

        //        //property variants
        //        //The function 'CurrentUtcDateTime' is not supported by SQL Server Compact. 
        //        //That's why we pass the date value
        //        var nowUtc = DateTime.UtcNow;
        //        query = from p in query
        //                from pv in p.PropertyVariants.DefaultIfEmpty()
        //                where
        //                    //deleted
        //                    (showHidden || !pv.Deleted) &&
        //                    //published
        //                    (showHidden || pv.Published) &&
        //                    //price min
        //                    (
        //                        !priceMin.HasValue 
        //                        ||
        //                        //special price (specified price and valid date range)
        //                        ((pv.SpecialPrice.HasValue && ((!pv.SpecialPriceStartDateTimeUtc.HasValue || pv.SpecialPriceStartDateTimeUtc.Value < nowUtc) && (!pv.SpecialPriceEndDateTimeUtc.HasValue || pv.SpecialPriceEndDateTimeUtc.Value > nowUtc))) && (pv.SpecialPrice >= priceMin.Value))
        //                        ||
        //                        //regular price (price isn't specified or date range isn't valid)
        //                        ((!pv.SpecialPrice.HasValue || ((pv.SpecialPriceStartDateTimeUtc.HasValue && pv.SpecialPriceStartDateTimeUtc.Value > nowUtc) || (pv.SpecialPriceEndDateTimeUtc.HasValue && pv.SpecialPriceEndDateTimeUtc.Value < nowUtc))) && (pv.Price >= priceMin.Value))
        //                    ) &&
        //                    //price max
        //                    (
        //                        !priceMax.HasValue 
        //                        ||
        //                        //special price (specified price and valid date range)
        //                        ((pv.SpecialPrice.HasValue && ((!pv.SpecialPriceStartDateTimeUtc.HasValue || pv.SpecialPriceStartDateTimeUtc.Value < nowUtc) && (!pv.SpecialPriceEndDateTimeUtc.HasValue || pv.SpecialPriceEndDateTimeUtc.Value > nowUtc))) && (pv.SpecialPrice <= priceMax.Value))
        //                        ||
        //                        //regular price (price isn't specified or date range isn't valid)
        //                        ((!pv.SpecialPrice.HasValue || ((pv.SpecialPriceStartDateTimeUtc.HasValue && pv.SpecialPriceStartDateTimeUtc.Value > nowUtc) || (pv.SpecialPriceEndDateTimeUtc.HasValue && pv.SpecialPriceEndDateTimeUtc.Value < nowUtc))) && (pv.Price <= priceMax.Value))
        //                    ) &&
        //                    //available dates
        //                    (showHidden || (!pv.AvailableStartDateTimeUtc.HasValue || pv.AvailableStartDateTimeUtc.Value < nowUtc)) &&
        //                    (showHidden || (!pv.AvailableEndDateTimeUtc.HasValue || pv.AvailableEndDateTimeUtc.Value > nowUtc))
        //                select p;


        //        //search by specs
        //        if (filteredSpecs != null && filteredSpecs.Count > 0)
        //        {
        //            query = from p in query
        //                    where !filteredSpecs
        //                               .Except(
        //                                   p.PropertySpecificationAttributes.Where(psa => psa.AllowFiltering).Select(
        //                                       psa => psa.SpecificationAttributeOptionId))
        //                               .Any()
        //                    select p;
        //        }

        //        //category filtering
        //        if (categoryIds != null && categoryIds.Count > 0)
        //        {
        //            //search in subcategories
        //            query = from p in query
        //                    from pc in p.PropertyCategories.Where(pc => categoryIds.Contains(pc.CategoryId))
        //                    where (!featuredProperties.HasValue || featuredProperties.Value == pc.IsFeaturedProperty)
        //                    select p;
        //        }

        //        //manufacturer filtering
        //        if (manufacturerId > 0)
        //        {
        //            query = from p in query
        //                    from pm in p.PropertyManufacturers.Where(pm => pm.ManufacturerId == manufacturerId)
        //                    where (!featuredProperties.HasValue || featuredProperties.Value == pm.IsFeaturedProperty)
        //                    select p;
        //        }

                
        //        //only distinct propertys (group by ID)
        //        //if we use standard Distinct() method, then all fields will be compared (low performance)
        //        //it'll not work in SQL Server Compact when searching propertys by a keyword)
        //        query = from p in query
        //                group p by p.Id
        //                into pGroup
        //                orderby pGroup.Key
        //                select pGroup.FirstOrDefault();

        //        //sort propertys
        //        if (orderBy == PropertySortingEnum.Position && categoryIds != null && categoryIds.Count > 0)
        //        {
        //            //category position
        //            var firstCategoryId = categoryIds[0];
        //            query = query.OrderBy(p => p.PropertyCategories.Where(pc => pc.CategoryId == firstCategoryId).FirstOrDefault().DisplayOrder);
        //        }
        //        else if (orderBy == PropertySortingEnum.Position && manufacturerId > 0)
        //        {
        //            //manufacturer position
        //            query =
        //                query.OrderBy(p => p.PropertyManufacturers.Where(pm => pm.ManufacturerId == manufacturerId).FirstOrDefault().DisplayOrder);
        //        }
        //        //else if (orderBy == PropertySortingEnum.Position && relatedToPropertyId > 0)
        //        //{
        //        //    //sort by related property display order
        //        //    query = from p in query
        //        //            join rp in _relatedPropertyRepository.Table on p.Id equals rp.PropertyId2
        //        //            where (relatedToPropertyId == rp.PropertyId1)
        //        //            orderby rp.DisplayOrder
        //        //            select p;
        //        //}
        //        else if (orderBy == PropertySortingEnum.Position)
        //        {
        //            //sort by name (there's no any position if category or manufactur is not specified)
        //            query = query.OrderBy(p => p.Name);
        //        }
        //        else if (orderBy == PropertySortingEnum.NameAsc)
        //        {
        //            //Name: A to Z
        //            query = query.OrderBy(p => p.Name);
        //        }
        //        else if (orderBy == PropertySortingEnum.NameDesc)
        //        {
        //            //Name: Z to A
        //            query = query.OrderByDescending(p => p.Name);
        //        }
        //        else if (orderBy == PropertySortingEnum.PriceAsc)
        //        {
        //            //Price: Low to High
        //            query = query.OrderBy(p => p.PropertyVariants.FirstOrDefault().Price);
        //        }
        //        else if (orderBy == PropertySortingEnum.PriceDesc)
        //        {
        //            //Price: High to Low
        //            query = query.OrderByDescending(p => p.PropertyVariants.FirstOrDefault().Price);
        //        }
        //        else if (orderBy == PropertySortingEnum.CreatedOn)
        //        {
        //            //creation date
        //            query = query.OrderByDescending(p => p.CreatedOnUtc);
        //        }
        //        else
        //        {
        //            //actually this code is not reachable
        //            query = query.OrderBy(p => p.Name);
        //        }

        //        var propertys = new PagedList<Property>(query, pageIndex, pageSize);

        //        //get filterable specification attribute option identifier
        //        if (loadFilterableSpecificationAttributeOptionIds)
        //        {
        //            var querySpecs = from p in query
        //                             join psa in _propertySpecificationAttributeRepository.Table on p.Id equals psa.PropertyId
        //                             where psa.AllowFiltering
        //                             select psa.SpecificationAttributeOptionId;
        //            //only distinct attributes
        //            filterableSpecificationAttributeOptionIds = querySpecs
        //                .Distinct()
        //                .ToList();
        //        }

        //        //return propertys
        //        return propertys;

        //        #endregion
        //    }
        //}
        #endregion
        #endregion
    }
}
