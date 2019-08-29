using ADit.Domain.Resources;
using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// Get different list items
    /// </summary>
    public static class GetDropDownList
    {
        /// <summary>
        /// Apcons the approval list items.
        /// </summary>
        /// <param name="apconApprovalTypeList">The apcon approval type list.</param>
        /// <param name="selectedApconApprovalTypeId">The selected apcon approval type identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ApconApprovalListItems(IList<IApconApprovalType> apconApprovalTypeList, int? selectedApconApprovalTypeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectApprovalTypeText,
                    Value = "-1",
                    Selected = (selectedApconApprovalTypeId < 1)
                }
            };

            if (apconApprovalTypeList.Any())
            {
                list.AddRange(apconApprovalTypeList.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.ApoconTypeId.ToString(),
                    Selected = (t.ApoconTypeId.Equals(selectedApconApprovalTypeId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Durations the type list items.
        /// </summary>
        /// <param name="durationType">Type of the duration.</param>
        /// <param name="selectedDurationTypecode">The selected duration typecode.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> DurationTypeListItems(IList<IDurationType> durationType,
           string selectedDurationTypecode)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectAdvertDuration,
                    Value = "-1",
                    Selected = (selectedDurationTypecode == "")
                }
            };

            if (durationType.Any())
            {
                list.AddRange(durationType.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.DurationTypeCode.ToString(),
                    Selected = (t.DurationTypeCode.Equals(selectedDurationTypecode))
                }));
            }

            return list;
        }

        /// <summary>
        /// Contacts the list items.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        /// <param name="selectedContactType">Type of the selected contact.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ContactListItems(IList<IContact> contacts,
          int selectedContactType)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectContact,
                    Value = "-1",
                    Selected = (selectedContactType <1)
                }
            };

            if (contacts.Any())
            {
                list.AddRange(contacts.Select(t => new SelectListItem
                {
                    Text = t.Decsription,
                    Value = t.ContactId.ToString(),
                    Selected = (t.ContactId.Equals(selectedContactType))
                }));
            }

            return list;
        }

        /// <summary>
        /// Materias the type time list items.
        /// </summary>
        /// <param name="materialTypeTimeList">The material type time list.</param>
        /// <param name="selectedMaterialTypeTimeId">The selected material type time identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> MateriaTypeTimeListItems(IList<IMaterialTypeTimingDetail> materialTypeTimeList, int selectedMaterialTypeTimeId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectMaterialTypeTimingText,
                    Value = "-1",
                    Selected = (selectedMaterialTypeTimeId < 1)
                }
            };

            if (materialTypeTimeList.Any())
            {
                list.AddRange(materialTypeTimeList.Select(t => new SelectListItem
                {
                    Text = string.Format("{0} - {1}", t.MaterialDescription, t.TimingDescription),
                    Value = t.MaterialTypeTimingId.ToString(),
                    Selected = (t.MaterialTypeTimingId.Equals(selectedMaterialTypeTimeId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Scripts the material question list items.
        /// </summary>
        /// <param name="question">The question.</param>
        /// <param name="selectScriptMaterialQuestionCode">The select script material question code.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ScriptMaterialQuestionListItems(IList<IScriptMaterialQuestion> question,
             string selectScriptMaterialQuestionCode)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.ChooseOption,
                    Value = "",
                    Selected = (selectScriptMaterialQuestionCode == "")
                }
            };

            if (question.Any())
            {
                list.AddRange(question.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.ScriptMaterialQuestionCode.ToString(),
                    Selected = (t.ScriptMaterialQuestionCode.Equals(selectScriptMaterialQuestionCode))
                }));
            }

            return list;
        }

        /// <summary>
        /// Radioes the station list items.
        /// </summary>
        /// <param name="radioStationType">Type of the radio station.</param>
        /// <param name="selectedRadioStationId">The selected radio station identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> RadioStationListItems(IList<IRadioStationModel> radioStationType,
           int selectedRadioStationId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectRadioStation,
                    Value = "-1",
                    Selected = (selectedRadioStationId < 1)
                }
            };

            if (radioStationType.Any())
            {
                list.AddRange(radioStationType.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.RadioStationId.ToString(),
                    Selected = (t.RadioStationId.Equals(selectedRadioStationId))
                }));
            }

            return list;
        }


        /// <summary>
        /// Apcons the approval price list items.
        /// </summary>
        /// <param name="apconApprovalTypePriceList">The apcon approval type price list.</param>
        /// <param name="selectedApconApprovalTypePriceId">The selected apcon approval type price identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ApconApprovalPriceListItems(IList<IApconApprovalTypePrice> apconApprovalTypePriceList, int selectedApconApprovalTypePriceId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectApprovalTypeText,
                    Value = "-1",
                    Selected = (selectedApconApprovalTypePriceId < 1)
                }
            };

            if (apconApprovalTypePriceList.Any())
            {
                list.AddRange(apconApprovalTypePriceList.Select(t => new SelectListItem
                {
                    Text = string.Format("{0} - {1}", t.ApconTypeDescription, t.Amount.ToString("###,###.##")),
                    Value = t.ApconTypePriceId.ToString(),
                    Selected = (t.ApconTypePriceId.Equals(selectedApconApprovalTypePriceId))
                }));
            }

            return list;
        }

        /// <summary>
        /// Tvs the station list items.
        /// </summary>
        /// <param name="tvStation">The tv station.</param>
        /// <param name="selectedTv">The selected tv.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> TvStationListItems(IList<ITvStation> tvStation,
            int selectedTv)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelecteTVStation,
                    Value = "-1",
                    Selected = (selectedTv < 1)
                }
            };

            if (tvStation.Any())
            {
                list.AddRange(tvStation.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.TVStationId.ToString(),
                    Selected = (t.TVStationId.Equals(selectedTv))
                }));
            }

            return list;
        }

        /// <summary>
        /// Called when [duration list items].
        /// </summary>
        /// <param name="onlineDurations">The online durations.</param>
        /// <param name="selectedOnlineDuration">Duration of the selected online.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> OnlineDurationListItems(IList<IOnlineDuration> onlineDurations,
            int selectedOnlineDuration)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = Common.SelectAdvertDuration,
                    Value = "-1",
                    Selected = (selectedOnlineDuration < 1)
                }
            };

            if (onlineDurations.Any())
            {
                list.AddRange(onlineDurations.Select(t => new SelectListItem
                {
                    Text = t.Description,
                    Value = t.OnlineDurationId.ToString(),
                    Selected = (t.OnlineDurationId.Equals(selectedOnlineDuration))
                }));
            }

            return list;
        }

    }
}
