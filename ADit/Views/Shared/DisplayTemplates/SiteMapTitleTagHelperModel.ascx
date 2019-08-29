<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapTitleTagHelperModel,MvcSiteMapProvider]]" %>

<% if (Model.CurrentNode != null) { %>
<title><%=Model.CurrentNode.Title%> | <%=Model.CurrentNode.Site%></title>
<meta itemprop="name" content="<%= Model.CurrentNode.Title %>" />
<meta property="og:title" content="<%= Model.CurrentNode.Title %>" />
<% } %>