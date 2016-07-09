<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertContact.aspx.cs" Inherits="crud.ui.InsertContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form method="post" action="InsertContact.aspx">
    <table border="1">
        <tr>
            <td>姓名：</td>
            <td><input type="text" name="txtName" value="" /></td>
        </tr>
        <tr>
            <td>电话：</td>
            <td><input type="text" name="txtPhone" value="" /></td>
        </tr>
        <tr>
            <td>邮箱：</td>
            <td><input type="text" name="txtEmail" value="" /></td>
        </tr>
        <tr>
            <td>分组：</td>
            <td><select name="selGroup">
                <%foreach (var item in list)
                  {%>
                    <option value="<%=item.GroupId %>"><%=item.GroupName %></option>                 
                 <% } %>               
                </select></td>
        </tr>
        <tr>
            <td></td>
            <td><input type="submit" value="添加" /></td>
        </tr>
    </table>
    </form>
</body>
</html>
