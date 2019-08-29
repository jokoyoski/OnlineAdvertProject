using ADit.Domain.Resources;
using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetDropDownBrandingMaterialList
    {
        /// <summary>
        /// Brandings the material list items.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="selectedBrandingMaterial">The selected branding material.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> BrandingMaterialListItems(IList<IBrandingMaterial> brandingMaterial,
           int selectedBrandingMaterial)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectBrandingMaterialText,
                    Value = "-1",
                    Selected = (selectedBrandingMaterial < 1)
                }
            };

            if (brandingMaterial.Any())
            {
                list.AddRange(brandingMaterial.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.BrandingMaterialId.ToString(),
                    Selected = (t.BrandingMaterialId.Equals(selectedBrandingMaterial))
                }));
            }

            return list;
        }


        /// <summary>
        /// Brandings the material price list items.
        /// </summary>
        /// <param name="brandingMaterial">The branding material.</param>
        /// <param name="selectedBrandingMaterial">The selected branding material.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> BrandingMaterialPriceListItems(IList<IBrandingMaterialPrice> brandingMaterial,
           int selectedBrandingMaterial)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectBrandingMaterialText,
                    Value = "-1",
                    Selected = (selectedBrandingMaterial < 1)
                }
            };

            if (brandingMaterial.Any())
            {
                list.AddRange(brandingMaterial.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.BrandingMaterialId.ToString(),
                    Selected = (t.BrandingMaterialId.Equals(selectedBrandingMaterial))
                }));
            }

            return list;
        }


        /// <summary>
        /// Prints the media apcon price items.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="selectedApcon">The selected apcon.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintMediaApconPriceItems(IList<IApconApprovalTypePrice> view,
       int selectedApcon)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectBrandingMaterialText,
                    Value = "-1",
                    Selected = (selectedApcon < 1)
                }
            };

            if (view.Any())
            {
                list.AddRange(view.Select(t => new SelectListItem
                {
                    Text = t.ApconTypeDescription,
                    Value = t.ApconTypeId.ToString(),
                    Selected = (t.ApconTypeId.Equals(selectedApcon))
                }));
            }

            return list;
        }

        /// <summary>
        /// Prints the media design element items.
        /// </summary>
        /// <param name="designelementprice">The designelementprice.</param>
        /// <param name="selectedDesignElement">The selected design element.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> PrintMediaDesignElementItems(IList<IDesignElementPrice> designelementprice,
       int selectedDesignElement)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectDesignElementText,
                    Value = "-1",
                    Selected = (selectedDesignElement < 1)
                }
            };

            if (designelementprice.Any())
            {
                list.AddRange(designelementprice.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.DesignElementId.ToString(),
                    Selected = (t.DesignElementId.Equals(selectedDesignElement))
                }));
            }

            return list;
        }
    }
}

