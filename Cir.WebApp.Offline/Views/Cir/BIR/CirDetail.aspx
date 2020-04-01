<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Cir.WebApp.Offline.Models.Cir.BIR.BIRCirData>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>CirDetail</title>
</head>
<body>    <table class="CirDataViewControl" style="border-collapse: collapse;" cellpadding="0">
    <thead>
                                                    <tr>
                                                        <th></th>
                                                        <th>Name</th>
                                                        <th>CIR ID</th>
                                                        <th>CIM Case</th>
                                                        <th>Component</th>
                                                        <th>Blade s/n</th>
                                                        <th>Report Type</th>

                                                        <th>Created</th>
                                                        <th>Modified</th>
                                                        </tr>

                                        </thead>
                                        <tbody>

  <% if (Model.BirCirDatas.Count > 0)
                               {
                                 foreach (var item in Model.BirCirDatas)
                                   {  %>

                                            <tr>
                                                <td><a href="Details.aspx?id=<%# Eval("CirDataId") %>">

                                                        <img title="View CIR Detail" border="0" src="../../../Images/information.png" /></a>
                                                        <a href="download/PdfDownload.ashx?id=<%# Eval("CirDataId") %>">
                                                            <img title="View as PDF" border="0" src="../../../Images/page_white_acrobat.png" /></a>
                                                        <a href="CirDownloads.ashx?id=<%# Eval("CirDataId") %>">
                                                            <img title="Download for editing" border="0" src="../../../Images/pencil_go.png" /></a></td>
                                                <td><%= item.Name %></td>
                                                <td><%=item.CirId %></td>
                                                <td>
                                                <a href="http://pman-dev.vestas.net/AdvancedSearch.aspx?searchinitiated=true&caseid=<%= item.CIMCaseNumber %>" target="_blank" ><%= item.CIMCaseNumber %></a>
                                                </td>
                                                 <td>Component Type</td>
                                                <td> <%= item.BirDataId %></td>
                                              <td>Report Type</td> 
                                                <td> <%= item.Created %></td>
                                                 <td> <%= item.Modified %></td>
                                                
                                            </tr>
                                          
                                    <% }
                               }
                               else
                               { %>
                            <tr>
                                
                                <td colspan="9" >No Cir found</td>
                            </tr>

                            <%} %>
                                
                                        </tbody>
                                    </table>


</body>
</html>
