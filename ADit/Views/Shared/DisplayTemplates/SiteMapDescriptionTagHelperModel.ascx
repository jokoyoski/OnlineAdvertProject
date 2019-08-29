<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapDescriptionTagHelperModel,MvcSiteMapProvider]]" %>

<% if (Model.CurrentNode != null && !string.IsNullOrEmpty(Model.CurrentNode.Description)) { %>
<meta name="description" content="<%= Model.CurrentNode.Description %>" />
<meta itemprop="description" content="<%= Model.CurrentNode.Description %>" />
<meta property="og:description" content="<%= Model.CurrentNode.Description %>" />
<% } %>