<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapDescriptionHelperModel,MvcSiteMapProvider]]" %>

<% if (Model.CurrentNode != null && !string.IsNullOrEmpty(Model.CurrentNode.Description)) { %>
<%= Model.CurrentNode.Description %>"
<% } %>