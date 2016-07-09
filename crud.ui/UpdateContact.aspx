<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateContact.aspx.cs" Inherits="crud.ui.UpdateContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form action="UpdateContact.aspx" method="post">
        <input type="hidden" name="id" value="<%=model.ContactId %>" />
    <table border="1">
        <tr>
            <td>姓名：</td>
            <td><input type="text" name="txtName" value="<%=model.ContactName %>" /></td>
         </tr>
        <tr>
             <td>电话：</td>
             <td><input type="text" name="txtPhone" value="<%=model.CellPhone %>" /></td>
        </tr>
        <tr>
             <td>邮箱：</td>
             <td><input type="text" name="txtEmail" value="<%=model.Email %>" /></td>
        </tr>
        <tr>
             <td>分组：</td>
            <td><select name="selGroup">
                <%foreach (var item in list)
                  {%>
                <%
                    if(item.GroupId==model.Group.GroupId)
                    {%>
                        <option selected="selected" value="<%=item.GroupId %>"><%=item.GroupName %></option>
                   <% }
                    else
                    {%>
                        <option  value="<%=item.GroupId %>"><%=item.GroupName %></option>
                    <%}
                     %>
                
                      
                 <% }
                     %>
                </select>                
            </td>
            </tr>
        <tr>
             <td></td>
            <td><input type="submit" value="保存" /></td>
        </tr>
    </table>
    </form>
</body>
</html>
