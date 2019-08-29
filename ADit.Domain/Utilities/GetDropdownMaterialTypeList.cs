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
    public static class GetDropdownMaterialTypeList
    {
        /// <summary>
        /// Materials the type list items.
        /// </summary>
        /// <param name="materialType">Type of the material.</param>
        /// <param name="selectedMaterialTypeId">The selected material type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> MaterialTypeListItems(IList<IMaterialType> materialType,
                      int selectedMaterialTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text = Common.SelectMaterialQuestion,
                    Value = "-1",
                    Selected = (selectedMaterialTypeId < 1)
                }
            };

            if (materialType.Any())
            {
                list.AddRange(materialType.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.MaterialTypeId.ToString(),
                    Selected = (t.MaterialTypeId.Equals(selectedMaterialTypeId))
                }));
            }

            return list;
        }
    }

}

