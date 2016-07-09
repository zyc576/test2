<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowContact.aspx.cs" Inherits="crud.ui.ShowContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form method="post" action="ShowContact.aspx">
        <a href="InsertContact.aspx">添加</a>
     <table border="1">
         <thead>
             <tr>
                 <th>编号</th>
                 <th>姓名</th>
                  <th>电话</th>
                  <th>邮箱</th>
                  <th>分组</th>
                  <th colspan="2">操作</th>
             </tr>
         </thead>
         <tbody>
             <%if (list != null)
               {%>
                   <%foreach (var item in list)
                   {%>
                       <tr>
                           <td><%=item.ContactId %></td>
                            <td><%=item.ContactName %></td>
                            <td><%=item.CellPhone %></td>
                            <td><%=item.Email %></td>
                            <td><%=item.Group.GroupName %></td>
                            <td><a href="UpdateContact.aspx?id=<%=item.ContactId %>">编辑</a></td>
                            <td><a onclick="return confirm('你确定要删除吗？');" href="DeleteContact.ashx?id=<%=item.ContactId %>">删除</a></td>
                       </tr>
                   <%}
               } %>
         </tbody>
     </table>
        <p>
            <%=page %>
        </p>
    </form>
</body>
</html>
